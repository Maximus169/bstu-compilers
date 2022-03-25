using System.Text.RegularExpressions;

public class Analization
{
    public string GetType(List<string> RomeList, int i)
    {
        if (new Regex(@"^[XVI]\w*$").IsMatch(RomeList[i]))
        {
            return "римское число";
        }
        else if (new Regex("^(-|/|[*]|[+])$").IsMatch(RomeList[i]))
        {
            return "знак операции";
        }
        else if (new Regex(@"^[(]|[)]$").IsMatch(RomeList[i]))
        {
            return "скобка";
        }
        else if (new Regex("^;$").IsMatch(RomeList[i]))
        {
            return "окончание команды";
        }
        else if (new Regex("^=$").IsMatch(RomeList[i]))
        {
            return "оператор присваивания";
        }
        else if (new Regex(@"^[a-zA-Z]\w*$").IsMatch(RomeList[i]))
        {
            return "идентификатор";
        }
        else
        {
            return "";
        }
    }
}
