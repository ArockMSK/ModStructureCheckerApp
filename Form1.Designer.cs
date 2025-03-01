namespace ModStructureCheckerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            languageMenu = new ToolStripMenuItem();
            languageEnglish = new ToolStripMenuItem();
            languageRussian = new ToolStripMenuItem();
            languageChinese = new ToolStripMenuItem(); // Добавляем китайский
            btnSelectFolder = new Button();
            btnRun = new Button();
            txtStatus = new TextBox();
            label1 = new Label();
            btnSaveFolder = new Button();
            txtSavePath = new TextBox();
            label2 = new Label();
            labelAuthor = new Label();
            SuspendLayout();

            // menuStrip1
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(430, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";

            // languageMenu
            languageMenu.Name = "languageMenu";
            languageMenu.Size = new Size(61, 20);
            languageMenu.Text = "Language";
            languageMenu.DropDownItems.AddRange(new ToolStripItem[] { languageEnglish, languageRussian, languageChinese });
            menuStrip1.Items.Add(languageMenu);

            // languageEnglish
            languageEnglish.Name = "languageEnglish";
            languageEnglish.Size = new Size(180, 22);
            languageEnglish.Text = "English";
            languageEnglish.Click += new EventHandler(languageEnglish_Click);

            // languageRussian
            languageRussian.Name = "languageRussian";
            languageRussian.Size = new Size(180, 22);
            languageRussian.Text = "Русский";
            languageRussian.Click += new EventHandler(languageRussian_Click);

            // languageChinese
            languageChinese.Name = "languageChinese";
            languageChinese.Size = new Size(180, 22);
            languageChinese.Text = "中文";
            languageChinese.Click += new EventHandler(languageChinese_Click);

            // btnSelectFolder
            btnSelectFolder.Location = new Point(12, 36);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(150, 30);
            btnSelectFolder.TabIndex = 0;
            btnSelectFolder.Text = "Select Folder 📁";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += new EventHandler(btnSelectFolder_Click);

            // btnRun
            btnRun.Location = new Point(168, 36);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(150, 30);
            btnRun.TabIndex = 1;
            btnRun.Text = "Run Analysis ▶️";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += new EventHandler(btnRun_Click);

            // txtStatus
            txtStatus.Location = new Point(13, 106);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.ScrollBars = ScrollBars.Vertical;
            txtStatus.Size = new Size(406, 138);
            txtStatus.TabIndex = 2;

            // label1
            label1.AutoSize = true;
            label1.Location = new Point(13, 79);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 3;
            label1.Text = "Status: 📋";

            // btnSaveFolder
            btnSaveFolder.Location = new Point(12, 279);
            btnSaveFolder.Name = "btnSaveFolder";
            btnSaveFolder.Size = new Size(229, 30);
            btnSaveFolder.TabIndex = 4;
            btnSaveFolder.Text = "Select Save Folder 📂";
            btnSaveFolder.UseVisualStyleBackColor = true;
            btnSaveFolder.Click += new EventHandler(btnSaveFolder_Click);

            // txtSavePath
            txtSavePath.Location = new Point(12, 315);
            txtSavePath.Name = "txtSavePath";
            txtSavePath.Size = new Size(406, 23);
            txtSavePath.TabIndex = 5;

            // label2
            label2.AutoSize = true;
            label2.Location = new Point(13, 261);
            label2.Name = "label2";
            label2.Size = new Size(149, 15);
            label2.TabIndex = 6;
            label2.Text = "Save Folder: 🗂️";

            // labelAuthor
            labelAuthor.AutoSize = true;
            labelAuthor.Location = new Point(12, 344);
            labelAuthor.Name = "labelAuthor";
            labelAuthor.Size = new Size(200, 15);
            labelAuthor.TabIndex = 7;
            labelAuthor.Text = "v1.0.0 by Arock (Built with Grok from xAI)";

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 374);
            Controls.Add(menuStrip1);
            Controls.Add(labelAuthor);
            Controls.Add(label2);
            Controls.Add(txtSavePath);
            Controls.Add(btnSaveFolder);
            Controls.Add(label1);
            Controls.Add(txtStatus);
            Controls.Add(btnRun);
            Controls.Add(btnSelectFolder);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Mod Structure Checker";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem languageMenu;
        private ToolStripMenuItem languageEnglish;
        private ToolStripMenuItem languageRussian;
        private ToolStripMenuItem languageChinese; // Новый элемент
        private Button btnSelectFolder;
        private Button btnRun;
        private TextBox txtStatus;
        private Label label1;
        private Button btnSaveFolder;
        private TextBox txtSavePath;
        private Label label2;
        private Label labelAuthor;
    }
}