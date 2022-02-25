using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdTable
{
    internal class ID
    {
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
        public void putID(ID nextID)
        {
            if (this.nextID == null)
            {
                this.nextID = nextID;
                //this.nextID.info = "";
            }
            else
            {
                this.nextID.putID(nextID);
            }
        }
        public ref ID getID()
        {
            return ref nextID;
        }
    }
}
