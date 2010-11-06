using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

using AuthEx = Aont_Mailer.SMTP.AuthentificationException;
using AuthType = Aont_Mailer.SMTP.AuthenticationType;
using MesEx = Aont_Mailer.SMTP.MessageException;
using System.Xml.Serialization;
using System.ComponentModel;


namespace Aont_Mailer.SMTP
{
    public class MessageException : Exception
    {
        public MessageException(string Message)
            : base(Message) { }
    }
    public class AuthentificationException : Exception
    {
        public AuthentificationException(string Type)
            : base(string.Format("{0} is invalid.", Type)) { }
    }



    public class Client : IDisposable
    {

        #region 変数＆プロパティー
        TcpClient tcpClient;
        NetworkStream networkStream;
        StreamReader streamReader;

        string _FQDN = null;
        public string FQDN
        {
            get
            {
                if (_FQDN == null)
                    return Dns.GetHostName();
                else
                    return _FQDN;
            }
            set
            {
                _FQDN = value;
            }
        }

        public int ReadTimeout
        {
            get
            {
                return this.networkStream.ReadTimeout;
            }
            set
            {
                this.networkStream.ReadTimeout = value;
            }
        }

        string[] authenticationTypes;

        #endregion
        #region コンストラクタ
        public Client(string Server, int Port)
        {
            this.tcpClient = new TcpClient(Server, Port);
            this.networkStream = tcpClient.GetStream();
            this.streamReader = new StreamReader(networkStream);
            
            ReadToEnd("220");

            WriteLine("EHLO ", this.FQDN);
            foreach (string read in ReadToEnd("250"))
            {
                if (read.StartsWith("250-AUTH "))
                {
                    authenticationTypes = read.Substring(9).Split(' ', '\0');
                }
            }
        }
        public Client(string Server) : this(Server, 25) { }


        #endregion

        #region 認証



        public void AuthPlain(string User, string Password)
        {
            AuthCheck("PLAIN");
            WriteLine("AUTH PLAIN ", EncodeBase64(User + '\0' + User + '\0' + Password));
            ReadToEnd("235");
        }
        public void AuthLogin(string User, string Password)
        {

            AuthCheck("LOGIN");
            WriteLine("AUTH LOGIN");
            ReadToEnd("334");
            WriteLine(EncodeBase64(User));
            ReadToEnd("334");
            WriteLine(EncodeBase64(Password));
            ReadToEnd("235");
        }

        public void AuthCramMD5(string User, string Password)
        {
            AuthCheck("CRAM-MD5");
            WriteLine("AUTH CRAM-MD5");
            byte[] data = System.Convert.FromBase64String(ReadLine().Substring(4));
            byte[] key = Encoding.ASCII.GetBytes(Password);
            WriteLine(EncodeBase64(User + " " + HMAC_MD5(data, key)));
            ReadToEnd("235");
        }

        public void Auth(AuthType Type, string User, string Password)
        {
            switch (Type)
            {
                case AuthenticationType.Plain:
                    AuthPlain(User, Password);
                    break;
                case AuthenticationType.Login:
                    AuthLogin(User, Password);
                    break;
                case AuthenticationType.CramMD5:
                    AuthCramMD5(User, Password);
                    break;
            }
        }
        public void Auth(string Type, string User, string Password)
        {
            Type = Type.ToUpper();
            switch (Type)
            {
                case "PLAIN":
                    AuthPlain(User, Password);
                    break;
                case "LOGIN":
                    AuthLogin(User, Password);
                    break;
                case "CRAM-MD5":
                    AuthCramMD5(User, Password);
                    break;
            }
        }

        void AuthCheck(string Type)
        {
            foreach (string type in authenticationTypes)
            {
                if (type == Type)
                    return;
            } throw new AuthEx(Type);
        }

        #endregion
        #region 各種コマンド
        public void From(string from)
        {
            WriteLine("MAIL FROM:<", from, ">");
            ReadLine("250");
        }
        public void Recipient(string rcpt)
        {
            WriteLine("RCPT TO:<", rcpt, ">");
            ReadLine("250", "251");
        }
        public void Recipient(params string[] rcpts)
        {
            foreach (string rcpt in rcpts)
            {
                if(rcpt != "")
                    Recipient(rcpt);
            }
        }
        #region Send
        public void Send(byte[] data, int offset, int size)
        {
            WriteLine("DATA");
            ReadToEnd("250", "354");
            Write(data, offset, size);
            WriteLine();
            WriteLine(".");
            ReadToEnd("250");
        }
        public void Send(byte[] data)
        {
            WriteLine("DATA");
            ReadToEnd("250", "354");
            WriteLine(data);
            WriteLine(".");
            ReadToEnd("250");
        }
        public void Send(string value, Encoding encoding)
        {
            Send(encoding.GetBytes(value));
        }
        public void Send(string value)
        {
            Send(Encoding.ASCII.GetBytes(value));
        }
        public void Send(Stream stream, int offset, int size)
        {
            WriteLine("DATA");
            ReadToEnd("250", "354");

            byte[] data = new byte[size];
            stream.Read(data, offset, size);
            WriteLine(data);

            WriteLine(".");
            ReadToEnd("250");
        }
        public void Send(Stream stream)
        {
            WriteLine("DATA");
            ReadToEnd("250", "354");

            while (true)
            {
                int read = stream.ReadByte();
                if (read == -1)
                    break;
                else
                    Write((byte)read);
            }
            WriteLine();
            WriteLine(".");
            ReadToEnd("250");
        }
        public void SendFile(string FileName)
        {
            FileStream fileStream = new FileStream(FileName, FileMode.Open);
            Send(fileStream);
            fileStream.Dispose();
        }
        #endregion
        public void Quit()
        {
            WriteLine("QUIT");
            ReadLine("221");
        }

        #endregion
        #region 応答の読み取り
        //使わないMethods
        //int ReadByte() { return streamReader.Read(); }
        //int Read(char[] buffer, int offset, int size) { return streamReader.Read(buffer, offset, size); }
        string ReadLine() { return streamReader.ReadLine(); }
        string ReadLine(params string[] codes)
        {
            string read = streamReader.ReadLine();
            foreach (string code in codes)
            {
                if (read.StartsWith(code))
                    return read;
            }
            throw new MesEx(read);
        }
        List<string> ReadToEnd(params string[] codes)
        {
            string read;
            List<string> messages = new List<string>();
            do
            {
                read = ReadLine(codes);
                messages.Add(read);

            } while (read[3] == '-');
            return messages;
        }
        #endregion
        #region コマンドの送信
        void Write(byte value) { networkStream.WriteByte(value); }
        void Write(byte[] buffer, int offset, int size) { networkStream.Write(buffer, offset, size); }
        void Write(params byte[] buffer) { networkStream.Write(buffer, 0, buffer.Length); }
        void Write(params byte[][] buffers)
        {
            foreach (byte[] buffer in buffers)
            {
                Write(buffer);
            }
        }
        void Write(string value)
        {
            byte[] bytearray = Encoding.ASCII.GetBytes(value);
            Write(bytearray);
        }
        void Write(params string[] values)
        {
            foreach (string value in values)
            {
                Write(value);
            }
        }
        void WriteLine(string value)
        {
            Write(value);
            Write(13, 10);
        }
        void WriteLine() { Write(13, 10); }
        void WriteLine(params string[] values)
        {
            foreach (string value in values)
            {
                Write(value);
            }
            WriteLine();
        }
        void WriteLine(params byte[] data)
        {
            Write(data);
            WriteLine();
        }
        void WriteLines(params string[] values)
        {
            foreach (string value in values)
            {
                WriteLine(value);
            }
        }

        #endregion
        #region 文字列の符号化

        static string EncodeBase64(string value)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(value), Base64FormattingOptions.None);
        }

        static string HMAC_MD5(byte[] data, byte[] key)
        {
            HMACMD5 hmacmd5 = new HMACMD5(key);
            byte[] hmacData = hmacmd5.ComputeHash(data);

            StringBuilder result = new StringBuilder();
            foreach (byte b in hmacData)
            {
                result.Append(b.ToString("x2"));
            }

            return result.ToString();
        }
        #endregion

        #region IDisposable メンバ

        void IDisposable.Dispose()
        {

            this.tcpClient.Close();
            this.networkStream.Dispose();
        }

        #endregion

    }
}