//List<string> RomeListD = FileWork.GetListFromFile();
//List<string> RomeList = RomeListD.Distinct().ToList();

FileWork file = new FileWork();
Analization analization = new Analization();    

List<string> RomeList = file.GetListFromFile(@"Data.txt");
List<string> TypeList = new List<string>();

for (int i = 0; i < RomeList.Count; i++)
{
    string tl = analization.GetType(RomeList, i);
    TypeList.Add(tl);
}

RomeList.RemoveAt(0);
TypeList.RemoveAt(0);

for (int i = 0; i < RomeList.Count; i++)
{
    Console.WriteLine($"Rome: {RomeList[i], 10}    Type: {TypeList[i], 25}");
}
