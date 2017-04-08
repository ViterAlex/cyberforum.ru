using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertFilesToText
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            foundedLabel.Text = "0";
            parsedLabel.Text = "0";
            elapsedLabel.Text = new TimeSpan().ToString(@"mm\:ss\.ff");
            dataGridView1.AutoGenerateColumns = true;
        }

        private dynamic _wdApp;//Приложение Word
        private Stopwatch _stopwatch;//счётчик времени
        private ConcurrentBag<FileContent> _fileTexts;//хранилище строк из файлов

        //Счётчик найденных файлов
        private int _foundedFilesCount;


        private void startButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                startButton.Enabled = false;
                _foundedFilesCount = 0;
                _stopwatch = new Stopwatch();
                _fileTexts = new ConcurrentBag<FileContent>();
                if (_wdApp != null)
                {
                    ExitWord();
                }
                _wdApp = Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application"));
                _stopwatch.Start();

                EnumerateFiles(dialog.SelectedPath);
                //Ожидание окончания обработки
                while (_foundedFilesCount != _fileTexts.Count)
                {
                    Application.DoEvents();
                    ShowInfo();
                }

                _stopwatch.Stop();
                ExitWord();
                startButton.Enabled = true;
            }
        }

        private void ExitWord()
        {
            _wdApp.Quit();
            _wdApp = null;
        }

        /// <summary>
        /// Перебор файлов в указанном каталоге
        /// </summary>
        /// <param name="path">Путь к каталогу</param>
        private void EnumerateFiles(string path)
        {

            foreach (var file in Directory.EnumerateFiles(path, "*.txt", SearchOption.AllDirectories))
            {
                ReadFromTxtFile(file);
                _foundedFilesCount++;
            }
            foreach (var file in Directory.EnumerateFiles(path, "*.doc*", SearchOption.AllDirectories))
            {
                ReadFromDocFile(file);
                _foundedFilesCount++;
            }
            foreach (var file in Directory.EnumerateFiles(path, "*.rtf", SearchOption.AllDirectories))
            {
                ReadFromDocFile(file);
                _foundedFilesCount++;
            }
        }
        /// <summary>
        /// Чтение файла типа doc или rtf
        /// </summary>
        /// <param name="file">Путь к файлу</param>
        private async void ReadFromDocFile(string file)
        {
            string text = await Task<string>.Factory.StartNew(() =>
            {
                try
                {
                    dynamic wdDoc = _wdApp.Documents.Open(file);
                    string s = wdDoc.Content.Text.ToString();
                    wdDoc.Close(false);
                    return s;
                }
                catch (Exception ex)
                {
                    throw new AccessViolationException($"Ошибка чтения файла {file}\r\n{ex.InnerException}");
                }
            });
            if (text.Length > 0)
            {
                var fc = new FileContent(DateTime.Now, file, text);
                _fileTexts.Add(fc);
                bindingSource1.Add(fc);
            }
            ShowInfo();
        }
        /// <summary>
        /// Чтение файла типа txt
        /// </summary>
        /// <param name="file">Путь к файлу</param>
        private async void ReadFromTxtFile(string file)
        {
            var text = await Task<string>.Factory.StartNew(() => File.ReadAllText(file));
            if (text.Length > 0)
            {
                var fc = new FileContent(DateTime.Now, file, text);
                _fileTexts.Add(fc);
                bindingSource1.Add(fc);
            }
            ShowInfo();
        }
        /// <summary>
        /// Отображение информации о ходе работы
        /// </summary>
        private void ShowInfo()
        {
            foundedLabel.Text = _foundedFilesCount.ToString();
            if (_fileTexts != null)
            {
                parsedLabel.Text = _fileTexts.Count.ToString();
            }
            if (_stopwatch != null)
            {
                elapsedLabel.Text = _stopwatch.Elapsed.ToString(@"mm\:ss\.ff");
            }
        }
    }
}
