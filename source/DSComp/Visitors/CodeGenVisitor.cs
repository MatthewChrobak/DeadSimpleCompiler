using DSComp.Nodes;

namespace DSComp.Visitors
{
    public class CodeGenVisitor : Visitor
    {
        private readonly CodeOutput _codeOutput;
        private SymbolTable CurrentScope;

        public CodeGenVisitor(GlobalSymbolTable globals, CodeOutput codeOutput) : base(globals) {
            this._codeOutput = codeOutput;
            this.CurrentScope = globals;
        }

        public override void PreVisit(RootNode node) {
            this._codeOutput.AddLine("#include <stdio.h>");
            this._codeOutput.AddLine("void PrintStr(const char* value) { printf(\"%s\", value); }");
            this._codeOutput.AddLine("void PrintInt(int value) { printf(\"%d\", value); }");
        }

        public override void PreVisit(FunctionNode function) {
            var functionName = function.FunctionName;

            this._codeOutput.AddLine($"void {functionName}() {{");
            this._codeOutput.IncreaseIndent();

            this.CurrentScope = CurrentScope.Get(function.SymbolTableGuid).Scope;
        }

        public override void Visit(FunctionNode node) {
            this._codeOutput.DecreaseIndent();
            this._codeOutput.AddLine("}");

            this.CurrentScope = this.Globals;
        }

        public override void Visit(FunctionCallStatement functionCallStatement) {
            var entry = this.CurrentScope.Get(functionCallStatement.SymbolTableGuid);

            var args = entry.MetaData;
            var fname = entry.Identifier;

            if (args.Length != 0) {
                if (int.TryParse(args, out var _)) {
                    // Good format for args.
                    fname = "PrintInt";
                }
                else {
                    // Otherwise, assume string
                    fname = "PrintStr";
                    args = $"\"{args}\"";
                }
            }

            this._codeOutput.AddLine($"{fname}({args});");
        }
    }
}
