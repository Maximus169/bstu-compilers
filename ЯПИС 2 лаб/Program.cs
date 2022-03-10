//2.Таблица организуется в виде списка, упорядоченного в алфавитном порядке.
//    Поиск - логарифмический. 
//    Подсчитывается число сравнений: в среднем и для каждого идентификатора. 

namespace ЯПИС_2_лаб
{
    public class Programm
    {
        internal static List<string> list = FileWork.GetListFromFile();

        public static void Add(string word)
        {
            list.Insert(LogFindForAdding(word), word);
        }

        private static int LogFindForAdding(string word)
        {
            int left = 0;
            int right = list.Count - 1;
            var comparisonResultL = list[left].CompareTo(word);
            var comparisonResultR = list[right].CompareTo(word);

            if (comparisonResultL > 0)
                return 0;
            if (comparisonResultR < 0)
                return list.Count;

            while (true)
            {
                if (right - left == 1)
                {
                    return right;
                }
                else
                {
                    var middle = left + (right - left) / 2;
                    var comparisonResult = list[middle].CompareTo(word);
                    if (comparisonResult == 0)
                        return middle;
                    if (comparisonResult < 0)
                        left = middle ;
                    if (comparisonResult > 0)
                        right = middle;
                }
            }
        }

        public static int LogFind(string word, ref int[] count)
        {            
            int left = 0;
            int right = list.Count - 1;
            while (true)
            {
                if (right - left == 1)
                {
                    if (list[left].CompareTo(word) == 0)
                    {
                        count[left]++;
                        return left;
                    }
                    if (list[right].CompareTo(word) == 0)
                    {
                        count[left]++;
                        return right;
                    }
                    return -1;
                }
                else
                {
                    var middle = left + (right - left) / 2;
                    var comparisonResult = list[middle].CompareTo(word);
                    count[middle]++;
                    if (comparisonResult == 0)
                    {
                        count[middle]++;
                        return middle;
                    }
                    if (comparisonResult < 0)
                        left = middle;
                    if (comparisonResult > 0)
                        right = middle;
                }
            }
        }

        public static bool Menu()
        {
            Console.WriteLine();
            Console.WriteLine("---Menu---");
            Console.WriteLine("1. Show elements");
            Console.WriteLine("2. Find element");
            Console.WriteLine("3. Add element");
            Console.WriteLine("4. Exit");
            int i = int.Parse(Console.ReadLine());
            switch (--i)
            {
                case 0:
                    foreach (var item in list)
                        Console.WriteLine(item);
                    return true;
                case 1:                    
                    int[] count = new int[list.Count];

                    Console.WriteLine("Enter a string");
                    string find = Console.ReadLine();

                    double sum = 0.00;
                    Console.WriteLine($"Finding index: {find} Finded number: {LogFind(find, ref count)}");
                    Console.WriteLine();
                    Console.WriteLine("Number of comparisons for each element:");
                    for (int j = 0; j < list.Count; j++)
                    {
                        sum += count[j];
                        Console.WriteLine($"Element's number: {j}\tCount: {count[j]}");
                    }
                    Console.WriteLine($"Average number of comparisons = {sum / list.Count}");
                    return true;

                case 2:
                    Console.WriteLine("Enter a string");
                    string add = Console.ReadLine();
                    Add(add);
                    return true;

                case 3:
                    return false;

                default:
                    Console.WriteLine("Incorrect data");
                    return true;
            }
        }
           
        public static void Main()
        {            
            while (Menu())
            {
            }
        }

    }
}