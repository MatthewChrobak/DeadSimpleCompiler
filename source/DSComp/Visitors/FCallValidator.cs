using DSComp.Nodes;
using System;

namespace DSComp.Visitors
{
    public class FCallValidator : Visitor
    {
        public FCallValidator(GlobalSymbolTable globals) : base(globals) {
        }

        public override void Visit(FunctionCallStatement functionCallStatement) {
           
        }
    }
}
