namespace ЯПИС_2_лаб
{
    internal static class FileWork
    {
        internal static List<string> GetListFromFile()
        {
            List<string> list = new List<string>(); 
            string path = @"Data.txt";
            StreamReader sr = new StreamReader(path);
            string file_text = sr.ReadToEnd();
            sr.Close();

            string[] lines = file_text.Split();
            Array.Sort(lines);  
            foreach (string line in lines)
                list.Add(line);
            return list;
        }
    }
}
