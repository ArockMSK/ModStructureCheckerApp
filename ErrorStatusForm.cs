using System;
using System.Windows.Forms;

namespace ModStructureCheckerApp
{
    public partial class ErrorStatusForm : Form
    {
        private TextBox txtErrorLog = null!;
        private Button btnClose = null!;

        public ErrorStatusForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            txtErrorLog = new TextBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // txtErrorLog
            // 
            txtErrorLog.Location = new Point(0, 0);
            txtErrorLog.Name = "txtErrorLog";
            txtErrorLog.Size = new Size(372, 23);
            txtErrorLog.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(0, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Click += BtnClose_Click;
            // 
            // ErrorStatusForm
            // 
            ClientSize = new Size(384, 250);
            Controls.Add(btnClose);
            Controls.Add(txtErrorLog);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ErrorStatusForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Error Status";
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        public void AddError(string errorMessage)
        {
            if (txtErrorLog.Text.Length > 0)
                txtErrorLog.Text += "\r\n";
            txtErrorLog.Text += $"[{DateTime.Now:HH:mm:ss}] {errorMessage} ❌";
        }

        public bool IsErrorLogEmpty()
        {
            return string.IsNullOrEmpty(txtErrorLog.Text);
        }

        public void UpdateLanguage(string language)
        {
            if (language == "English")
            {
                Text = "Error Status";
                btnClose.Text = "Close";
            }
            else if (language == "Russian")
            {
                Text = "Статус ошибок";
                btnClose.Text = "Закрыть";
            }
            else // Chinese
            {
                Text = "错误状态";
                btnClose.Text = "关闭";
            }
        }
    }
}