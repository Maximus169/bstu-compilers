namespace yapis_2
{
    public class Identifier
    {
        public string value { get; set; }
        public string info { get; set; }
        public int id { get; }
        public Identifier parent { get; set; }
        public Identifier leftChild { get; set; }
        public Identifier rightChild { get; set; }
        public string inheritor { get; set; }

        public Identifier(string value, string info, int id)
        {
            this.value = value;
            this.info = info;
            parent = null;
            leftChild = null;
            rightChild = null;
            this.id = id;
        }

    }
}
