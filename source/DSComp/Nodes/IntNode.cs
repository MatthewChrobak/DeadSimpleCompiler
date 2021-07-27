namespace DSComp.Nodes
{
    public class IntNode : Node
    {
        public IntNode(Token num) {
            this.Content = num.Content;
        }
    }
}