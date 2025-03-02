using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ModStructureCheckerApp
{
    public partial class ExtensionSettingsForm : Form
    {
        private CheckedListBox? textExtensionsList;
        private TextBox? customExtensionInput;
        private Button? addCustomExtensionButton;
        private CheckedListBox? imageExtensionsList;
        private Button? saveButton;
        private Button? cancelButton;
        private string currentLanguage;

        public List<string> SelectedTextExtensions { get; private set; }
        public List<string> SelectedImageExtensions { get; private set; }

        private readonly List<string> availableTextExtensions = new List<string>
        {
            ".xml", ".cs", ".txt", ".json", ".yaml", ".ini", ".cfg", ".csproj", ".sln", ".lua", ".py", ".js", ".h", ".cpp", ".md"
        };
        private readonly List<string> availableImageExtensions = new List<string>
        {
            ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tiff", ".webp"
        };

        public ExtensionSettingsForm(List<string> selectedTextExtensions, List<string> selectedImageExtensions, string language)
        {
            currentLanguage = language;
            SelectedTextExtensions = new List<string>(selectedTextExtensions);
            SelectedImageExtensions = new List<string>(selectedImageExtensions);
            InitializeComponents();
            UpdateLanguage();
            PopulateLists();
        }

        private void InitializeComponents()
        {
            textExtensionsList = new CheckedListBox();
            customExtensionInput = new TextBox();
            addCustomExtensionButton = new Button();
            imageExtensionsList = new CheckedListBox();
            saveButton = new Button();
            cancelButton = new Button();

            SuspendLayout();

            // textExtensionsList
            textExtensionsList.Location = new Point(12, 40);
            textExtensionsList.Size = new Size(200, 200);
            textExtensionsList.CheckOnClick = true;

            // customExtensionInput
            customExtensionInput.Location = new Point(12, 250);
            customExtensionInput.Size = new Size(140, 23);

            // addCustomExtensionButton
            addCustomExtensionButton.Location = new Point(158, 250);
            addCustomExtensionButton.Size = new Size(54, 23);
            addCustomExtensionButton.Click += AddCustomExtensionButton_Click;

            // imageExtensionsList
            imageExtensionsList.Location = new Point(230, 40);
            imageExtensionsList.Size = new Size(200, 200);
            imageExtensionsList.CheckOnClick = true;

            // saveButton
            saveButton.Location = new Point(230, 280);
            saveButton.Size = new Size(100, 30);
            saveButton.Click += SaveButton_Click;

            // cancelButton
            cancelButton.Location = new Point(340, 280);
            cancelButton.Size = new Size(100, 30);
            cancelButton.Click += CancelButton_Click;

            // Form
            ClientSize = new Size(450, 320);
            Controls.Add(new Label { Text = "Text Files:", Location = new Point(12, 20), AutoSize = true });
            Controls.Add(textExtensionsList);
            Controls.Add(customExtensionInput);
            Controls.Add(addCustomExtensionButton);
            Controls.Add(new Label { Text = "Image Files:", Location = new Point(230, 20), AutoSize = true });
            Controls.Add(imageExtensionsList);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Extension Settings";

            ResumeLayout(false);
            PerformLayout();
        }

        private void UpdateLanguage()
        {
            if (currentLanguage == "English")
            {
                Text = "Extension Settings";
                Controls[0].Text = "Text Files:";
                Controls[4].Text = "Image Files:";
                addCustomExtensionButton!.Text = "Add";
                saveButton!.Text = "Save";
                cancelButton!.Text = "Cancel";
            }
            else if (currentLanguage == "Russian")
            {
                Text = "Настройки расширений";
                Controls[0].Text = "Текстовые файлы:";
                Controls[4].Text = "Файлы изображений:";
                addCustomExtensionButton!.Text = "Добавить";
                saveButton!.Text = "Сохранить";
                cancelButton!.Text = "Отмена";
            }
            else // Chinese
            {
                Text = "扩展设置";
                Controls[0].Text = "文本文件:";
                Controls[4].Text = "图像文件:";
                addCustomExtensionButton!.Text = "添加";
                saveButton!.Text = "保存";
                cancelButton!.Text = "取消";
            }
        }

        private void PopulateLists()
        {
            foreach (var ext in availableTextExtensions)
            {
                textExtensionsList!.Items.Add(ext, SelectedTextExtensions.Contains(ext));
            }
            foreach (var ext in SelectedTextExtensions)
            {
                if (!availableTextExtensions.Contains(ext) && !textExtensionsList!.Items.Contains(ext))
                    textExtensionsList.Items.Add(ext, true);
            }

            foreach (var ext in availableImageExtensions)
            {
                imageExtensionsList!.Items.Add(ext, SelectedImageExtensions.Contains(ext));
            }
        }

        private void AddCustomExtensionButton_Click(object? sender, EventArgs e)
        {
            string input = customExtensionInput!.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(input) && !input.StartsWith("."))
                input = "." + input;
            if (!string.IsNullOrEmpty(input) && !textExtensionsList!.Items.Contains(input))
            {
                textExtensionsList.Items.Add(input, true);
                customExtensionInput.Clear();
            }
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            SelectedTextExtensions.Clear();
            foreach (object? item in textExtensionsList!.CheckedItems)
            {
                if (item != null)
                    SelectedTextExtensions.Add(item.ToString()!);
            }

            SelectedImageExtensions.Clear();
            foreach (object? item in imageExtensionsList!.CheckedItems)
            {
                if (item != null)
                    SelectedImageExtensions.Add(item.ToString()!);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}