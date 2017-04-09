using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConsoleCapture
{
    public class ConsoleCapture
    {
        /// <summary>
        ///     Обрамляет кавычками аргументы, имеющие пробелы или начинающиеся с кавычек
        ///     и возвращает одну строку аргументов для метода Process.Start();
        /// </summary>
        /// <param name="args">Список аргументов, не может содержать null, '\0', '\r', или '\n'</param>
        /// <returns>Подготовленную строку с экранированными и взятыми в кавычки аргументами</returns>
        /// <exception cref="ArgumentNullException">возникает, если один из аргументов null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Возникает, если аргумент содержит '\0', '\r', or '\n'</exception>
        public static string EscapeArguments(params string[] args)
        {
            StringBuilder arguments = new StringBuilder();
            Regex invalidChar = new Regex("[\x00\x0a\x0d]");
                //  неверные символы. Не могут быть экранированы или взяты в кавычки
            Regex needsQuotes = new Regex(@"\s|"""); //          содержит пробелы или двойные кавычки
            Regex escapeQuote = new Regex(@"(\\*)(""|$)");
                //    один или больше '\', за которым стоит кавычка или конец строки
            for (int carg = 0; args != null && carg < args.Length; carg++)
            {
                if (args[carg] == null) throw new ArgumentNullException(string.Format("args[{0}]", carg));
                if (invalidChar.IsMatch(args[carg])) throw new ArgumentOutOfRangeException(
                    string.Format("args[{0}]", carg));
                if (args[carg] == string.Empty)
                {
                    arguments.Append("\"\"");
                }
                else if (!needsQuotes.IsMatch(args[carg]))
                {
                    arguments.Append(args[carg]);
                }
                else
                {
                    arguments.Append('"');
                    arguments.Append(
                        escapeQuote.Replace(
                            args[carg], m =>
                                m.Groups[1].Value + m.Groups[1].Value +
                                (m.Groups[2].Value == "\"" ? "\\\"" : "")
                        ));
                    arguments.Append('"');
                }
                if (carg + 1 < args.Length)
                    arguments.Append(' ');
            }
            return arguments.ToString();
        }

        /// <summary>
        ///     Разворачивает переменные окружени и, если не указан полный путь, запускает файл из рабочей директории
        ///     или переменной окружения
        /// </summary>
        /// <param name="exe">Имя исполняемого файла</param>
        /// <returns>Полный путь к файлу</returns>
        /// <exception cref="FileNotFoundException">Возникает, если файл не был найден</exception>
        public static string FindExePath(string exe)
        {
            exe = Environment.ExpandEnvironmentVariables(exe);
            if (File.Exists(exe)) return Path.GetFullPath(exe);
            if (Path.GetDirectoryName(exe) != string.Empty)
                throw new FileNotFoundException(new FileNotFoundException().Message, exe);
            foreach (string test in (Environment.GetEnvironmentVariable("PATH") ?? "").Split(';'))
            {
                string path = test.Trim();
                if (!string.IsNullOrEmpty(path) && File.Exists(path = Path.Combine(path, exe)))
                    return Path.GetFullPath(path);
            }
            throw new FileNotFoundException(new FileNotFoundException().Message, exe);
        }

        /// <summary>
        ///     Запускает на выполнение указанный файл с указанными аргументами и возвращает код выхода процесса
        ///     Runs the specified executable with the provided arguments and returns the process' exit code.
        /// </summary>
        /// <param name="output">Получает вывод из std/err или из std/out</param>
        /// <param name="input">Предоставляет построчный ввод, который записывается в std/in. null для пустого ввода</param>
        /// <param name="exe">Путь к исполяемому файлу. Может быть не полный или содержать переменные окружения</param>
        /// <param name="args">Список аргументов</param>
        /// <returns>Возвращает код выхода из процесса после его завершения</returns>
        /// <exception cref="FileNotFoundException">Возникает, если исполняемый файл не был найден</exception>
        /// <exception cref="ArgumentNullException">Возникает, если один из аргументов null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Возникает, если один из аргументов содержит '\0', '\r', или '\n'</exception>
        public static int Run(Action<string> output, TextReader input, string exe, params string[] args)
        {
            if (string.IsNullOrEmpty(exe))
                throw new FileNotFoundException();
            if (output == null)
                throw new ArgumentNullException("output");

            ProcessStartInfo psi = new ProcessStartInfo
                                   {
                                       UseShellExecute = false,
                                       RedirectStandardError = true,
                                       RedirectStandardOutput = true,
                                       RedirectStandardInput = true,
                                       WindowStyle = ProcessWindowStyle.Hidden,
                                       CreateNoWindow = true,
                                       ErrorDialog = false,
                                       WorkingDirectory = Environment.CurrentDirectory,
                                       FileName = FindExePath(exe), //подробнее http://csharptest.net/?p=526
                                       Arguments = EscapeArguments(args) // подробнее http://csharptest.net/?p=529
                                   };

            using (Process process = Process.Start(psi))
            {
                using (ManualResetEvent mreOut = new ManualResetEvent(false), mreErr = new ManualResetEvent(false))
                {
                    process.OutputDataReceived += (o, e) =>
                    {
                        if (e.Data == null) mreOut.Set();
                        else output(e.Data);
                    };
                    process.BeginOutputReadLine();
                    process.ErrorDataReceived += (o, e) =>
                    {
                        if (e.Data == null) mreErr.Set();
                        else output(e.Data);
                    };
                    process.BeginErrorReadLine();

                    string line;
                    while (input != null && null != (line = input.ReadLine()))
                        process.StandardInput.WriteLine(line);

                    process.StandardInput.Close();
                    process.WaitForExit();

                    mreOut.WaitOne();
                    mreErr.WaitOne();
                    return process.ExitCode;
                }
            }
        }
    }
}