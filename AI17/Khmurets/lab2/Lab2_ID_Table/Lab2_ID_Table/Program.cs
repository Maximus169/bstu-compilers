using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_ID_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Identificators from file:\n");
            IdentTable idTable = new IdentTable();
            while(Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.WriteLine("\nChoose:\n1 - Search\n2 - Add");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        SearchElement(ref idTable);
                        break;

                    case ConsoleKey.D2:
                        AddElement(ref idTable);
                        break;

                    default:
                        Console.WriteLine("\nWrong entry! For exit press 'Esc' button!\n");
                        break;
                }
            }
        }

        static void SearchElement(ref IdentTable idTable)
        {
            Console.Write("\nEnter the value to search: ");
            string id = Console.ReadLine();
            int iterator = idTable.Search(id.ToUpper());
            if (iterator != -1)
            {
                idTable.ShowElement(iterator);
            }
            else
            {
                Console.WriteLine("None of elements were found");
            }
        }

        static void AddElement(ref IdentTable idTable)
        {
            Console.Write("\nEnter the identificator value: ");
            string val = Console.ReadLine();
            Console.Write("\nEnter the identificator info: ");
            string info = Console.ReadLine();
            idTable.Add(val, info);
        }
    }
}
