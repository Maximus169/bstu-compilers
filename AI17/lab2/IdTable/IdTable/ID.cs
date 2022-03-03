using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdTable
{
    internal class ID
    {
        public static bool check;
        private static uint counter;
        private const uint MAX_COUNT = 9999;
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string info;
        public string Info
        {
            get { return info; }
            set { info = value; }
        }
        private ID nextID;
        public ID putID(ID nextID)
        {
            if (this.nextID == null)
            {
                this.nextID = nextID;
                this.nextID.info = "";
                check = true;
                counter = 0;
                return nextID;
            }
            else
            {
                if (counter == MAX_COUNT)
                {
                    counter = 0;
                    return this.nextID;
                }
                else
                {
                    counter++;
                    check = false;
                    return this.nextID.putID(nextID);
                }
            }
        }
        public ref ID getID()
        {
            return ref nextID;
        }
    }
}
