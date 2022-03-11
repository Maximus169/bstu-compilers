using LexicalAnalysis;
using System.Text.RegularExpressions;

string text;
string path = "code.txt";
using (StreamReader reader = new StreamReader(path))
{
    text = await reader.ReadToEndAsync();
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
Regex r = new Regex(@"\b\d+\b");

//Заполнение таблицы лексем
int idKW = 1, idID = 0;
foreach (var item in words)
{
    Match m = r.Match(item);
    if (item == "if" || item == "else" || item == "then")
    {
        table.Add(new LexicalTable(item, "Ключевое слово", $"X{idKW}"));
        idKW++;
    }
    else if (item == ":=")
    {
        table.Add(new LexicalTable(item, "Знак присваивания", " "));
    }
    else if(item == "*" || item == "+" || item == "-" || item =="/" || item == "%")
    {
        table.Add(new LexicalTable(item, "Знак арифметической операции", " "));
    }
    else if (item == "and" || item == "not" || item == "or")
    {
        table.Add(new LexicalTable(item, "Знак логической операции", " "));
    }
    else if (m.Success)
    {
        table.Add(new LexicalTable(item, "Целочисленная константа", item));
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

//Проверка введенного кода
r = new Regex(@"if\s+\w+\s+\w+\s+\w+\s+then[$\s+]*(\w+\s+:=\s+\w+(\s+\S\s+\w+)*[$\s+]*)+(else[$\s+]*\w+\s:=\s\w+(\s+\S\s+\w+)*[$\s+]*)*");
Match mat = r.Match(text);

if (!mat.Success)
{
    Console.WriteLine("Error: incorrect structure");
}
else
{
    Console.WriteLine("Code is right");
}



Console.ReadLine();

