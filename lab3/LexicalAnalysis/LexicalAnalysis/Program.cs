
using LexicalAnalysis;

//путь до файла с кодом
string path = "code.txt";

//считывание и вывод на консоль кода с файла
StreamReader reader = new StreamReader(path);
string text = await reader.ReadToEndAsync();
Console.WriteLine($"Code:\n{text}");

//разбиение текста на лексемы с удалением излишка
List<string> lexemes = new List<string>(text.Split());
lexemes.RemoveAll(lexeme =>
{
    if (lexeme.Equals(""))
        return true;
    else
        return false;
});

//создание таблицы лексем
List<LexemeTable> table = new List<LexemeTable>();

//Заполнение таблицы лексем
int idKW = 0, idID = 0;
foreach (var lexeme in lexemes)
{
    if (lexeme.IndexOf("[") != -1)
    {
        string[] temp = lexeme.Substring(1, lexeme.Length - 2).Split(".");

        table.Add(new LexemeTable(lexeme, $"Диапазон массива: от {temp[0]} до {temp[temp.Length-1]}", $"{temp[0]}, {temp[temp.Length - 1]}"));
    }
    else if(lexeme == "integer" || lexeme == "real" || lexeme == "byte" || lexeme == "word" || lexeme == "char")
    {
        table.Add(new LexemeTable(lexeme, "Тип Массива", lexeme));
    }
    else if (lexeme == ";" || lexeme == ":" || lexeme == "of" || lexeme == "array")
    {
        table.Add(new LexemeTable(lexeme, "Ключевое слово", $"X{idKW}"));
        idKW++;
    }
    else
    {
        bool flag = false;
        foreach (var element in table)
        {
            if (lexeme == element.lexeme)
            {
                flag = true;
                table.Add(new LexemeTable(lexeme, "Идентификатор", element.value));
                break;
            }
        }
        if (!flag) { 
            idID++;
            table.Add(new LexemeTable(lexeme, "Идентификатор", $"{lexeme} : {idID}"));
        }
    }
}

Console.WriteLine("\nTable:\nLexeme\tType\t\t\t\tValue");
foreach (var lexeme in table)
{
    Console.WriteLine($"{lexeme.lexeme}\t{lexeme.lexemeType}\t\t\t{lexeme.value}");
}
