using System;
using System.Collections.Generic;
using System.Text;

namespace SentenceStatistic.Models
{
    class Sentence
    {
        static string symbolsPunctuation = "?!.";//набор символов, на которые может заканчиваться предложение
        static byte[] arrCodeSymbolsPunctuation = getBytesString(symbolsPunctuation);//преобразуем в массив байтов строку, созданную выше
        static char symEndString(string str)//метод типа char (символ), передаем в него строку
        {
            return str[str.Length - 1];//возвращает последний символ строки (предложения)
        }

        public static string getRandomSetSymbols(int countSymbols)//метод возвращает строку из рандомных символов, в него передаем длину этой строки
        {
            List<byte> listBytes = new List<byte>();//создаем список элементов типа byte(целое число от 0 до 255)
            Random r = new Random();//создаем экземпляр класса Random
            for (int i = 0; i < countSymbols; i++)//открываем цикл от 0 до количества символов, которое передали в мтеод
                listBytes.Add((byte)r.Next(192, 255));//добавляем в список рандомное число от 192 до 255 (в таблице символов строчные и прописные буквы как раз лежат в этом промежутке)

            return Encoding.GetEncoding(1251).GetString(listBytes.ToArray()) + symbolsPunctuation[new Random().Next(0, symbolsPunctuation.Length)];
            //возвращаем преобразованную строку из созданного списка (кодировка 1251 означает, что мы можем использовать кириллицу) + добавляем рандомный знак на конец предложения (? или ! или .)
            //также для этого используем экземпляр класса Random, в метод Next передаем парамметры 0 и длинну строки символов (?!.), т.е. рандомим от 0 до 3
        }

        static int getRandomNumber(int minCountNumber, int maxCountNumber)//метод возвращает целое рандомное число в промежутке от переданных значений
        {
            return new Random().Next(minCountNumber, maxCountNumber);//также используем класс Random для случайного значения
        }
        static byte[] getBytesString(string str)//метод, который возвращает массив байтов строки, в него передаем переменную типа string
        {
            return Encoding.GetEncoding(1251).GetBytes(str);//возвращаем массив, используя класс Encoding в указанной кодировке (1251 - это кириллица)
        }

        public static int getCountUpperLetters(string str)//метод возвращает количество прописных букв, в него передаем строку, из которой будем искать те самые символы (прописные буквы)
        {
            int count = 0;//инициализируем счетчик
            byte[] tempArr = getBytesString(str);//создаем массив байтов, используя метод, описанный ранее 
            foreach (var item in tempArr)//открываем цикл foreach (отличается от for тем, что не используется итератор)
                if ((item >= 192 && item <= 223) && isContainsSymbolsPunctuation(item) == false)//если текущий символ лежит в промежутке от 192 до 223 включительно (в таблице символов ascii - это все прописные буквы)
                    //(этот промежуток указывает на то, что код символа соответствует прописной букве) и код символа не является кодом ? или ! или .
                    count++;//увеличиваем счетчик

            return count;//возвращаем счетчик
        }

        static bool isContainsSymbolsPunctuation(byte codeSym)//метод, который вернет true, если если код символа совпал с кодом ? или ! или ., иначе вернет false
        {
            bool result = false;//инициализируем переменную result
            foreach (var item in arrCodeSymbolsPunctuation)//открываем цикл по массиву кодов строки symbolsPunctuation
                if (item == codeSym)//если код текущего символа совпал 
                {
                    result = true;//result присваиваем true
                    break;//выходим из цикла
                }

            return result;//возвращаем result
        }

        public static int getCountLowerLetters(string str)//метод возвращает количество строчных букв, в него передаем строку, из которой будем искать те самые символы (строчные буквы)
        {
            int count = 0;//инициализируем счетчик
            byte[] tempArr = getBytesString(str);//создаем массив байтов, используя метод, описанный ранее 
            foreach (var item in tempArr)//открываем цикл foreach
                if (item >= 224 && isContainsSymbolsPunctuation(item) == false)//если текущий код символа больше 224 (в таблице символов ascii - это все строчные буквы)
                    count++;//увеличиваем счетчик

            return count;//возвращаем наш счетчик
        }

        public static SentenceKind Answer(string str)//метод типа void (ничего не возращает), передаем в него строку (предложение по заданию)
        {
            switch (str[str.Length - 1])//смотрим его последний символов, делаем из этого вывод
            {
                case '.'://если точка
                    return SentenceKind.Narrative;
                case '!'://если восклицательный знак
                    return SentenceKind.Exclamation;
                case '?'://если вопросительный знак
                    return SentenceKind.Interrogative;
            }
            return SentenceKind.None;
        }
    }
}
