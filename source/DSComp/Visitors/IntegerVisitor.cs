using DSComp.Nodes;
using System;

namespace DSComp.Visitors
{
    public class IntegerVisitor : Visitor
    {
        public IntegerVisitor(GlobalSymbolTable globals) : base(globals) {
        }

        public override void Visit(IntNode node) {
            if (!int.TryParse(node.Content, out var result)) {
                Console.WriteLine($"Int too big: {node.Content}");
            }
        }
    }
}
