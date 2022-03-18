using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
    class PreparingText
    {
        private string origText;

        public PreparingText(string txt)
        {
            origText = txt;
        }

        public string StartProcess()
        {
            var words = new HashSet<string>();
            origText = Regex.Replace(origText, "\\w+", m => // \\w+ - обратная ссылка, идентиф. повторы в строке
                                 words.Add(m.Value.ToUpperInvariant())
                                     ? m.Value
                                     : $"**{m.Value}**");
            return origText;
        }
    }
}
