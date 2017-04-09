using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Win32;
using RunConsole.Commands;
using RunConsole.Models;

namespace RunConsole.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Свойства

        private DelegateCommand<int> _addArgumentCommand;
        private DelegateCommand _browseFileCommand;
        private DelegateCommand _clearCommand;
        private DelegateCommand _exitCommand;
        private StringBuilder _output;
        private Process _process;
        private DelegateCommand<int> _removeArgumentCommand;
        private DelegateCommand _runCommand;

        #endregion

        #region Constructor

        public MainViewModel()
        {
            Arguments = new ObservableCollection<ArgumentInfo>();
            EncodingInfos = new List<EncodingInfo>(Encoding.GetEncodings());
            SelectedEncoding = EncodingInfos.First(ei => ei.CodePage == 866);
        }

        #endregion

        /// <summary>
        ///     Диалог выбора файла
        /// </summary>
        private void BrowseFile()
        {
            var dialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                Filter = "Исполняемые файлы|*.exe"
            };
            if (dialog.ShowDialog() == false) return;
            ExecPath = dialog.FileName;
        }

        /// <summary>
        ///     Выход из приложения
        /// </summary>
        private void Exit()
        {
            KillProcess();
            Application.Current.Shutdown();
        }

        /// <summary>
        ///     Завершение процесса
        /// </summary>
        private void KillProcess()
        {
            if (_process != null && !_process.HasExited)
                _process.Kill();
        }

        /// <summary>
        ///     Запуск консольного приложения и получение текста из его потока вывода
        /// </summary>
        private void RunConsole()
        {
            //Завершение процесса, если он был создан раньше
            KillProcess();
            //Создание нового процесса.
            _process = new Process
            {
                //Процесс может вызывать события
                EnableRaisingEvents = true,
                StartInfo =
                           {
                               //Путь к исполняемому файлу процесса
                               FileName = ExecPath,
                               //Не запускать системой
                               UseShellExecute = false,
                               //Перенаправление вывода
                               RedirectStandardOutput = true,
                               //Аргументы командной строки
                               Arguments = string.Join(" ", Arguments.Select(arg => string.Format("\"{0}\"", arg.Value))),
                               //Не создавать окно
                               CreateNoWindow = true,
                               //Кодировка для кириллических символов
                               StandardOutputEncoding = SelectedEncoding.GetEncoding()
                           }
            };
            //Буфер для вывод
            if (_output == null)
                _output = new StringBuilder();
            //Событие получения данных из потока вывода
            _process.OutputDataReceived += (sender, args) =>
            {
                Dispatcher.Invoke(
                    DispatcherPriority.Background, new Action(
                        () =>
                        {
                            //Добавляем строку в буфер.
                            _output.AppendLine(args.Data);
                            Output = _output.ToString();
                        }));
            };
            _process.Start();
            _process.BeginOutputReadLine();
        }

        #region Properties

        /// <summary>
        ///     Список поддерживаемых кодировок
        /// </summary>
        public List<EncodingInfo> EncodingInfos { get; set; }

        /// <summary>
        ///     Выбранная кодировка
        /// </summary>
        public EncodingInfo SelectedEncoding { get; set; }

        /// <summary>
        ///     Коллекция аргументов командной строки
        /// </summary>
        public ObservableCollection<ArgumentInfo> Arguments { get; set; }

        public static readonly DependencyProperty ExecPathProperty = DependencyProperty.Register(
            "ExecPath", typeof(string), typeof(MainViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        ///     Путь к исполняемому файлу
        /// </summary>
        public string ExecPath
        {
            get
            {
                return (string)GetValue(ExecPathProperty);
            }
            set
            {
                SetValue(ExecPathProperty, value);
            }
        }

        public static readonly DependencyProperty OutputProperty = DependencyProperty.Register(
            "Output", typeof(string), typeof(MainViewModel), new PropertyMetadata(default(StringBuilder)));

        /// <summary>
        ///     Строка полученная из потока вывода запущенного приложения
        /// </summary>
        public string Output
        {
            get
            {
                return (string)GetValue(OutputProperty);
            }
            set
            {
                SetValue(OutputProperty, value);
            }
        }

        #endregion

        #region Commands

        /// <summary>
        ///     Команда для диалога выбора файла
        /// </summary>
        public ICommand BrowseFileCommand
        {
            get
            {
                if (_browseFileCommand == null)
                    _browseFileCommand = new DelegateCommand(BrowseFile);
                return _browseFileCommand;
            }
        }

        /// <summary>
        ///     Команда добавления аргумента в список
        /// </summary>
        public ICommand AddArgumentCommand
        {
            get
            {
                if (_addArgumentCommand == null)
                    _addArgumentCommand =
                        new DelegateCommand<int>(n =>
                        {
                            Arguments.Add(new ArgumentInfo(
    string.Format("arg{0}", n + 1)));
                        });
                return _addArgumentCommand;
            }
        }

        /// <summary>
        ///     Команда удаления аргумента из списка
        /// </summary>
        public ICommand RemoveArgumentCommand
        {
            get
            {
                if (_removeArgumentCommand == null)
                    _removeArgumentCommand = new DelegateCommand<int>(
                        n =>
                        {
                            Arguments.RemoveAt(n);
                        },
                        n => n != -1);
                return _removeArgumentCommand;
            }
        }

        /// <summary>
        ///     Команда для запуска исполняемого файла
        /// </summary>
        public ICommand RunCommand
        {
            get
            {
                if (_runCommand == null)
                    _runCommand = new DelegateCommand(RunConsole, () => !string.IsNullOrEmpty(ExecPath));
                return _runCommand;
            }
        }

        /// <summary>
        ///     Команда для выхода из приложения
        /// </summary>
        public ICommand ExitCommand
        {
            get
            {
                if (_exitCommand == null)
                    _exitCommand = new DelegateCommand(Exit);
                return _exitCommand;
            }
        }

        /// <summary>
        ///     Команда для очистки поля вывода
        /// </summary>
        public ICommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                    _clearCommand = new DelegateCommand(
                        () =>
                        {
                            _output.Clear();
                            Output = _output.ToString();
                            OnPropertyChanged("Output");
                        }, () => !string.IsNullOrEmpty(Output));
                return _clearCommand;
            }
        }

        #endregion
    }
}