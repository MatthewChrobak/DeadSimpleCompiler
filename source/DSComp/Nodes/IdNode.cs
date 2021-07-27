namespace DSComp.Nodes
{
    public class IdNode : Node
    {
        public IdNode(Token id) {
            this.Content = id.Content;
        }
    }
}