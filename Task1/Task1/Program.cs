using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task1
{
    internal class Program
    {
        static string writePath = @"D:\Task1\new_text.md";

        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            PreparingText textOperations = new PreparingText(text);
            text = textOperations.StartProcess();
            Console.WriteLine($"New text:\n{text}");
            WriteToFile(text);
        }

        static void WriteToFile(string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
