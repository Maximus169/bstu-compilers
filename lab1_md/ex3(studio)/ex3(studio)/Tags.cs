using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ex3_studio_
{
    class Tags
    {
        private string[] mdTag = {  @"# ", @" #", @"## ", @" ##", @"### ", @" ###", @"#### ", @" ####", @"##### ", @" #####", @"###### ", @" ######",
                                    @"* ", @" *"
        };
        private string[] specMdTag = { @"\*\b\w", @"\w\b\*", @"~~\b\w", @"\w\b~~", @"`\b\w", @"\w\b`", @">.+" };
        private string[] monoMdTag = { @"\*", @"\*", @"~~", @"~~", @"`", @"`", @">" };
        private string[] htmlTag = {    "<h1>", "</h1>", "<h2>", "</h2>", "<h3>", "</h3>", "<h4>", "</h4>", "<h5>", "</h5>", "<h6>", "</h6>",
                                        "<li>", "</li>"
        };
        private string[] specHtmlTag = { "<i>", "</i>", "<s>", "</s>", "<code>", "</code>", "<blockquote>" };
        private bool spec;
        private uint position;
        public Tags()
        {
            spec = false;
        }
        public bool Contains(string tag)
        {
            uint index = 0;
            foreach (var item in mdTag)
            {
                if (item == tag)
                {
                    position = index;
                    return true;
                }
                index++;
            }
            index = 0;
            foreach (var item in specMdTag)
            {
                if (Regex.IsMatch(tag, item))
                {
                    position = index;
                    spec = true;
                    return true;
                }
                index++;
            }
            return false;
        }
        public string getTag(string tag)
        {
            if (spec)
            {
                spec = false;
                if(position == 6)
                {
                    Regex regex = new Regex(monoMdTag[position]);
                    tag = regex.Replace(tag, specHtmlTag[position]);
                    return tag + "</blockquote>";
                }
                else
                {
                    Regex regex = new Regex(monoMdTag[position]);
                    return regex.Replace(tag, specHtmlTag[position]);
                }
            }
            else
                return htmlTag[position];
        }
    }
}
