using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LexicalAnalyzer // доделать идентификацию значений
{
    internal class Analyzer
    {
        private string path = @"..\..\..\code.txt";
        private string code;
        bool recognized;
        List<Lexema> tokens;

        public Analyzer()
        {
            tokens = new List<Lexema>();
            ReadCode();
            recognized = true;
            Check();
        }

        public void Analyze()
        {
            string[] parts = code.Split(' ', '\n', '\t', '\r');
            Regex identReg = new Regex(@"\w+");
            Regex arithReg = new Regex(@"[\/\*\-+%]+[\=]");
            Regex logReg = new Regex(@"[<>=]");
            int keyCount = 1, identCount = 1;
            foreach (string part in parts)
            {
                if(part == "while" || part == "do" || part == "(" || part == ")" || part == ";")
                {
                    tokens.Add(new Lexema(part, "Ключевое слово", $"X{keyCount}"));
                    keyCount++;
                } 
                else if (int.TryParse(part, out int value))
                {
                    tokens.Add(new Lexema(part, "Цел. константа", part));
                }
                else if(double.TryParse(part, out double val))
                {
                    tokens.Add(new Lexema(part, "Вещ. константа", part));
                }
                else if (identReg.IsMatch(part))
                {
                    bool isFound = false;
                    for(int i = 0; i < tokens.Count; i++)
                    {
                        if(tokens[i].Name == part)
                        {
                            tokens.Add(new Lexema(part, "Идентификатор", tokens[i].Value));
                            isFound = true;
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        tokens.Add(new Lexema(part, "Идентификатор", $"{part} : {identCount}"));
                        identCount++;
                    }
                }
                else if (arithReg.IsMatch(part))
                {
                    tokens.Add(new Lexema(part, "Арифм. операция", String.Empty));
                }
                else if (logReg.IsMatch(part))
                {
                    tokens.Add(new Lexema(part, "Лог. операция", String.Empty));
                }
            }
        }

        public void ShowTable()
        {
            for(int i = 0; i < tokens.Count; i++)
            {
                tokens[i].ShowInfo();
            }
        }

        private void Check()
        {
            string[] blocks = code.Split('\n');
            Regex regex = new Regex(@"while\s\(+[\w+\s+\<\>\=\!\.]+\)\sdo");
            MatchCollection matches = regex.Matches(blocks[0]);
            if (matches.Count == 0)
                recognized = false;
            for (int i = 1; i < blocks.Length - 1; i++)
            {
                regex = new Regex(@"\t+(\w+\s+[\*\-+=/]{1,2})+\s[\w+]");
                matches = regex.Matches(blocks[i]);
                if (matches.Count == 0)
                    recognized = false;
            }
            if(blocks[blocks.Length-1] != ";")
                recognized = false;
        }

        public void ReadCode()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                code = sr.ReadToEnd();
            }
            Console.WriteLine("Original text:\n\n" + code);
        }

        public bool IsRight { get { return recognized; } }
    }
}
