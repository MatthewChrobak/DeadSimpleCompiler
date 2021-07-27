using System;

namespace DSComp.Nodes
{
    public class FunctionCallStatement : StatementNode
    {
        public readonly string FunctionName;
        public Guid SymbolTableGuid;

        public FunctionCallStatement(Token functionName) {
            this.FunctionName = functionName.Content;
        }
    }
}
