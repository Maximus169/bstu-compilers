using IdTable;
using System.Security.Cryptography;

IDFile iDFile = new IDFile();
string path = @"ids.txt";

//идентификаторы
string[] ids = iDFile.getString(path);

//хеш таблица
uint hTableSize = (uint)(ids.Length);
ID[] hTable = new ID[hTableSize];

//таблица идентификаторов + info
List<ID> idTable = new List<ID>();
idTable.Add(new ID());

int freePtr = 0;

//хеш функция
//uint hFunc(string id)
//{
//    SHA256 hash = SHA256.Create();
//    return BitConverter.ToUInt32(hash.ComputeHash(System.Text.Encoding.Default.GetBytes(id))) % hTableSize;
//}

uint hFunc(string id)
{
    return id[0] % hTableSize;
}

int collCount = 0;

//заполнение таблиц
foreach (var item in ids)
{
    int index = (int)hFunc(item);
    //Console.WriteLine(index);
    if (hTable[index] == null)
    {
        idTable[freePtr].Name = item;
        idTable[freePtr].Info = " ";
        hTable[index] = idTable[freePtr];
        idTable.Add(new ID());
        freePtr++;
    }
    else
    {
        idTable[freePtr].Name = item;
        idTable[freePtr].Info = " ";
        if (hTable[index].Name == idTable[freePtr].Name)
        {
            Console.WriteLine($"!(ACHTUNG)! == WARNING! id repeat == !(!ACHTUNG!)!\n{hTable[index].Name} == {idTable[index].Name}");
            continue;
        }
        hTable[index].putID(idTable[freePtr]);
        idTable.Add(new ID());
        freePtr++;
        collCount++;
    }
}

Console.WriteLine($"Collision number: {collCount}");


void findID(ID[] ht, string id)
{
    int index = (int)hFunc(id);
    if (ht[index] == null)
    {
        Console.WriteLine("Not found!");
        return;
    }
    else
    {
        recFindID(ht[index], id);
    }
}

void recFindID(ID ht, string id)
{
    if (ht == null)
    {
        Console.WriteLine("Not found!");
        return;
    }
    else if (ht.Name == id)
    {
        Console.WriteLine($"Was found!:\nName: {ht.Name}\nInfo: {ht.Info}");
        return;
    }
    else
    {
        recFindID(ht.getID(), id);
    }
}

while (true)
{
    string input = Console.ReadLine();
    findID(hTable, input);
}