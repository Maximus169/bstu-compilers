namespace LexicalAnalysis
{
    public class LexemeTable
    {
        public string lexeme;
        public string lexemeType;
        public string value;
        public LexemeTable(string lexeme, string lexemeType, string value)
        {
            this.value = value;
            this.lexeme = lexeme;
            this.lexemeType = lexemeType;
        }
    }
}
