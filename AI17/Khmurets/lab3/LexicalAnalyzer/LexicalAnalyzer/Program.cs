using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Analyzer analyzer = new Analyzer();
            if (analyzer.IsRight)
            {
                analyzer.Analyze();
                Console.WriteLine("\n\nЛексема\tТип лексемы\tЗначение");
                analyzer.ShowTable();
            }
            else
            {
                Console.WriteLine("\n\nConstruction is wrong");
            }
        }
    }
}
