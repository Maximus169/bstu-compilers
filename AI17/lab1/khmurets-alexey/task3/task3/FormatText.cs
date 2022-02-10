using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task3
{
    internal class FormatText
    {
        private string mdText;
        private string[] mdTags = {  };

        public FormatText(string text)
        {
            mdText = text;
            Console.WriteLine(mdText);
        }

        public string StartConverting()
        {
            Tags tags = new Tags();
            Regex reg = new Regex(@"\n");
            mdText = reg.Replace(mdText, delegate (Match m)
            {
                return m.Value + $"<br> ";
            });
            mdText = mdText.Replace(Environment.NewLine, "");

            for (int i = 0; i < tags.Count; i++)
            {
                reg = new Regex(tags.Pattern(i));
                mdText = reg.Replace(mdText, delegate (Match m)
                {
                    // поступает строка по заданному шаблону
                    Regex regex = new Regex(tags.MDTag(i)); // задается шаблон для удаления md-тега
                    string temp = regex.Replace(m.Value, String.Empty); // md-тег удаляется из найденной строки
                    return $"<{tags.HTMLTag(i)}>" + temp + $"</{tags.HTMLTag(i)}>"; // возвращается найденная строка с html-тегами
                });
            }


            Console.WriteLine(Environment.NewLine + mdText);
            return mdText;
        }

    }
}
