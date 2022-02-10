using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ex1_studio_
{
    class Program
    {
        static public string deleteDpl(string inp)
        {
            var d = new List<string>();
            return Regex.Replace(inp, @"\b\w+\b", m =>
            {
                if (d.Contains(m.Value)) return "**" + m.Value + "**";
                else
                {
                    d.Add(m.Value);
                    return m.Value;
                }
            });
        }
        static void Main(string[] args)
        {
            Console.Write("Enter your string: ");
             
            Console.WriteLine("\nRight version: " + deleteDpl(Console.ReadLine()));
        }
    }
}
