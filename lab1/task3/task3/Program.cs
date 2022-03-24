using System;
using System.IO;

namespace task3
{
    internal class Program
    {
        static string path = @"..\..\..\";

        static void Main(string[] args)
        {
            string mdText = "";
            Read(ref mdText, @"orig_text.md");
            FormatText formatText = new FormatText(mdText);
            mdText = formatText.StartConverting();
            WriteToFile(mdText, @"html_text.html");
        }

        static void Read(ref string mdText, string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path+file))
                {
                    mdText = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void WriteToFile(string text, string file)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path+file, false, System.Text.Encoding.Default))
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
