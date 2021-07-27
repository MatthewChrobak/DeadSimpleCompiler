namespace DSComp
{
    public class Token
    {
        public string Type { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool HasContent => Content.Length != 0;

        public Token(string typeAndContent) {
            this.Type = typeAndContent;
            this.Content = typeAndContent;
        }

        public Token() {
        }
    }
}