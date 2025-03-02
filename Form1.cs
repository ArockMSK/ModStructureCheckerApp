using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;

namespace ModStructureCheckerApp
{
    public partial class Form1 : Form
    {
        private string selectedFolder = "";
        private string saveFolder = "";
        private ErrorStatusForm? errorForm = null;
        private string currentLanguage;
        private List<string> selectedTextExtensions = new List<string> { ".xml", ".cs", ".txt" };
        private List<string> selectedImageExtensions = new List<string> { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };

        public Form1()
        {
            string systemLanguage = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToLower();
            if (systemLanguage == "ru")
                currentLanguage = "Russian";
            else if (systemLanguage == "zh")
                currentLanguage = "Chinese";
            else
                currentLanguage = "English";

            InitializeComponent();
            try
            {
                this.Icon = new Icon("ModStructureCheckerApp.ico");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки иконки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtStatus.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point);
            UpdateLanguage();
        }

        private void UpdateLanguage()
        {
            // Получаем версию из метаданных сборки (только Major.Minor.Build)
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.1.0";

            if (currentLanguage == "English")
            {
                Text = "Mod Structure Checker";
                btnSelectFolder.Text = "Select Folder 📁";
                btnRun.Text = "Run Analysis ▶️";
                btnSaveFolder.Text = "Select Save Folder 📂";
                label1.Text = "Status: 📋";
                label2.Text = "Save Folder: 🗂️";
                labelAuthor.Text = $"v{version} by Arock (Built with Grok from xAI)"; // Динамическая версия
                extensionsSettingsMenu.Text = "Extension Settings";
            }
            else if (currentLanguage == "Russian")
            {
                Text = "ModStructureCheckerApp";
                btnSelectFolder.Text = "Выбрать папку 📁";
                btnRun.Text = "Запустить сборку ▶️";
                btnSaveFolder.Text = "Выбрать папку сохранения 📂";
                label1.Text = "Статус: 📋";
                label2.Text = "Папка для сохранения: 🗂️";
                labelAuthor.Text = $"v{version} от Arock (Создано с Grok от xAI)"; // Динамическая версия
                extensionsSettingsMenu.Text = "Настройки расширений";
            }
            else // Chinese
            {
                Text = "模组结构检查器";
                btnSelectFolder.Text = "选择文件夹 📁";
                btnRun.Text = "运行分析 ▶️";
                btnSaveFolder.Text = "选择保存文件夹 📂";
                label1.Text = "状态: 📋";
                label2.Text = "保存文件夹: 🗂️";
                labelAuthor.Text = $"v{version} by Arock (由xAI的Grok构建)"; // Динамическая версия
                extensionsSettingsMenu.Text = "扩展设置";
            }
        }

        private void PrintTree(string path, string indent, bool isLast, StreamWriter writer)
        {
            string dirName = Path.GetFileName(path);
            writer.WriteLine(indent + (isLast ? "└─ " : "├─ ") + dirName);
            string newIndent = indent + (isLast ? "   " : "│  ");

            string[] subDirs = Array.Empty<string>();
            string[] files = Array.Empty<string>();

            try
            {
                subDirs = Directory.GetDirectories(path);
            }
            catch (Exception ex)
            {
                writer.WriteLine(newIndent + "[ERROR] " + ex.Message);
                if (errorForm != null && !errorForm.IsDisposed)
                    errorForm.AddError(currentLanguage == "English" ? $"Error processing directory {path}: {TranslateException(ex.Message, currentLanguage)}" :
                                      currentLanguage == "Russian" ? $"Ошибка при обработке директории {path}: {TranslateException(ex.Message, currentLanguage)}" :
                                      $"处理目录 {path} 时出错: {TranslateException(ex.Message, currentLanguage)}");
            }

            for (int i = 0; i < subDirs.Length; i++)
            {
                PrintTree(subDirs[i], newIndent, i == subDirs.Length - 1, writer);
            }

            try
            {
                files = Directory.GetFiles(path);
            }
            catch (Exception ex)
            {
                writer.WriteLine(newIndent + "[ERROR] " + ex.Message);
                if (errorForm != null && !errorForm.IsDisposed)
                    errorForm.AddError(currentLanguage == "English" ? $"Error processing files in {path}: {TranslateException(ex.Message, currentLanguage)}" :
                                      currentLanguage == "Russian" ? $"Ошибка при обработке файлов в {path}: {TranslateException(ex.Message, currentLanguage)}" :
                                      $"处理 {path} 中的文件时出错: {TranslateException(ex.Message, currentLanguage)}");
            }

            for (int i = 0; i < files.Length; i++)
            {
                string fileName = Path.GetFileName(files[i]);
                writer.WriteLine(newIndent + (i == files.Length - 1 ? "└─ " : "├─ ") + fileName);
            }
        }

        private void btnSelectFolder_Click(object? sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = currentLanguage == "English" ? "Select mods folder" :
                                          currentLanguage == "Russian" ? "Выберите папку с модами" :
                                          "选择模组文件夹";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolder = folderDialog.SelectedPath;
                    txtStatus.Text = currentLanguage == "English" ? $"Selected mods folder: {selectedFolder} 📁\r\n" :
                                    currentLanguage == "Russian" ? $"Выбрана папка с модами: {selectedFolder} 📁\r\n" :
                                    $"已选择模组文件夹: {selectedFolder} 📁\r\n";
                    saveFolder = selectedFolder;
                    txtSavePath.Text = saveFolder;
                }
            }
        }

        private void btnSaveFolder_Click(object? sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = currentLanguage == "English" ? "Select save location" :
                                          currentLanguage == "Russian" ? "Выберите папку для сохранения результата" :
                                          "选择保存位置";
                folderDialog.ShowNewFolderButton = true;
                folderDialog.SelectedPath = saveFolder;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    saveFolder = folderDialog.SelectedPath;
                    txtSavePath.Text = saveFolder;
                    txtStatus.Text += currentLanguage == "English" ? $"Save folder changed to: {saveFolder} 🗂️\r\n" :
                                     currentLanguage == "Russian" ? $"Папка сохранения изменена на: {saveFolder} 🗂️\r\n" :
                                     $"保存文件夹更改为: {saveFolder} 🗂️\r\n";
                }
            }
        }

        private void btnRun_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFolder))
            {
                MessageBox.Show(
                    currentLanguage == "English" ? "Please select a mods folder!" :
                    currentLanguage == "Russian" ? "Пожалуйста, выберите папку с модами!" :
                    "请先选择模组文件夹！",
                    currentLanguage == "English" ? "Error" :
                    currentLanguage == "Russian" ? "Ошибка" :
                    "错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(saveFolder))
            {
                saveFolder = selectedFolder;
                txtSavePath.Text = saveFolder;
            }

            string outputFile = Path.Combine(saveFolder, "ModFullData.txt");
            string errorFile = Path.Combine(saveFolder, "ScanErrors.txt");

            if (errorForm == null || errorForm.IsDisposed)
            {
                errorForm = new ErrorStatusForm(saveFolder, currentLanguage);
                errorForm.UpdateLanguage(currentLanguage);
                errorForm.Show(this);
            }

            txtStatus.Text = currentLanguage == "English" ? "Analysis started... ⏳\r\n" :
                            currentLanguage == "Russian" ? "Сборка началась... ⏳\r\n" :
                            "分析开始... ⏳\r\n";
            if (File.Exists(errorFile)) File.Delete(errorFile);

            using (StreamWriter writer = new StreamWriter(outputFile, false, Encoding.UTF8))
            {
                writer.WriteLine(currentLanguage == "English" ? $"Full mod data analysis started: {DateTime.Now}" :
                                currentLanguage == "Russian" ? $"Полная сборка данных модов начата: {DateTime.Now}" :
                                $"模组数据完整分析开始: {DateTime.Now}");
                writer.WriteLine();

                // Анализ корневой директории
                writer.WriteLine(currentLanguage == "English" ? "Root Directory:" :
                                currentLanguage == "Russian" ? "Корневая директория:" :
                                "根目录:");
                ProcessFilesInDirectory(selectedFolder, writer, true);
                writer.WriteLine();

                string[] modFolders = Directory.GetDirectories(selectedFolder);
                foreach (var modPath in modFolders)
                {
                    try
                    {
                        string modName = Path.GetFileName(modPath);
                        writer.WriteLine(currentLanguage == "English" ? $"Mod: {modName}" :
                                        currentLanguage == "Russian" ? $"Мод: {modName}" :
                                        $"模组: {modName}");
                        writer.WriteLine(new string('-', 50));

                        writer.WriteLine(currentLanguage == "English" ? "Directory Structure:" :
                                        currentLanguage == "Russian" ? "Структура директорий:" :
                                        "目录结构:");
                        PrintTree(modPath, "", true, writer);
                        writer.WriteLine();

                        ProcessFilesInDirectory(modPath, writer, false);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine(currentLanguage == "English" ? $"[ERROR] Failed to process mod {modPath}: {ex.Message}" :
                                        currentLanguage == "Russian" ? $"[ОШИБКА] Не удалось обработать мод {modPath}: {ex.Message}" :
                                        $"[错误] 无法处理模组 {modPath}: {ex.Message}");
                        if (errorForm != null && !errorForm.IsDisposed)
                            errorForm.AddError(currentLanguage == "English" ? $"General analysis error for mod {modPath}: {TranslateException(ex.Message, currentLanguage)}" :
                                              currentLanguage == "Russian" ? $"Общая ошибка сборки для мода {modPath}: {TranslateException(ex.Message, currentLanguage)}" :
                                              $"模组 {modPath} 的总体分析错误: {TranslateException(ex.Message, currentLanguage)}");
                    }
                }

                writer.WriteLine(currentLanguage == "English" ? "Analysis completed. ✅" :
                                currentLanguage == "Russian" ? "Сборка завершена. ✅" :
                                "分析完成。 ✅");
            }

            txtStatus.Text += currentLanguage == "English" ? $"Analysis completed. File saved: {outputFile} 📄\r\n" :
                             currentLanguage == "Russian" ? $"Сборка завершена. Файл сохранен: {outputFile} 📄\r\n" :
                             $"分析完成。文件已保存: {outputFile} 📄\r\n";
            if (File.Exists(errorFile) && new FileInfo(errorFile).Length > 0)
                txtStatus.Text += currentLanguage == "English" ? $"Errors logged: {errorFile} ⚠️\r\n" :
                                 currentLanguage == "Russian" ? $"Ошибки записаны: {errorFile} ⚠️\r\n" :
                                 $"错误已记录: {errorFile} ⚠️\r\n";
            if (errorForm != null && !errorForm.IsDisposed)
                errorForm.CompleteScan();
            if (errorForm != null && !errorForm.IsDisposed && errorForm.IsErrorLogEmpty())
            {
                errorForm.Close();
            }
        }

        private void ProcessFilesInDirectory(string directory, StreamWriter writer, bool isRoot)
        {
            writer.WriteLine(currentLanguage == "English" ? "Text Files:" :
                            currentLanguage == "Russian" ? "Текстовые файлы:" :
                            "文本文件:");
            try
            {
                string[] allFiles = isRoot ? Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly) : Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
                foreach (var file in allFiles)
                {
                    string ext = Path.GetExtension(file).ToLower();
                    if (selectedTextExtensions.Contains(ext))
                    {
                        writer.WriteLine(currentLanguage == "English" ? $"File: {file}" :
                                        currentLanguage == "Russian" ? $"Файл: {file}" :
                                        $"文件: {file}");
                        writer.WriteLine(currentLanguage == "English" ? $"Type: {ext.TrimStart('.')}" :
                                        currentLanguage == "Russian" ? $"Тип: {ext.TrimStart('.')}" :
                                        $"类型: {ext.TrimStart('.')}");
                        writer.WriteLine(currentLanguage == "English" ? "Content:" :
                                        currentLanguage == "Russian" ? "Содержимое:" :
                                        "内容:");
                        try
                        {
                            string content = File.ReadAllText(file, Encoding.UTF8);
                            writer.WriteLine(content);
                        }
                        catch (Exception ex)
                        {
                            writer.WriteLine(currentLanguage == "English" ? $"[ERROR] Could not read file: {ex.Message}" :
                                            currentLanguage == "Russian" ? $"[ОШИБКА] Не удалось прочитать файл: {ex.Message}" :
                                            $"[错误] 无法读取文件: {ex.Message}");
                            if (errorForm != null && !errorForm.IsDisposed)
                                errorForm.AddError(currentLanguage == "English" ? $"Error reading file {file}: {TranslateException(ex.Message, currentLanguage)}" :
                                                  currentLanguage == "Russian" ? $"Ошибка при чтении файла {file}: {TranslateException(ex.Message, currentLanguage)}" :
                                                  $"读取文件 {file} 时出错: {TranslateException(ex.Message, currentLanguage)}");
                        }
                        writer.WriteLine(new string('-', 50));
                    }
                }
            }
            catch (Exception ex)
            {
                writer.WriteLine(currentLanguage == "English" ? $"[ERROR] Could not scan text files: {ex.Message}" :
                                currentLanguage == "Russian" ? $"[ОШИБКА] Не удалось просканировать текстовые файлы: {ex.Message}" :
                                $"[错误] 无法扫描文本文件: {ex.Message}");
                if (errorForm != null && !errorForm.IsDisposed)
                    errorForm.AddError(currentLanguage == "English" ? $"Error scanning text files in {directory}: {TranslateException(ex.Message, currentLanguage)}" :
                                      currentLanguage == "Russian" ? $"Ошибка при сканировании текстовых файлов в {directory}: {TranslateException(ex.Message, currentLanguage)}" :
                                      $"扫描 {directory} 中的文本文件时出错: {TranslateException(ex.Message, currentLanguage)}");
            }
            writer.WriteLine();

            writer.WriteLine(currentLanguage == "English" ? "Image Files:" :
                            currentLanguage == "Russian" ? "Изображения:" :
                            "图像文件:");
            try
            {
                string[] allFiles = isRoot ? Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly) : Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
                foreach (var file in allFiles)
                {
                    string ext = Path.GetExtension(file).ToLower();
                    if (selectedImageExtensions.Contains(ext))
                    {
                        writer.WriteLine(currentLanguage == "English" ? $"File: {file}" :
                                        currentLanguage == "Russian" ? $"Файл: {file}" :
                                        $"文件: {file}");
                        writer.WriteLine(currentLanguage == "English" ? $"Type: {ext.TrimStart('.')}" :
                                        currentLanguage == "Russian" ? $"Тип: {ext.TrimStart('.')}" :
                                        $"类型: {ext.TrimStart('.')}");
                        try
                        {
                            using (Bitmap bitmap = new Bitmap(file))
                            {
                                int width = bitmap.Width;
                                int height = bitmap.Height;
                                long fileSize = new FileInfo(file).Length;
                                writer.WriteLine(currentLanguage == "English" ? $"Dimensions: {width}x{height} pixels" :
                                                currentLanguage == "Russian" ? $"Размеры: {width}x{height} пикселей" :
                                                $"尺寸: {width}x{height} 像素");
                                writer.WriteLine(currentLanguage == "English" ? $"File Size: {fileSize} bytes" :
                                                currentLanguage == "Russian" ? $"Размер файла: {fileSize} байт" :
                                                $"文件大小: {fileSize} 字节");
                            }
                        }
                        catch (Exception ex)
                        {
                            writer.WriteLine(currentLanguage == "English" ? $"[ERROR] Could not process image: {ex.Message}" :
                                            currentLanguage == "Russian" ? $"[ОШИБКА] Не удалось обработать изображение: {ex.Message}" :
                                            $"[错误] 无法处理图像: {ex.Message}");
                            if (errorForm != null && !errorForm.IsDisposed)
                                errorForm.AddError(currentLanguage == "English" ? $"Error processing image {file}: {TranslateException(ex.Message, currentLanguage)}" :
                                                  currentLanguage == "Russian" ? $"Ошибка при обработке изображения {file}: {TranslateException(ex.Message, currentLanguage)}" :
                                                  $"处理图像 {file} 时出错: {TranslateException(ex.Message, currentLanguage)}");
                        }
                        writer.WriteLine(new string('-', 50));
                    }
                }
            }
            catch (Exception ex)
            {
                writer.WriteLine(currentLanguage == "English" ? $"[ERROR] Could not scan image files: {ex.Message}" :
                                currentLanguage == "Russian" ? $"[ОШИБКА] Не удалось просканировать изображения: {ex.Message}" :
                                $"[错误] 无法扫描图像文件: {ex.Message}");
                if (errorForm != null && !errorForm.IsDisposed)
                    errorForm.AddError(currentLanguage == "English" ? $"Error scanning image files in {directory}: {TranslateException(ex.Message, currentLanguage)}" :
                                      currentLanguage == "Russian" ? $"Ошибка при сканировании изображений в {directory}: {TranslateException(ex.Message, currentLanguage)}" :
                                      $"扫描 {directory} 中的图像文件时出错: {TranslateException(ex.Message, currentLanguage)}");
            }
        }

        private string TranslateException(string message, string language)
        {
            if (message.Contains("Access to the path") && message.Contains("is denied"))
            {
                return language == "English" ? "Access to the path is denied" :
                       language == "Russian" ? "Доступ к пути запрещён" :
                       "路径访问被拒绝";
            }
            else if (message.Contains("File Not Found"))
            {
                return language == "English" ? "File not found" :
                       language == "Russian" ? "Файл не найден" :
                       "文件未找到";
            }
            else if (message.Contains("Invalid Image Format"))
            {
                return language == "English" ? "Invalid image format" :
                       language == "Russian" ? "Недопустимый формат изображения" :
                       "无效的图像格式";
            }
            return message;
        }

        private void LogError(string errorMessage)
        {
            try
            {
                string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");
                File.AppendAllText(logPath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {errorMessage}\r\n");
            }
            catch (Exception)
            {
            }
        }

        private void languageEnglish_Click(object? sender, EventArgs e)
        {
            currentLanguage = "English";
            UpdateLanguage();
            if (errorForm != null && !errorForm.IsDisposed)
                errorForm.UpdateLanguage(currentLanguage);
        }

        private void languageRussian_Click(object? sender, EventArgs e)
        {
            currentLanguage = "Russian";
            UpdateLanguage();
            if (errorForm != null && !errorForm.IsDisposed)
                errorForm.UpdateLanguage(currentLanguage);
        }

        private void languageChinese_Click(object? sender, EventArgs e)
        {
            currentLanguage = "Chinese";
            UpdateLanguage();
            if (errorForm != null && !errorForm.IsDisposed)
                errorForm.UpdateLanguage(currentLanguage);
        }

        private void extensionsSettings_Click(object? sender, EventArgs e)
        {
            using (var settingsForm = new ExtensionSettingsForm(selectedTextExtensions, selectedImageExtensions, currentLanguage))
            {
                if (settingsForm.ShowDialog(this) == DialogResult.OK)
                {
                    selectedTextExtensions = settingsForm.SelectedTextExtensions;
                    selectedImageExtensions = settingsForm.SelectedImageExtensions;
                }
            }
        }
    }
}