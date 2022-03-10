using System.Text.RegularExpressions;

var words = new HashSet<string>();
string text = "Тут есть повторения. Тут ничего нет.";
Console.WriteLine(text);
text = Regex.Replace(text, "\\w+", m =>
                     words.Add(m.Value.ToUpperInvariant())
                         ? m.Value
                         : "**" + m.Value + "**");
Console.WriteLine(text);    