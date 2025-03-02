using System;
using System.IO;
using System.Windows.Forms;

namespace ModStructureCheckerApp
{
    public partial class ErrorStatusForm : Form
    {
        private TextBox txtErrorLog = null!;
        private Button btnClose = null!;
        private string saveFolder;
        private string currentLanguage;

        public ErrorStatusForm(string saveFolder, string currentLanguage)
        {
            this.saveFolder = saveFolder;
            this.currentLanguage = currentLanguage;
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
            txtErrorLog.Location = new Point(12, 38);
            txtErrorLog.Multiline = true;
            txtErrorLog.Name = "txtErrorLog";
            txtErrorLog.Size = new Size(521, 209);
            txtErrorLog.TabIndex = 1;
            txtErrorLog.ScrollBars = ScrollBars.Vertical;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(12, 9);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Click += BtnClose_Click;
            // 
            // ErrorStatusForm
            // 
            ClientSize = new Size(545, 274);
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

            string errorFile = Path.Combine(saveFolder, "ScanErrors.txt");
            string tip = GetErrorTip(errorMessage, currentLanguage);
            File.AppendAllText(errorFile, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {errorMessage}\r\n{tip}\r\n");
        }

        public void CompleteScan()
        {
            if (txtErrorLog.Text.Length > 0)
                txtErrorLog.Text += "\r\n";
            txtErrorLog.Text += $"[{DateTime.Now:HH:mm:ss}] {TranslateScanComplete(currentLanguage)} ✅";

            string errorFile = Path.Combine(saveFolder, "ScanErrors.txt");
            File.AppendAllText(errorFile, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {TranslateScanComplete(currentLanguage)}\r\n-----\r\n");
        }

        private string TranslateScanComplete(string language)
        {
            return language == "English" ? "Scan completed" :
                   language == "Russian" ? "Сканирование завершено" :
                   "扫描完成";
        }

        private string GetErrorTip(string errorMessage, string language)
        {
            if (errorMessage.Contains("Access Denied") || errorMessage.Contains("Доступ к пути запрещён") || errorMessage.Contains("路径访问被拒绝"))
            {
                return language == "English" ? "Tip: Ensure you have permission to access this file. Try running the app as an administrator." :
                       language == "Russian" ? "Совет: Убедитесь, что у вас есть права доступа к файлу. Попробуйте запустить приложение от имени администратора." :
                       "提示: 确保您有权限访问此文件。请尝试以管理员身份运行应用程序。";
            }
            else if (errorMessage.Contains("File Not Found") || errorMessage.Contains("Файл не найден") || errorMessage.Contains("文件未找到"))
            {
                return language == "English" ? "Tip: Check if the file exists at the specified path. It may have been moved or deleted." :
                       language == "Russian" ? "Совет: Проверьте, существует ли файл по указанному пути. Возможно, он был перемещён или удалён." :
                       "提示: 检查文件是否在指定路径存在。它可能已被移动或删除。";
            }
            else if (errorMessage.Contains("Invalid Image Format") || errorMessage.Contains("Недопустимый формат изображения") || errorMessage.Contains("无效的图像格式") || errorMessage.Contains("Could not process image"))
            {
                return language == "English" ? "Tip: The image file may be corrupted. Try replacing it with a valid copy." :
                       language == "Russian" ? "Совет: Файл изображения может быть повреждён. Попробуйте заменить его на действующую копию." :
                       "提示: 图像文件可能已损坏。请尝试替换为有效副本。";
            }
            return language == "English" ? "Tip: Unknown error. Check the file or folder manually." :
                   language == "Russian" ? "Совет: Неизвестная ошибка. Проверьте файл или папку вручную." :
                   "提示: 未知错误。请手动检查文件或文件夹。";
        }

        public bool IsErrorLogEmpty()
        {
            return string.IsNullOrEmpty(txtErrorLog.Text);
        }

        public void UpdateLanguage(string language)
        {
            currentLanguage = language;
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