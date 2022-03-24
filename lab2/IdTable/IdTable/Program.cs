using IdTable;

IDFile iDFile = new IDFile();

//the file for standard working
string path = @"ids.txt";

//идентификаторы
string[] ids = iDFile.getString(path);

//таблица указателей
uint hTableSize = (uint)(ids.Length);
ID[] hTable = new ID[hTableSize];

//таблица идентификаторов
List<ID> idTable = new List<ID>();
idTable.Add(new ID());

int freePtr = 0;

//хеш функция
uint hFunc(string id)
{
    return (uint) (id[0] + id[1]) % hTableSize;
}

void fill(ID hTable, ID idTable)
{    
    ID temp = hTable.putID(idTable);
    while (!ID.check)
    {
        temp = temp.putID(idTable);
    }
}

int collisionCount = 0;

//заполнение таблиц
foreach (var item in ids)
{
    int index = (int)hFunc(item);
    if (hTable[index] == null)
    {
        idTable[freePtr].name = item;
        hTable[index] = idTable[freePtr];
        idTable.Add(new ID());
        freePtr++;
    }
    else
    {
        idTable[freePtr].name = item;
        if (hTable[index].name == idTable[freePtr].name)
        {
            Console.WriteLine($"Обнаружено повторение идентификатора!\n{hTable[index].name} == {idTable[index].name}");
            continue;
        }

        fill(hTable[index], idTable[freePtr]);

        idTable.Add(new ID());
        freePtr++;
        collisionCount++;
    }
}

Console.WriteLine($"comparisonCount: { collisionCount + hTableSize }, middlevalue: { (collisionCount + hTableSize) / (double) hTableSize }");


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
    else if (ht.name == id)
    {
        Console.WriteLine($"Was found!:\nName: {ht.name} \nComparisons: {counter + 1}");
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