using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfAndDiploms
{
    /// <summary>
    /// Класс для чтения данных из документа
    /// </summary>
    public class WordReader
    {
        private dynamic _app;
        private dynamic _doc;
        private readonly string _docPath;
        public event EventHandler ProfRead;

        public List<Professor> Professors { get; set; }

        public WordReader(string docPath)
        {
            _docPath = docPath;
        }

        public void GetProfs()
        {
            Professors = new List<Professor>();

            CreateWordApp();
            OpenDoc();
            var proffs = GetProfIndicies();

            foreach (var i in proffs)
            {
                var name = GetProfName(i);
                var d = GetDiplomas(i).ToList();
                //Если преподаватель уже есть в списке, то добавляем ему дипломы
                var existingProf = Professors.FirstOrDefault(p => p.Name == name);
                if (existingProf != null)
                {
                    existingProf.Diplomas.AddRange(d);
                    OnProfRead();
                    continue;
                }

                var newProf = new Professor
                {
                    Name = name,
                    Diplomas = d
                };
                Professors.Add(newProf);
                OnProfRead();
            }
            Clean();
        }
        /// <summary>
        /// Выделение имени преподавателя
        /// </summary>
        private string GetProfName(int profIndex)
        {
            var range = _doc.Range(profIndex, profIndex);
            range.MoveStartUntil("- ");
            //Имя преподавателя начинается с первой буквы после чёрточки с пробелом
            while (!char.IsLetter(range.Characters.First.Text[0]))
            {
                //продвигаемся пока не найдём букву
                range.Move(1, 1); //wdCharacter
            }
            var start = range.Start;
            var end = start + range.MoveEndUntil(",") - 1;
            return GetRangeText(start, end);
        }
        /// <summary>
        /// Открытие документа
        /// </summary>
        private void OpenDoc()
        {
            try
            {
                _doc = _app.Documents.Open(_docPath, AddToRecentFiles: false, ReadOnly: true);
            }
            catch (Exception e)
            {
                Console.WriteLine(_docPath);
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Создание приложения
        /// </summary>
        private void CreateWordApp()
        {
            try
            {
                _app = Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            _app.Visible = true;
        }
        /// <summary>
        /// Получение списка дипломных проектов для преподавателя
        /// </summary>
        private IEnumerable<Diploma> GetDiplomas(int profIndex)
        {
            dynamic range = _doc.Range;
            int start = profIndex;
            while (true)
            {
                range.SetRange(start, start);
                range = range.Paragraphs.First.Next.Range;
                start = range.Start;
                string firstPara = range.Paragraphs.First.Range.Text;
                if (firstPara.StartsWith("Руководитель") || firstPara.StartsWith("Зам"))
                {
                    yield break;
                }
                if (!firstPara.Contains("Дипломн"))
                {
                    continue;
                }
                var topic = GetTopic(range);
                var group = GetGroup(range);
                var studentName = GetStudentName(range);
                yield return new Diploma
                {
                    Topic = topic,
                    Student = new Student
                    {
                        Group = group,
                        Name = studentName
                    }
                };
            }
        }

        /// <summary>
        /// Выделение темы из абзаца
        /// </summary>
        private string GetTopic(dynamic range)
        {
            int rangeStart = range.Start, rangeEnd = range.End;
            var find = Find(range, "«");//Тема начинается с открывающей кавычки ёлочкой
            if (find == -1) return string.Empty;
            int start = find + 1;
            range.SetRange(rangeStart, rangeEnd);
            find = Find(range, "»");//закрывающая кавычка ёлочкой заканчивает тему диплома
            if (find == -1) return string.Empty;
            //Если в конце темы диплома две закрывающих кавычки
            int end = find + (range.Characters.First.Next.Text == "»" ? 1 : 0);
            var topic = GetRangeText(start, end);
            return topic;
        }
        /// <summary>
        /// Выделение названия группы
        /// </summary>
        private string GetGroup(dynamic range)
        {
            range.SetRange(range.Start, range.Start);
            var find = range.Find;
            if (!find.Execute("группы ")) return string.Empty;
            range.SetRange(find.Parent.End, find.Parent.End);
            int start = range.Start;
            range.MoveEndUntil(" ");
            int end = range.End;
            var group = GetRangeText(start, end);
            return group.Trim();
        }
        /// <summary>
        /// Выделение имени студента
        /// </summary>
        private string GetStudentName(dynamic range)
        {
            range.SetRange(range.End, range.End);
            range.MoveEndUntil(".");//Двигаемся до точки в конце абзаца
            return GetRangeText((int)range.Start, (int)range.End).Trim();
        }

        /// <summary>
        /// Текст между позициями в документе
        /// </summary>
        /// <param name="start">Начало текста</param>
        /// <param name="end">Конец текста</param>
        private string GetRangeText(int start, int end)
        {
            if (start < 0 || end < 0)
            {
                return string.Empty;
            }
            if (start > _doc.Range.End || end > _doc.Range.End)
            {
                return string.Empty;
            }
            if (end < start)
            {
                throw new ArgumentException($"Начальный индекс должен быть меньше конечного. Start = {start}, End = {end}");
            }
            return _doc.Range(start, end).Text;
        }

        /// <summary>
        /// Позиции, с которых в документе начинаются абзацы с рукодителями проектов
        /// </summary>
        private IEnumerable<int> GetProfIndicies()
        {
            dynamic find = _doc.Range.Find;
            find.Text = "Руководитель";
            while (find.Execute)
            {
                yield return find.Parent.Start;
            }
        }

        public void Clean()
        {
            _doc?.Close(false);
            _app?.Quit(false);
        }

        private static int Find(dynamic range, string text)
        {
            var find = range.Find;
            if (!find.Execute(text))
            {
                return -1;
            }
            return find.Parent.Start;
        }

        protected virtual void OnProfRead()
        {
            ProfRead?.Invoke(this, EventArgs.Empty);
        }
    }
}
