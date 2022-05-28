using System;
using System.Collections.Generic;
using System.IO;

namespace yapis_2
{
    public class Tree
    {
        public List<Identifier> identifiers;

        public Tree()
        {
            identifiers = new List<Identifier>();
        }

        public void FillTree()
        {
            List<string> test = new List<string>();
            using (StreamReader sr = new StreamReader(@"..\..\..\identifiers.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] info = sr.ReadToEnd().Split('\n');
                    AddElements(info);
                }
            }
        }

        private void AddElements(string[] info)
        {
            string[] firstEl = info[0].Split(' ');
            identifiers.Add(new Identifier(firstEl[0], firstEl[1], 0));
            identifiers[0].parent = identifiers[0];
            identifiers[0].inheritor = "None";

            for(int i = 1; i < info.Length; i++)
            {
                string[] element = info[i].Split(' ');
                bool isAdded = false;
                int currentID = 0;
                while (!isAdded)
                {
                    if (String.Compare(identifiers[currentID].value, element[0]) > 0)
                    {
                        if (identifiers[currentID].leftChild == null)
                        {
                            int id = identifiers.Count;
                            identifiers.Add(new Identifier(element[0], element[1], id));
                            identifiers[identifiers.Count - 1].parent = identifiers[currentID];
                            identifiers[identifiers.Count - 1].inheritor = "left";
                            identifiers[currentID].leftChild = identifiers[identifiers.Count - 1];
                            isAdded = true;
                        }
                        else
                        {
                            currentID = identifiers[currentID].leftChild.id;
                        }
                    }
                    else if (String.Compare(identifiers[currentID].value, element[0]) == 0)
                    {
                        return;
                    }
                    else
                    {
                        if (identifiers[currentID].rightChild == null)
                        {
                            int id = identifiers.Count;
                            identifiers.Add(new Identifier(element[0], element[1], id));
                            identifiers[identifiers.Count - 1].parent = identifiers[currentID];
                            identifiers[identifiers.Count - 1].inheritor = "right";
                            identifiers[currentID].rightChild = identifiers[identifiers.Count - 1];
                            isAdded = true;
                        }
                        else
                        {
                            currentID = identifiers[currentID].rightChild.id;
                        }
                    }
                }
            }
        }

        public void Search(string value)
        {
            bool isFound = false;
            int currentID = 0;
            int numOfComparisons = 0;
            while (!isFound)
            {
                if(String.Compare(identifiers[currentID].value, value) == 0)
                {
                    Console.WriteLine($"You found, that {identifiers[currentID].value} is " +
                        $"{identifiers[currentID].info}\nNumber of comparisons: {numOfComparisons}\n\n");
                    isFound = true;
                }
                else if (String.Compare(identifiers[currentID].value, value) > 0)
                {
                    numOfComparisons++;
                    currentID = identifiers[currentID].leftChild.id;
                }
                else
                {
                    numOfComparisons++;
                    currentID = identifiers[currentID].rightChild.id;
                }
            }
        }

        public void ShowTree()
        {
            Console.WriteLine();
            foreach (var ident in identifiers)
            {
                Console.Write($"{ident.value}: {ident.info}\nparent: {ident.parent.value} {ident.inheritor}\n\n");
            }
        }
    }
}
