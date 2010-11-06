using System;
using System.Windows.Forms;
namespace Aont_Mailer
{
    partial class AontMailer
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AontMailer());
        }

        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label from_label1;
            System.Windows.Forms.Label recipient_label2;
            System.Windows.Forms.Label eml_label3;
            System.Windows.Forms.Button eml_button2;
            System.Windows.Forms.Button send_button5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AontMailer));
            this.Settings_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新規作成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くtoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.標準設定読み込みToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.名前を付けて保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openEMLDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveSettingsdialogue = new System.Windows.Forms.SaveFileDialog();
            this.設定 = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.from_textBox1 = new System.Windows.Forms.TextBox();
            this.recipient_textBox2 = new System.Windows.Forms.TextBox();
            this.eml_tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.eml_textBox3 = new System.Windows.Forms.TextBox();
            this.openSettingsDialog = new System.Windows.Forms.OpenFileDialog();
            from_label1 = new System.Windows.Forms.Label();
            recipient_label2 = new System.Windows.Forms.Label();
            eml_label3 = new System.Windows.Forms.Label();
            eml_button2 = new System.Windows.Forms.Button();
            send_button5 = new System.Windows.Forms.Button();
            this.Settings_contextMenu.SuspendLayout();
            this.設定.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.eml_tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // from_label1
            // 
            from_label1.AutoSize = true;
            from_label1.Dock = System.Windows.Forms.DockStyle.Fill;
            from_label1.Location = new System.Drawing.Point(3, 0);
            from_label1.Name = "from_label1";
            from_label1.Size = new System.Drawing.Size(63, 25);
            from_label1.TabIndex = 0;
            from_label1.Text = "送信者";
            from_label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // recipient_label2
            // 
            recipient_label2.AutoSize = true;
            recipient_label2.Dock = System.Windows.Forms.DockStyle.Fill;
            recipient_label2.Location = new System.Drawing.Point(3, 25);
            recipient_label2.Name = "recipient_label2";
            recipient_label2.Size = new System.Drawing.Size(63, 379);
            recipient_label2.TabIndex = 2;
            recipient_label2.Text = "あて先";
            recipient_label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // eml_label3
            // 
            eml_label3.AutoSize = true;
            eml_label3.Dock = System.Windows.Forms.DockStyle.Fill;
            eml_label3.Location = new System.Drawing.Point(3, 404);
            eml_label3.Name = "eml_label3";
            eml_label3.Size = new System.Drawing.Size(63, 28);
            eml_label3.TabIndex = 4;
            eml_label3.Text = "送信ファイル";
            eml_label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // eml_button2
            // 
            eml_button2.AutoSize = true;
            eml_button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            eml_button2.Location = new System.Drawing.Point(443, 3);
            eml_button2.Name = "eml_button2";
            eml_button2.Size = new System.Drawing.Size(39, 22);
            eml_button2.TabIndex = 1;
            eml_button2.Text = "参照";
            eml_button2.UseVisualStyleBackColor = true;
            eml_button2.Click += new System.EventHandler(this.eml_button2_Click);
            // 
            // send_button5
            // 
            send_button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            send_button5.AutoSize = true;
            send_button5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            send_button5.Location = new System.Drawing.Point(512, 435);
            send_button5.Name = "send_button5";
            send_button5.Size = new System.Drawing.Size(39, 22);
            send_button5.TabIndex = 6;
            send_button5.Text = "送信";
            send_button5.UseVisualStyleBackColor = true;
            send_button5.Click += new System.EventHandler(this.send_button5_Click);
            // 
            // Settings_contextMenu
            // 
            this.Settings_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新規作成ToolStripMenuItem,
            this.開くtoolStripMenuItem2,
            this.標準設定読み込みToolStripMenuItem,
            this.toolStripSeparator,
            this.名前を付けて保存ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.Settings_contextMenu.Name = "contextMenuStrip1";
            this.Settings_contextMenu.Size = new System.Drawing.Size(213, 120);
            // 
            // 新規作成ToolStripMenuItem
            // 
            this.新規作成ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新規作成ToolStripMenuItem.Image")));
            this.新規作成ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新規作成ToolStripMenuItem.Name = "新規作成ToolStripMenuItem";
            this.新規作成ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新規作成ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.新規作成ToolStripMenuItem.Text = "クリア";
            this.新規作成ToolStripMenuItem.Click += new System.EventHandler(this.新規作成ToolStripMenuItem_Click);
            // 
            // 開くtoolStripMenuItem2
            // 
            this.開くtoolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("開くtoolStripMenuItem2.Image")));
            this.開くtoolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.開くtoolStripMenuItem2.Name = "開くtoolStripMenuItem2";
            this.開くtoolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.開くtoolStripMenuItem2.Size = new System.Drawing.Size(212, 22);
            this.開くtoolStripMenuItem2.Text = "開く";
            this.開くtoolStripMenuItem2.Click += new System.EventHandler(this.開くtoolStripMenuItem2_Click);
            // 
            // 標準設定読み込みToolStripMenuItem
            // 
            this.標準設定読み込みToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("標準設定読み込みToolStripMenuItem.Image")));
            this.標準設定読み込みToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.標準設定読み込みToolStripMenuItem.Name = "標準設定読み込みToolStripMenuItem";
            this.標準設定読み込みToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.標準設定読み込みToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.標準設定読み込みToolStripMenuItem.Text = "標準設定の読み込み";
            this.標準設定読み込みToolStripMenuItem.Click += new System.EventHandler(this.標準の読み込みToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(209, 6);
            // 
            // 名前を付けて保存ToolStripMenuItem
            // 
            this.名前を付けて保存ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("名前を付けて保存ToolStripMenuItem.Image")));
            this.名前を付けて保存ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.名前を付けて保存ToolStripMenuItem.Name = "名前を付けて保存ToolStripMenuItem";
            this.名前を付けて保存ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.名前を付けて保存ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.名前を付けて保存ToolStripMenuItem.Text = "名前を付けて保存";
            this.名前を付けて保存ToolStripMenuItem.Click += new System.EventHandler(this.名前を付けて保存ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.toolStripMenuItem1.Text = "標準設定として保存";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // openEMLDialog
            // 
            this.openEMLDialog.DefaultExt = "*.eml";
            this.openEMLDialog.Filter = "EML (*.eml)|*.eml|MHTML (*.mht)|*.mht |All files (*.*)|*.*";
            // 
            // saveSettingsdialogue
            // 
            this.saveSettingsdialogue.DefaultExt = "*.xml";
            this.saveSettingsdialogue.Filter = "XML (*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // 設定
            // 
            this.設定.BackColor = System.Drawing.Color.White;
            this.設定.Controls.Add(this.propertyGrid1);
            this.設定.Location = new System.Drawing.Point(4, 21);
            this.設定.Name = "設定";
            this.設定.Padding = new System.Windows.Forms.Padding(3);
            this.設定.Size = new System.Drawing.Size(560, 466);
            this.設定.TabIndex = 1;
            this.設定.Text = "設定";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.BackColor = System.Drawing.Color.White;
            this.propertyGrid1.ContextMenuStrip = this.Settings_contextMenu;
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpBackColor = System.Drawing.Color.White;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(554, 460);
            this.propertyGrid1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.設定);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 491);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 466);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "メッセージ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(from_label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.from_textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(recipient_label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.recipient_textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(eml_label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.eml_tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(send_button5, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(554, 460);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // from_textBox1
            // 
            this.from_textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.from_textBox1.Location = new System.Drawing.Point(72, 3);
            this.from_textBox1.Name = "from_textBox1";
            this.from_textBox1.Size = new System.Drawing.Size(479, 19);
            this.from_textBox1.TabIndex = 1;
            // 
            // recipient_textBox2
            // 
            this.recipient_textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipient_textBox2.Location = new System.Drawing.Point(72, 28);
            this.recipient_textBox2.Multiline = true;
            this.recipient_textBox2.Name = "recipient_textBox2";
            this.recipient_textBox2.Size = new System.Drawing.Size(479, 373);
            this.recipient_textBox2.TabIndex = 3;
            // 
            // eml_tableLayoutPanel3
            // 
            this.eml_tableLayoutPanel3.AutoSize = true;
            this.eml_tableLayoutPanel3.ColumnCount = 2;
            this.eml_tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.eml_tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.eml_tableLayoutPanel3.Controls.Add(this.eml_textBox3, 0, 0);
            this.eml_tableLayoutPanel3.Controls.Add(eml_button2, 1, 0);
            this.eml_tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eml_tableLayoutPanel3.Location = new System.Drawing.Point(69, 404);
            this.eml_tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.eml_tableLayoutPanel3.Name = "eml_tableLayoutPanel3";
            this.eml_tableLayoutPanel3.RowCount = 1;
            this.eml_tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.eml_tableLayoutPanel3.Size = new System.Drawing.Size(485, 28);
            this.eml_tableLayoutPanel3.TabIndex = 5;
            // 
            // eml_textBox3
            // 
            this.eml_textBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.eml_textBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.eml_textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eml_textBox3.Location = new System.Drawing.Point(3, 3);
            this.eml_textBox3.Name = "eml_textBox3";
            this.eml_textBox3.Size = new System.Drawing.Size(434, 19);
            this.eml_textBox3.TabIndex = 0;
            // 
            // openSettingsDialog
            // 
            this.openSettingsDialog.DefaultExt = "*.xml";
            this.openSettingsDialog.Filter = "XML (*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // AontMailer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 491);
            this.Controls.Add(this.tabControl1);
            this.Name = "AontMailer";
            this.Text = "Aont Mailer";
            this.Settings_contextMenu.ResumeLayout(false);
            this.設定.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.eml_tableLayoutPanel3.ResumeLayout(false);
            this.eml_tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

      private  OpenFileDialog openEMLDialog = new OpenFileDialog();
        private ContextMenuStrip Settings_contextMenu;
        private ToolStripMenuItem 新規作成ToolStripMenuItem;
        private ToolStripMenuItem 標準設定読み込みToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem 名前を付けて保存ToolStripMenuItem;
        private TabPage 設定;
        private PropertyGrid propertyGrid1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox from_textBox1;
        private TableLayoutPanel eml_tableLayoutPanel3;
        private TextBox eml_textBox3;
        private TextBox recipient_textBox2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem 開くtoolStripMenuItem2;
        private OpenFileDialog openSettingsDialog;

    }
}

