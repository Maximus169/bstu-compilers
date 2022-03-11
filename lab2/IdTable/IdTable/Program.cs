using IdTable;
using System.Security.Cryptography;

IDFile iDFile = new IDFile();

//the file for standesrt working
//string path = @"ids.txt";

//the file to raise a stack overflow exception
string path = @"overIds.txt";

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

void feel(ID hTable, ID idTable)
{    
    ID temp = hTable.putID(idTable);
    while (!ID.check)
    {
        temp = temp.putID(idTable);
    }
}

int collCount = 0;

//заполнение таблиц
foreach (var item in ids)
{
    int index = (int)hFunc(item);
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
        //version 3
        feel(hTable[index], idTable[freePtr]);

        //version 2
        //Thread tr = new Thread(() => feel(hTable[index], idTable[freePtr]), 10000000);
        //tr.Start();
        //tr.Join();

        //version 1
        //hTable[index].putID(idTable[freePtr]);
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
        ID temp = recFindID(ht[index], id);
        while (temp != null)
        {
            temp = recFindID(temp, id);
        }
    }
}

const uint MAX_COUNT = 5999;
uint counter = 0;

ID recFindID(ID ht, string id)
{
    if (ht == null)
    {
        Console.WriteLine("Not found!");
        counter = 0;
        return null;
    }
    else if (ht.Name == id)
    {
        Console.WriteLine($"Was found!:\nName: {ht.Name}\nInfo: {ht.Info}");
        counter = 0;
        return null;
    }
    else
    {
        if (counter == MAX_COUNT)
        {
            counter = 0;
            return ht.getID();
        }
        else
        {
            counter++;
            return recFindID(ht.getID(), id);
        }
    }
}

while (true)
{
    string input = Console.ReadLine();
    findID(hTable, input);
}