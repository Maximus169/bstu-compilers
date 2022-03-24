
namespace IdTable
{
    internal class IDFile
    {
        public string[] getString(string path)
        {
            using (FileStream fstream = File.OpenRead($"{path}"))
            {
                string text;
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                text = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {text}");
                return text.Split(" ");
            }
        }
    }
}
