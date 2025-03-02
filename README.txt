# Mod Structure Checker

![Mod Structure Checker Icon](https://github.com/ArockMSK/ModStructureCheckerApp/blob/main/ModStructureCheckerApp.ico?raw=true)

## English
### Description
Welcome to **Mod Structure Checker** — a powerful Windows Forms application designed to streamline mod development for **RimWorld** by enhancing collaboration with neural networks, such as the AI assistant **Grok**. Developed in C#, this tool enables you to scan mod folders, collect detailed data on directory structures, text files, and images, and generate a comprehensive report saved as `ModFullData.txt`. It’s an invaluable asset for RimWorld modders, simplifying the process of working with AI to troubleshoot and create mods.

#### My Journey with Grok
While developing a mod with the **Grok** neural network, I faced a challenge: Grok needed access to all generated files to accurately identify and fix errors. However, it often struggled with the mod’s structure, prompting me to repeatedly use the `tree /f` command for assistance. Additionally, Grok asked about image formats, locations, and sizes. I realized that providing a full report to the AI, especially for small projects or early stages, was the most efficient approach. This insight led to the creation of **Mod Structure Checker**, tailored to optimize RimWorld modding with AI support.

### Key Features
- **Folder Selection**: Choose a folder with RimWorld mods and a save location for results.
- **Recursive Directory Display**: View the mod structure in a tree format.
- **Customizable File Extensions**: Configure text and image extensions via the "Extension Settings" menu (e.g., `.xml`, `.cs`, `.txt`, `.json`, `.csproj`, `.png`, `.jpg`, `.tiff`, etc.), with support for user-defined text extensions.
- **Text File Analysis**: Extract and display contents of text files.
- **Image Metadata Collection**: Retrieve dimensions and file sizes for supported image formats.
- **Error Handling**: Log errors with timestamps in a reusable `ErrorStatusForm` window and save detailed multilingual tips to `ScanErrors.txt`.
- **Root Directory Scanning**: Include files from the root of the selected folder in the report.
- **Unicode (UTF-8) Support**: Ensure proper handling of files in different languages.
- **Dynamic Versioning**: Automatically generate build numbers using assembly metadata.

### Usage
1. Download the binaries from the [Releases](#releases) section.
2. Extract and run `ModStructureCheckerApp.exe`.
3. Select the mod folder and (optionally) the save location.
4. Click **"Run Analysis"** and wait for completion.
5. Find the results in `ModFullData.txt` in the specified directory.
6. Share the report with a neural network (e.g., Grok) to assist with error correction and RimWorld mod development.

### System Requirements
- **Operating System:** Windows 7, 8, 10, or 11 (32-bit or 64-bit).
- **.NET 8.0 Runtime:**
  - Required to run the application (not pre-installed on all systems).
  - For 32-bit (x86): [Download](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime-8.0.0-win-x86)
  - For 64-bit (x64): [Download](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime-8.0.0-win-x64)
  - **Installation:** Run the installer and follow the instructions.
  - **Note:** Check your system type via Right-click "This PC" → "Properties".
- **Disk Space:** Approximately 303 KB for the application, plus additional space for generated reports.
- **No additional software required.**

---

## Русский
### Описание
Добро пожаловать в **Mod Structure Checker** — мощное приложение с интерфейсом на Windows Forms, созданное на C# для упрощения разработки модов для **RimWorld** с использованием нейросетей, таких как ИИ-ассистент **Grok**. Этот инструмент позволяет сканировать папки с модами, собирать данные о структуре директорий, текстовых файлах и изображениях, а затем сохранять их в файл `ModFullData.txt`. Он особенно полезен для моддеров RimWorld, помогая работать с ИИ для устранения ошибок и создания модов.

#### Мой опыт с Grok
Создавая мод с помощью нейросети **Grok**, я столкнулся с проблемой: ей нужны были все файлы мода для точного исправления ошибок. Однако Grok путалась в структуре, и мне приходилось часто использовать команду `tree /f`. Также она задавала вопросы о форматах, расположении и размере изображений. В итоге я понял, что предоставление полного отчёта ИИ, особенно на ранних этапах, — лучший подход. Так появился **Mod Structure Checker**, оптимизированный для работы с RimWorld и нейросетями.

### Основные возможности
- **Выбор папки**: Укажите папку с модами RimWorld и место для сохранения результатов.
- **Рекурсивное отображение структуры**: Просмотр структуры модов в виде дерева.
- **Настраиваемые расширения файлов**: Настройка расширений через меню "Настройки расширений" (например, `.xml`, `.cs`, `.txt`, `.json`, `.csproj`, `.png`, `.jpg`, `.tiff` и др.) с поддержкой пользовательских текстовых расширений.
- **Анализ текстовых файлов**: Извлечение и вывод содержимого текстовых файлов.
- **Сбор метаданных изображений**: Получение размеров и объёма файлов изображений.
- **Обработка ошибок**: Логирование ошибок с временными метками в переиспользуемом окне `ErrorStatusForm` и сохранение советов на трёх языках в `ScanErrors.txt`.
- **Сканирование корневой директории**: Включение файлов из корня выбранной папки в отчёт.
- **Поддержка Unicode (UTF-8)**: Корректная работа с файлами на разных языках.
- **Динамическая версия**: Автоматическое обновление номера сборки из метаданных.

### Использование
1. Скачайте бинарники из раздела [Releases](#releases).
2. Распакуйте и запустите `ModStructureCheckerApp.exe`.
3. Выберите папку с модами и (при необходимости) место сохранения.
4. Нажмите **"Запустить сборку"** и дождитесь завершения.
5. Результаты будут в `ModFullData.txt` в указанной папке.
6. Передайте отчёт нейросети (например, Grok) для помощи в разработке модов RimWorld.

### Требования к системе
- **Операционная система:** Windows 7, 8, 10 или 11 (32-бит или 64-бит).
- **.NET 8.0 Runtime:**
  - Требуется для работы (может отсутствовать на системе).
  - Для 32-бит (x86): [Скачать](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime-8.0.0-win-x86)
  - Для 64-бит (x64): [Скачать](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime-8.0.0-win-x64)
  - **Установка:** Запустите установщик и следуйте инструкциям.
  - **Примечание:** Тип системы — правый клик по "Этот компьютер" → "Свойства".
- **Место на диске:** Примерно 303 КБ для приложения + место для отчётов.
- **Дополнительное ПО не требуется.**

---

## 中文 (简体)
### 描述
欢迎体验 **Mod Structure Checker** — 一款功能强大的 Windows Forms 应用程序，专为 **RimWorld** 模组开发设计，通过与神经网络（如 AI 助手 **Grok**）协作简化开发流程。这款用 C# 开发的工具可扫描模组文件夹，收集目录结构、文本文件和图像的详细信息，并生成完整的报告文件 `ModFullData.txt`。它对 RimWorld 模组开发者尤为有用，帮助解决与 AI 合作时的难题。

#### 我的 Grok 之旅
在使用 **Grok** 神经网络编写模组时，我遇到了一个难题：Grok 需要所有生成的文件来准确识别和修复错误。然而，它经常对模组结构感到困惑，我不得不多次使用 `tree /f` 命令协助。此外，Grok 偶尔会询问图像格式、位置和大小。我意识到，尤其在小型项目或初期，向 AI 提供完整报告是最有效的方法。这启发了我开发 **Mod Structure Checker**，专为 RimWorld 的 AI 模组开发优化。

### 主要功能
- **文件夹选择**: 选择 RimWorld 模组文件夹和结果保存路径。
- **递归目录显示**: 以树形视图展示模组结构。
- **可自定义文件扩展名**: 通过“扩展设置”菜单配置文本和图像扩展名（例如 `.xml`, `.cs`, `.txt`, `.json`, `.csproj`, `.png`, `.jpg`, `.tiff` 等），支持自定义文本扩展。
- **文本文件分析**: 提取并显示文本文件内容。
- **图像元数据收集**: 获取支持图像格式的尺寸和文件大小。
- **错误处理**: 在可复用的 `ErrorStatusForm` 窗口中记录带时间戳的错误，并在 `ScanErrors.txt` 中保存三语建议。
- **根目录扫描**: 将所选文件夹根目录中的文件包含在报告中。
- **Unicode (UTF-8) 支持**: 确保正确处理多语言文件。
- **动态版本**: 从程序集元数据自动生成构建号。

### 使用方法
1. 从 [Releases](#releases) 下载二进制文件。
2. 解压并运行 `ModStructureCheckerApp.exe`。
3. 选择模组文件夹和（可选）保存路径。
4. 点击 **“运行分析”** 并等待完成。
5. 结果将保存为指定目录中的 `ModFullData.txt`。
6. 将报告分享给神经网络（如 Grok），以协助 RimWorld 模组开发和错误修复。

### 系统要求
- **操作系统**: Windows 7、8、10 或 11（32 位或 64 位）。
- **.NET 8.0 Runtime**:
  - 运行所需（某些系统可能未预装）。
  - 32 位 (x86): [下载](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime-8.0.0-win-x86)
  - 64 位 (x64): [下载](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime-8.0.0-win-x64)
  - **安装**: 运行安装程序并按提示操作。
  - **注意**: 检查系统类型：右键“此电脑” → “属性”。
- **磁盘空间**: 应用程序约 303 KB，外加报告所需空间。
- **无需额外软件**。

---

## Release Notes

### v1.1.0 - March 2, 2025
#### English
- **✨ New Features**  
  - Added "Extension Settings" menu to customize file extensions for scanning (text files and images). Supports custom text extensions (e.g., `.xs`) and expanded default list (`.json`, `.yaml`, `.csproj`, `.sln`, `.lua`, `.tiff`, `.webp`, etc.).  
  - Root Directory Scanning: Files in the root of the selected folder are now included in the report under "Root Directory".  
  - Automatic Versioning: Implemented build number generation (`Build` and `Revision`) using wildcards in `.csproj`. UI version (`labelAuthor`) is now dynamic from assembly metadata.  
- **🐛 Improvements & Fixes**  
  - Enhanced Error Handling: Errors are displayed in a reusable `ErrorStatusForm` window. Removed redundant error messages per extension for inaccessible folders. Added multilingual tips in `ScanErrors.txt`.  
  - Report Optimization: `ModFullData.txt` now fully reports folder structure, text file contents, and image metadata despite partial access errors.  
- **⚙️ Technical Changes**  
  - Disabled build determinism to support wildcard versioning.

#### Russian
- **✨ Новые функции**  
  - Добавлено меню "Настройки расширений" для выбора расширений файлов (текст и изображения). Поддержка пользовательских текстовых расширений (например, `.xs`) и расширенный список (`.json`, `.yaml`, `.csproj`, `.sln`, `.lua`, `.tiff`, `.webp` и др.).  
  - Сканирование корневой директории: Файлы в корне выбранной папки теперь в отчёте под "Корневая директория".  
  - Автоматическая версия: Настроена генерация номера сборки (`Build` и `Revision`) с использованием `*` в `.csproj`. Версия в интерфейсе (`labelAuthor`) динамически берётся из метаданных.  
- **🐛 Улучшения и исправления**  
  - Улучшена обработка ошибок: Ошибки отображаются в переиспользуемом окне `ErrorStatusForm`. Убраны лишние сообщения об ошибках для каждого расширения при недоступности папки. Добавлены советы на трёх языках в `ScanErrors.txt`.  
  - Оптимизация отчёта: `ModFullData.txt` теперь включает полную структуру, содержимое текстовых файлов и метаданные изображений даже при частичных ошибках доступа.  
- **⚙️ Технические изменения**  
  - Отключён детерминизм сборки для поддержки подстановочных знаков.

#### Chinese (Simplified)
- **✨ 新功能**  
  - 添加“扩展设置”菜单自定义扫描文件扩展名（文本和图像）。支持自定义文本扩展名（例：`.xs`），扩展默认列表（`.json`、`.yaml`、`.csproj`、`.sln`、`.lua`、`.tiff`、`.webp` 等）。  
  - 根目录扫描：所选文件夹根目录中的文件现在包含在报告的“根目录”部分。  
  - 自动版本控制：在 `.csproj` 中使用通配符（`*`）生成构建号（`Build` 和 `Revision`）。界面版本（`labelAuthor`）从元数据动态获取。  
- **🐛 改进与修复**  
  - 改进错误处理：错误在复用 `ErrorStatusForm` 窗口显示。移除不可访问文件夹时每个扩展名的冗余错误消息。在 `ScanErrors.txt` 中添加三语建议。  
  - 报告优化：`ModFullData.txt` 即使部分访问出错也能完整报告结构、文本内容和图像元数据。  
- **⚙️ 技术变更**  
  - 禁用构建确定性以支持通配符版本控制。

---

## Releases
- The application is provided as a standalone executable:
  - [ModStructureCheckerApp.exe (x64)](https://github.com/ArockMSK/ModStructureCheckerApp/releases/download/v1.1.0/ModStructureCheckerApp.exe)  
    *(Coming soon with v1.1.0 release)*  
- Download the appropriate version for your system and ensure .NET 8.0 Runtime is installed.

## Author
Developed by Arock with assistance from Grok (xAI).