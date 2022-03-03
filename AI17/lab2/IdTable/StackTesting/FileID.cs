using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTesting
{
    internal class FileID
    {
        public void WriteID(string ids)
        {
            using (FileStream fstream = new FileStream(@"C:\WorkPlace\University-3-6\labs\LPIS\bstu-compilers\AI17\lab2\IdTable\IdTable\bin\Debug\net6.0\overIds.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(ids);
                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
