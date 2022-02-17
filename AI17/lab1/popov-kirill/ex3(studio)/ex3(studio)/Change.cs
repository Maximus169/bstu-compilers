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

        public Change(string text)
        {
            mdText = text;
        }

        public string StartConverting()
        {
            
            Tags tags = new Tags();

            Regex reg = new Regex(@"((#){1,6} )*( (#){1,6})*(\*\b\w)*(\w\b\*)*(\w\b~~)*(~~\b\w)*(`\b\w)*(\w\b`)*(\* )*(>.+\n)*", RegexOptions.Multiline);
            mdText = reg.Replace(mdText, m =>
            {
                if (tags.Contains(m.Value))
                    return tags.getTag(m.Value);
                else
                    return m.Value;
            });

            reg = new Regex(@"$", RegexOptions.Multiline);
            mdText = reg.Replace(mdText, m =>
            {
                return m.Value + $"<br>";
            });

            return Regex.Replace(mdText, @"<\/h[1-6]>.<br>", m =>
            {
                return Regex.Replace(m.Value, @"<br>", m =>
                {
                    return "";
                });
            });
        }
    }
}
