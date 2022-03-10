using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_ID_Table
{
    internal class Element
    {
        public string value { get; set; }
        public string info { get; set; }

        public Element(string value, string info)
        {
            this.value = value;
            this.info = info;
        }
    }
}
