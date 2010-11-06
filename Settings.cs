using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;
using System.Globalization;

namespace Aont_Mailer.SMTP

{
    public enum AuthenticationType { None, Plain, Login, CramMD5 }

    public class Settings
    {
        public Client CreateClient()
        {
            Client client = new Client(this.サーバー.アドレス, this.サーバー.ポート);
            if (this.認証 != null)
                if (this.認証.認証方法 != AuthenticationType.None)
                    client.Auth(this.認証.認証方法, this.認証.ユーザ名, this.認証.パスワード);
            return client;
        }
        

        [Category("設定")]
        [Description("SMTPサーバーの情報")]
        [TypeConverter(typeof(SortExpandConverter))]
        public Server サーバー { get; set; }


        [Category("設定")]
        [Description("認証設定")]
        [TypeConverter(typeof(SortExpandConverter))]
        public Authentification 認証 { get; set; }

        public Settings()
        {
            this.サーバー = new Server();
            this.認証 = new Authentification();
            //this.message = new Message();
        }
        public Settings(Server server, Authentification authentification/*, Message message*/)
        {
            this.サーバー = server;
            this.認証 = authentification;
            //this.message = message;
        }


        static XmlSerializer Serializer = new XmlSerializer(typeof(Settings));
        public void Save(string XMLPath)
        {
            using (FileStream stream = new FileStream(XMLPath, FileMode.Create))
            {
                Serializer.Serialize(stream, this);
            }
        }
        static public Settings Load(string XMLPath)
        {
            using (FileStream stream = new FileStream(XMLPath, FileMode.Open))
            {
                return Serializer.Deserialize(stream) as Settings;
            }
        }

    }

    public class Server
    {
        public string アドレス { get; set; }
        public int ポート { get; set; }
        public Server(string Address, int Port)
        {
            this.アドレス = Address;
            this.ポート = Port;
        }
        public Server(string Address)
        {
            this.アドレス = Address;
            this.ポート = 25;
        }
        public Server() {
            this.アドレス = "localhost";
            this.ポート = 25; 
        }
    }

    public class Authentification
    {
        public AuthenticationType 認証方法 { get; set; }
        public string ユーザ名 { get; set; }
        public string パスワード { get; set; }
        public Authentification(string AuthType, string User, string Password)
        {
            this.認証方法 =  AuthenticationType.None;
            this.ユーザ名 = User;
            this.パスワード = Password;
        }
        public Authentification() { this.認証方法 = AuthenticationType.None; }
    }


    public class SortExpandConverter : ExpandableObjectConverter
    {

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {

            // 現在のプロパティ一覧を得る
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value, attributes, true);

            // ソートして返す
            return properties.Sort(new string[] { "認証方法", "ユーザ名", "パスワード", "アドレス", "ポート" });


        }

        //コンバータがオブジェクトを指定した型に変換できるか
        //（変換できる時はTrueを返す）
        //ここでは、CustomClass型のオブジェクトには変換可能とする
        public override bool CanConvertTo(
            ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Authentification) |
                destinationType == typeof(Server))
            {
                return true;
            }
            else
            {
                return base.CanConvertTo(context, destinationType);
            }
        }

        //指定した値オブジェクトを、指定した型に変換する
        //CustomClass型のオブジェクトをString型に変換する方法を提供する
        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value is Authentification)
                {
                    Authentification auth = value as Authentification;
                    return auth.認証方法;
                }
                else if (value is Server)
                {
                    Server server = value as Server;
                    return string.Format("smtp://{0}:{1}", server.アドレス, server.ポート);
                }
            }
            
                return base.ConvertTo(context, culture, value, destinationType);
        }


    }
}
