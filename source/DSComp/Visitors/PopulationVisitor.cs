using DSComp.Nodes;
using System;
using System.Linq;

namespace DSComp.Visitors
{
    public class PopulationVisitor : Visitor
    {
        private SymbolTable CurrentScope;

        public PopulationVisitor(GlobalSymbolTable globals) : base(globals) {
            this.CurrentScope = globals;
        }

        public override void PreVisit(FunctionNode node) {
            var function = this.Globals.CreateUnique("function", node.Content);
            node.SymbolTableGuid = function.Guid;
            CurrentScope = function.Scope;
        }

        public override void Visit(FunctionNode node) {
            CurrentScope = this.Globals;
        }

        public override void PreVisit(FunctionCallStatement functionCallStatement) {
            // We can guarentee that these must be valid because of the syntactic analysis.
            // Also, there can only be one arg for now. But in the future, this might be handy.
            var args = string.Join(',', functionCallStatement.Children.Select(node => node.Content));

            if (!this.Globals.Exists("function", functionCallStatement.FunctionName)) {
                Console.WriteLine($"The function {functionCallStatement.FunctionName} doesn't exist");
                return;
            }
            if (this.Globals.Exists("function", functionCallStatement.FunctionName, args)) {
                Console.WriteLine($"No function {functionCallStatement.FunctionName} exists that can take in {args}");
                return;
            }
            functionCallStatement.SymbolTableGuid = CurrentScope.Create("fcall", functionCallStatement.FunctionName, args).Guid;
        }
    }
}
