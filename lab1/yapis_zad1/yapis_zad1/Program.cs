using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace yapis_zad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            var words = new HashSet<string>();
            text = Regex.Replace(text, "\\w+", m => words.Add(m.Value.ToUpperInvariant()) ? m.Value : $"**{m.Value}**");
            Console.WriteLine($"Обработанный текст:\n{text}");
        }
    }
}
