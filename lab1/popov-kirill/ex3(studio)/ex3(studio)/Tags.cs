using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex3_studio_
{
    class Tags
    {
        private string[] mdTags = { @"\s\>", @"\#\#\#\#\#\#\s", @"\#\#\#\#\#\s", @"\#\#\#\#\s", @"\#\#\#\s", @"\#\#\s", @"\#\s", @"\*",
            @"\~\~", @"\-\s", @"\`" };
        private string[] htmlTags = { "blockquote", "h6", "h5", "h4", "h3", "h2", "h1", "i", "s", "li", "code" };
        private string mainPattern = @"+[\w+\s+\'+\!+\?+\.+\:+]+";
        private bool[] isSingle = { true, true, true, true, true, true, true, false, false, true, false };
        public int count;
        public Tags()
        {
            count = mdTags.Length;
        }

        public int Count { get { return count; } }

        public string Pattern(int iterator)
        {
            if (isSingle[iterator])
            {
                return mdTags[iterator] + mainPattern + @"<br>";
            }
            else
            {
                return mdTags[iterator] + mainPattern + mdTags[iterator];
            }
        }

        public string MDTag(int iterator)
        {
            return mdTags[iterator];
        }

        public string HTMLTag(int iterator)
        {
            return htmlTags[iterator];
        }
    }
}
