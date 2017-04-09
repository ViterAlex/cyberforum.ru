using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                Console.WriteLine("Без аргументов");
            else
                Console.WriteLine("Переданные параметры: {0}", string.Join(", ", args));
        }
    }
}