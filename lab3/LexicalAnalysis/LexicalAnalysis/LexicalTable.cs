using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalysis
{
    internal class LexicalTable
    {
        public string lexeme;
        public string lexemeType;
        public string value;
        public LexicalTable(string lexeme, string lexemeType, string value)
        {
            this.value = value;
            this.lexeme = lexeme;
            this.lexemeType = lexemeType;
        }
    }
}
