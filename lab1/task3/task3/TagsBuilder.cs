using System.Collections.Generic;

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
