using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ex3_studio_
{
    class Change
    {
        private string mdText;

        public Change(ref string text)
        {
            mdText = text;
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
                    Regex regex = new Regex(tags.MDTag(i)); 
                    string temp = regex.Replace(m.Value, String.Empty); 
                    return $"<{tags.HTMLTag(i)}>" + temp + $"</{tags.HTMLTag(i)}>"; 
                });
            }


            Console.WriteLine(Environment.NewLine + mdText);
            return mdText;
        }
    }
}
