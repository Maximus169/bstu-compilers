using System.Text.RegularExpressions;

namespace ЯПИС_1_3
{
    class Program
    {
        public static string[] str = new string[13];
        public static string[] markdown =
        {
             ">",
            "**",
            "~~",
            "*",
            "######",
            "#####",
            "####",
            "###",
            "##",
            "#",           
            "'"
        }; 
        
        public static void ReadFromFile()
        {
           str = File.ReadAllLines("mrkd.txt");
        }
        public static string[] Replace()
        {
            for(int i=0;i<str.Length;i++)
            {
                for (int j = 0; j < markdown.Length; j++)
                {
                    if (str[i].Contains(markdown[j]))
                    {
                        str[i] = Regular(str[i], j);
                    }
                }
            }
            return str;
        }        
        public static string Regular(string inputStr, int i)
        {
            string newStr;
            switch (i)
            {
                case 0:
                    newStr = Regex.Replace(inputStr, @">(.*)", "<blockquote>$1</blockquote>");
                    return newStr;
                case 1:                  
                    newStr = Regex.Replace(inputStr, @"\*\*(.*)\*\*", "<b>$1</b>");
                    return newStr;
                case 2:
                    newStr = Regex.Replace(inputStr, @"~~(.*)~~", "<s>$1</s>");
                    return newStr;
                case 3:
                    newStr = Regex.Replace(inputStr, @"\*(.*)", "<li>$1</li>");
                    return newStr;
                case 4:
                    newStr = Regex.Replace(inputStr, @"######(.*)", "<h6>$1</h6>");
                    return newStr; ;
                case 5:
                    newStr = Regex.Replace(inputStr, @"#####(.*)", "<h5>$1</h5>");
                    return newStr;
                case 6:
                    newStr = Regex.Replace(inputStr, @"####(.*)", "<h4>$1</h4>");
                    return newStr;
                case 7:
                    newStr = Regex.Replace(inputStr, @"###(.*)", "<h3>$1</h3>");
                    return newStr;
                case 8:
                    newStr = Regex.Replace(inputStr, @"##(.*)", "<h2>$1</h2>");
                    return newStr;
                case 9:
                    newStr = Regex.Replace(inputStr, @"#(.*)", "<h1>$1</h1>");
                    return newStr;                
                case 10:
                    newStr = Regex.Replace(inputStr, @"'(.*)'", "<code>$1</code>");
                    return newStr;
            }
            return "";
        }
        public static void Main()
        {
            ReadFromFile();
            string[] newArr = Replace();
            foreach (string str in newArr)
                Console.WriteLine(str);
        }
    }
}