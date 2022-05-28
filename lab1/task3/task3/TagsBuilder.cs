using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class TagsBuilder  
    {
        private string mainPattern = @"+[\w+\s+\'+\!+\?+\.+\:+]+";
        private List<Tag> Tags;

        public TagsBuilder(List<Tag> Tags)
        {
            this.Tags = Tags;
        } 

        public string Pattern(int iterator)
        {
            if (Tags[iterator].IsSingle)
            {
                return Tags[iterator].MD + mainPattern + @"<br>";
            }
            else
            {
                return Tags[iterator].MD + mainPattern + Tags[iterator].MD;
            }
        }
    }
}
