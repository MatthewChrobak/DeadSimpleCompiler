using System;

namespace DSComp.Nodes
{
    public class FunctionNode : Node
    {
        public readonly string FunctionName;
        public Guid SymbolTableGuid;

        public FunctionNode(Token token) {
            this.Content = token.Content;
            this.FunctionName = token.Content;
        }
    }
}