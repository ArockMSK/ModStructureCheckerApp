# Mod Structure Checker

![Mod Structure Checker Icon](https://github.com/ArockMSK/ModStructureCheckerApp/blob/main/ModStructureCheckerApp.ico?raw=true)

## English
### Description
Welcome to the release of **Mod Structure Checker** — a powerful Windows Forms application designed to streamline mod development for **RimWorld** by facilitating collaboration with neural networks, such as the AI assistant **Grok**. This tool, developed in C#, allows you to quickly scan mod folders, collect detailed data on directory structures, text files, and images, and save the results to a comprehensive text file (`ModFullData.txt`). It is especially useful for modders working with RimWorld, helping to overcome challenges when using AI for mod creation.

#### My Journey with Grok
When I started writing a mod using the **Grok** neural network, I encountered a significant challenge: Grok required me to provide all generated files to correctly identify and fix errors. However, the AI often struggled with the mod's structure, leading me to frequently use the `tree /f` command to assist it. Additionally, Grok occasionally asked questions about image formats, locations, and sizes. Ultimately, I realized that for small projects—especially at the start—providing a full report to the neural network is the most efficient approach. This inspired the creation of **Mod Structure Checker**, tailored to enhance the modding process for RimWorld using AI.

### Key Features
- **Select a folder** with RimWorld mods and a save location for results.
- **Recursive directory display** in a tree view.
- **Analysis of text files** (`.xml`, `.cs`, `.txt`) with content output.
- **Collection of image metadata** (`.png`, `.jpg`, `.jpeg`, `.gif`, `.bmp`) — dimensions and file size.
- **Error logging** in a separate window with timestamps.
- **Unicode (UTF-8) support** for correct handling of files in different languages.

### Usage
1. Download the binaries from the [Releases](#releases) section.
2. Extract and run `ModStructureCheckerApp.exe`.
3. Select the mod folder and (if needed) the save location.
4. Click **"Run Analysis"** and wait for the process to complete.
5. Results will be saved to `ModFullData.txt` in the specified directory.
6. Share the report with a neural network (e.g., Grok) to assist with error correction and mod development for RimWorld.

### System Requirements
- **Operating System:** Windows 7, 8, 10, or 11 (32-bit or 64-bit).
- **.NET 8.0 Runtime:**
  - Required to run the application. Not pre-installed on all systems.
  - For 32-bit (x86) systems: [Download](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime-8.0.0-win-x86)
  - For 64-bit (x64) systems: [Download](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime-8.0.0-win-x64)
  - **Installation:** Run the downloaded installer and follow the on-screen instructions.
  - **Note:** Check your system type via right-click 'This PC' → 'Properties'.
- **Disk Space:** Approximately 5-10 MB for the application, plus additional space for generated reports.
- **No additional software required.**

## Русский
### Описание
Добро пожаловать в релиз **Mod Structure Checker** — мощного приложения с графическим интерфейсом на Windows Forms, разработанного на C# для упрощения создания модов для **RimWorld** с использованием нейросетей, таких как ИИ-ассистент **Grok**. Этот инструмент позволяет быстро сканировать папки с модами, собирать подробные данные о структуре директорий, текстовых файлах и изображениях, а затем сохранять результаты в удобный текстовый файл (`ModFullData.txt`). Он особенно полезен для моддеров RimWorld, помогая преодолевать трудности при работе с ИИ.

#### Мой опыт с Grok
Когда я начал писать мод с помощью нейросети **Grok**, я столкнулся с проблемой: ей требовалось видеть все сгенерированные файлы, чтобы правильно исправлять ошибки. Однако Grok часто путалась в структуре мода, и мне приходилось регулярно использовать команду `tree /f`, чтобы помочь. Кроме того, нейросеть периодически задавала вопросы о форматах изображений, их расположении и размере. В итоге я понял, что для небольших проектов, особенно на начальном этапе, предоставление полной отчётности нейросети — самый удобный подход. Так родилась идея **Mod Structure Checker**, адаптированного для работы с RimWorld и ИИ.

### Основные возможности
- **Выбор папки** с модами RimWorld и папки для сохранения результатов.
- **Рекурсивное отображение структуры директорий** в виде дерева.
- **Анализ текстовых файлов** (`.xml`, `.cs`, `.txt`) с выводом их содержимого.
- **Сбор метаданных изображений** (`.png`, `.jpg`, `.jpeg`, `.gif`, `.bmp`) — размеры и размер файла.
- **Логирование ошибок** в отдельном окне с поддержкой временных меток.
- **Поддержка Unicode (UTF-8)** для корректной работы с файлами на разных языках.

### Использование
1. Скачайте бинарники из раздела [Releases](#releases).
2. Распакуйте и запустите `ModStructureCheckerApp.exe`.
3. Выберите папку с модами и (при необходимости) папку для сохранения.
4. Нажмите **"Запустить сборку"** и дождитесь завершения процесса.
5. Результаты будут сохранены в файл `ModFullData.txt` в указанной директории.
6. Передайте отчёт нейросети (например, Grok) для помощи в исправлении ошибок и разработке модов для RimWorld.

### Требования к системе
- **Операционная система:** Windows 7, 8, 10 или 11 (32-бит или 64-бит).
- **.NET 8.0 Runtime:**
  - Требуется для работы приложения. На некоторых системах он может отсутствовать.
  - Для 32-битных (x86) систем: [Скачайте](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime-8.0.0-win-x86)
  - Для 64-битных (x64) систем: [Скачайте](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime-8.0.0-win-x64)
  - **Установка:** Запустите скачанный установщик и следуйте инструкциям на экране.
  - **Примечание:** Проверьте тип системы через правый клик по "Этот компьютер" → "Свойства".
- **Место на диске:** Примерно 5-10 МБ для приложения, плюс дополнительное место для отчётов.
- **Дополнительное ПО не требуется.**

## 中文 (简体)
### 描述
欢迎体验 **Mod Structure Checker** 发布版 — 一款功能强大的 Windows Forms 应用程序，专为 RimWorld 模组开发设计，通过与神经网络（如 AI 助手 **Grok**）的协作简化开发流程。这款基于 C# 开发的工具允许您快速扫描模组文件夹，收集目录结构、文本文件和图像的详细信息，并将结果保存到全面的文本文件（`ModFullData.txt`）。它特别适合 RimWorld 模组开发者，帮助克服使用 AI 创建模组时的挑战。

#### 我的 Grok 之旅
当我开始使用神经网络 **Grok** 编写模组时，我遇到了一个重大挑战：Grok 需要查看所有生成的 文件才能正确识别和修复错误。然而，AI 经常对模组结构感到困惑，我不得不频繁使用 `tree /f` 命令来协助它。此外，Grok 偶尔会询问图像的格式、位置和大小。最终，我意识到，对于小型项目（尤其是在项目开始时），向神经网络提供完整报告是最有效的方法。这启发了我创建 **Mod Structure Checker**，专门用于 RimWorld 和 AI 的模组开发。

### 主要功能
- **选择 RimWorld 模组文件夹**和保存结果的路径。
- **递归显示目录结构**，以树形视图呈现。
- **分析文本文件** (`.xml`, `.cs`, `.txt`) 并输出其内容。
- **收集图像元数据** (`.png`, `.jpg`, `.jpeg`, `.gif`, `.bmp`) — 尺寸和文件大小。
- **在单独窗口中记录错误**，支持时间戳。
- **支持 Unicode (UTF-8)**，确保不同语言文件的正确处理。

### 使用方法
1. 从 [Releases](#releases) 部分下载二进制文件。
2. 解压并运行 `ModStructureCheckerApp.exe`。
3. 选择模组文件夹和（如果需要）保存路径。
4. 单击**“运行分析”**并等待过程完成。
5. 结果将保存到指定目录中的 `ModFullData.txt` 文件。
6. 与神经网络（例如 Grok）分享报告，以帮助修正错误并开发 RimWorld 模组。

### 系统要求
- **操作系统：** Windows 7、8、10 或 11（32 位或 64 位）。
- **.NET 8.0 Runtime：**
  - 运行应用程序所需。某些系统中可能未预装。
  - 对于 32 位 (x86) 系统：从 [下载](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime-8.0.0-win-x86)
  - 对于 64 位 (x64) 系统：从 [下载](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime-8.0.0-win-x64)
  - **安装：** 运行下载的安装程序并按照屏幕上的说明操作。
  - **注意：** 如果不确定系统类型，右键点击“此电脑”→“属性”查看。
- **磁盘空间：** 应用程序约需 5-10 MB，外加生成的报告所需空间。
- **无需额外软件。**

## Releases
- The application is provided as two standalone executables:
  - [ModStructureCheckerApp.exe (x64)](https://github.com/ArockMSK/ModStructureCheckerApp/releases/download/v1.0.0/ModStructureCheckerApp_x64.exe)
  - [ModStructureCheckerApp.exe (x86)](https://github.com/ArockMSK/ModStructureCheckerApp/releases/download/v1.0.0/ModStructureCheckerApp_x86.exe)
- Download the appropriate version based on your system architecture and ensure .NET 8.0 Runtime is installed.

## Author
Developed by Arock with assistance from Grok (xAI).

---
