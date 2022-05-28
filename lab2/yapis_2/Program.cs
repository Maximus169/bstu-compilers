using System;

namespace yapis_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tree table = new Tree();
            table.FillTree();
            while (true)
            {
                Console.WriteLine("1 - Show tree\n2 - Search\nAnother keys - exit\n");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        {
                            table.ShowTree();
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.Write("\nEnter the value to search: ");
                            table.Search(Console.ReadLine());
                            break;
                        }
                    default:
                        return;
                }
            }
        }
    }
}
