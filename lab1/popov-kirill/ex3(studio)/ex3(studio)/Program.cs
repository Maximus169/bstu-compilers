﻿using System;
using System.IO;

namespace ex3_studio_
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\WorkPlace\University-3-6\labs\LPIS\lab1_md\ex3(studio)\";

            string text;

            using (FileStream fstream = File.OpenRead($"{path}text.md"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                text = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {text}");
            }

            Change ch = new Change(ref text);

            using (FileStream fstream = new FileStream($"{path}title.html", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(ch.StartConverting());
                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
