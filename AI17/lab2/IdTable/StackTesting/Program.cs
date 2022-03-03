using StackTesting;

string f = "f";
string ids = f;
int alphSize = 26;



for (int i = 0; i < alphSize/4; i++)
{
    for (int j = 0; j < alphSize; j++)
    {
        for (int g = 0; g < alphSize; g++)
        {
            for (int h = 0; h < alphSize; h++)
            {
                ids += $" {f + (char)(97 + i % (alphSize + 1)) + (char)(97 + j % (alphSize + 1)) + (char)(97 + g % (alphSize + 1)) + (char)(97 + h % (alphSize + 1))}";
            }
        }
    }
}


FileID file = new FileID();

file.WriteID(ids);