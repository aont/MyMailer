using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Aont_Mailer.SMTP;

namespace Aont_Mailer
{
    public partial class AontMailer : Form
    {
        public AontMailer()
        {
            InitializeComponent();
            標準の読み込みToolStripMenuItem_Click_1(null, null);

        }
        Settings settings
        {
            get
            {
                Settings _settings = this.propertyGrid1.SelectedObject as Settings;
                if (_settings == null)
                    this.propertyGrid1.SelectedObject = _settings = new Settings();


                    return _settings;
            }
            set
            {
                this.propertyGrid1.SelectedObject = value;
            }
        }
        private void 新規作成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.settings = new Settings();
        }

        SaveFileDialog saveSettingsdialogue;
        private void 名前を付けて保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveSettingsdialogue = new SaveFileDialog();
            if (saveSettingsdialogue.ShowDialog() == DialogResult.OK)
            {
                this.settings.Save(saveSettingsdialogue.FileName);
            }
        }

        private void eml_button2_Click(object sender, EventArgs e)
        {
            if(openEMLDialog.ShowDialog() == DialogResult.OK)
            {
                this.eml_textBox3.Text = openEMLDialog.FileName;
            }
        }

        private void send_button5_Click(object sender, EventArgs e)
        {
            try
            {
                Client smtp = this.settings.CreateClient();
                smtp.From(this.from_textBox1.Text);
                smtp.Recipient(this.recipient_textBox2.Text.Split(',', '\r', '\n', ' '));
                smtp.SendFile(this.eml_textBox3.Text);

                MessageBox.Show("送信完了!");
            }
            catch (Exception _e)
            {
                MessageBox.Show(_e.ToString(), _e.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
                this.settings.Save("settings.xml");
        }

        private void 標準の読み込みToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.settings = Settings.Load("settings.xml");
            }
            catch { }
        }

        private void 開くtoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.openSettingsDialog.ShowDialog() == DialogResult.OK)
            {
                this.settings = Settings.Load(this.openSettingsDialog.FileName);
            }
        }




    }
}
