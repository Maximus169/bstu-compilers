
using LexicalAnalysis;
using System.Text.RegularExpressions;

string text;
string path = "code.txt";
using (StreamReader reader = new StreamReader(path))
{
    text = await reader.ReadToEndAsync();
    Console.WriteLine("> Text of code:");
    Console.WriteLine(text);
}
List<string> words = new List<string>(text.Split());
words.RemoveAll(name =>
{
    if (name.Equals(""))
        return true;
    else
        return false;
});
List<LexicalTable> table = new List<LexicalTable>();

//Заполнение таблицы лексем
int idKW = 0, idID = 0;
foreach (var item in words)
{
    if (item.IndexOf("\"") != -1)
    {
        table.Add(new LexicalTable(item, "Строковая константа", item));
        idKW++;
    }
    else if (item.IndexOf("\'") != -1)
    {
        table.Add(new LexicalTable(item, "Символьная константа", item));
    }
    else if (item == ":=")
    {
        table.Add(new LexicalTable(item, "Знак присваивания", " "));
    }
    else if(item == "+")
    {
        table.Add(new LexicalTable(item, "Знак арифметической операции", " "));
    }
    else if (item == ";")
    {
        table.Add(new LexicalTable(item, "Ключевое слово", $"X{idKW}"));
        idKW++;
    }
    else
    {
        bool flag = false;
        string id = "";
        foreach (var element in table)
        {
            if (item == element.lexeme)
            {
                flag = true;
                id = element.value;
                break;
            }
        }
        if (flag)
            table.Add(new LexicalTable(item, "Идентификатор", id));
        else
        {
            idID++;
            table.Add(new LexicalTable(item, "Идентификатор", $"{item} : {idID}"));
        }
    }
}

Console.WriteLine("\n> the table:\nLexeme\tType\t\t\tValue");
foreach (var item in table)
{
    Console.WriteLine($"{item.lexeme}\t{item.lexemeType}\t\t{item.value}");
}

Console.ReadLine();