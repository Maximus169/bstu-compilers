public class FileWork
{
    internal List<string> GetListFromFile(string path)
    {
        List<string> list = new List<string>();
        StreamReader sr = new StreamReader(path);
        string file_text = sr.ReadToEnd();
        sr.Close();

        string[] lines = file_text.Split();
        Array.Sort(lines);
        foreach (string line in lines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                string romenum = line[i].ToString();
                if (Char.IsLetter((line[i])) && (i < (line.Length - 1)) && (Char.IsLetter(line[i + 1])))
                {
                    while (Char.IsLetter(line[i]))
                    {
                        romenum += line[i];
                        i++;
                    }
                }
                list.Add(romenum);
            }            
        }
        return list;
    }
}

