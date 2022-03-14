using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer
{
    internal class Lexema
    {
        private string name;
        private string type;
        private string value;
        

        public Lexema(string lexema, string type, string value)
        {
            this.name = lexema;
            this.type = type;
            this.value = value;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{name}\t{type}\t{value}");
        }

        public string Name { get { return name; } }
        public string Value { get { return value; } }
    }
}
