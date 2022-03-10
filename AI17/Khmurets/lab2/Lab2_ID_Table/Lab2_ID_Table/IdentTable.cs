using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_ID_Table
{
    internal class IdentTable
    {
        private string path = @"..\..\..\identifiers.txt";
        private List<Element> elements;

        public IdentTable()
        {
            elements = new List<Element>();
            FillFromFile();
        }

        private void FillFromFile()
        {
            List<string> test = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] info = sr.ReadLine().Split(' ');
                    elements.Add(new Element(info[0].ToUpper(), info[1]));
                }
                
            }
            Sort();
            ShowTable();
        }

        public void Add(string val, string info)
        {
            elements.Add(new Element(val.ToUpper(), info));
            Sort();
            Console.WriteLine("\nUpdated table:\n");
            ShowTable();
        }

        public int Search(string val)
        {
            int firstIndex = 0, lastIndex = elements.Count - 1, counter = 0;

            while(firstIndex <= lastIndex)
            {
                int middle = (firstIndex + lastIndex) / 2;
                if (elements[middle].value == val)
                {
                    Console.WriteLine("Number of comparisons: {0}", counter);
                    return middle;
                }
                else if(string.Compare(elements[middle].value,val) > 0)
                {
                    counter++;
                    firstIndex = middle + 1;
                }
                else if(string.Compare(elements[middle].value, val) < 0)
                {
                    counter++;
                    lastIndex = middle - 1;
                }
            }

            return -1;
        }

        public void ShowElement(int i)
        {
            Console.WriteLine(elements[i].value + " - " + elements[i].info);
        }

        public void ShowTable()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                Console.WriteLine(elements[i].value + " - " + elements[i].info);
            }
        }

        private void Sort()
        {
            elements.Sort(delegate (Element first, Element second)
            {
                return string.Compare(second.value, first.value);
            });
        }
    }
}
