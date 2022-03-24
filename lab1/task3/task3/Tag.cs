
namespace task3
{
    struct Tag
    {
        private string html;
        private string md;
        private bool isSingle;

        public Tag(string md, string html, bool isSingle)
        {
            this.md = md;
            this.html = html;
            this.isSingle = isSingle;
        }

        public string HTML { get { return html; } }
        public string MD { get { return md; } }
        public bool IsSingle { get { return isSingle; } }
    }
}
