
namespace IdTable
{
    internal class ID
    {
        public static bool check;
        private static uint counter;
        private const uint MAX_COUNT = 9999;
        public string name;
        
        private ID nextID;
        public ID putID(ID nextID)
        {
            if (this.nextID == null)
            {
                this.nextID = nextID;
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
