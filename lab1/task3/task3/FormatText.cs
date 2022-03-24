using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace task3
{
    internal class FormatText
    {
        private string mdText;
        private List<Tag> Tags;

        public FormatText(string text)
        {
            mdText = text;
            Console.WriteLine(mdText);
            Tags = new List<Tag>();
            FillTheTags();
        }

        public string StartConverting()
        {
            TagsBuilder tagsBuilder = new TagsBuilder(Tags);
            Regex reg = new Regex(@"\n");
            mdText = reg.Replace(mdText, delegate (Match m)
            {
                return m.Value + $"<br> ";
            });

            for (int i = 0; i < Tags.Count; i++)
            {
                reg = new Regex(tagsBuilder.Pattern(i));
                mdText = reg.Replace(mdText, delegate (Match m)
                {
                    // поступает строка по заданному шаблону
                    Regex regex = new Regex(Tags[i].MD); // задается шаблон для удаления md-тега
                    string temp = regex.Replace(m.Value, String.Empty); // md-тег удаляется из найденной строки
                    return $"<{Tags[i].HTML}>" + temp + $"</{Tags[i].HTML}>"; // возвращается найденная строка с html-тегами
                });
            }


            Console.WriteLine(Environment.NewLine + mdText);
            return mdText;
        }

        private void FillTheTags()
        {
            StreamReader f = new StreamReader(@"..\tags-info.txt");
            string[] mdTags = SeparateTags(ref f);
            string[] htmlTags = SeparateTags(ref f);
            string[] boolArr = SeparateTags(ref f);
            f.Close();

            for(int i = 0;i < mdTags.Length; i++)
            {
                Tags.Add(new Tag(mdTags[i], htmlTags[i], Convert.ToBoolean(boolArr[i])));
            }
        }

        private string[] SeparateTags(ref StreamReader f)
        {
            string temp = f.ReadLine();
            string[] arr = temp.Split(' ');
            return arr;
        }

    }
}
