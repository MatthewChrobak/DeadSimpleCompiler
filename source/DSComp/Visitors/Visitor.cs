using DSComp.Nodes;

namespace DSComp.Visitors
{
    public class Visitor
    {
        public readonly GlobalSymbolTable Globals;

        public Visitor(GlobalSymbolTable globals) {
            this.Globals = globals;
        }

        public virtual void Visit(FunctionNode node) {

        }

        public virtual void Visit(IdNode node) {

        }

        public virtual void Visit(IntNode node) {

        }

        public virtual void Visit(RootNode node) {

        }

        public virtual void Visit(FunctionCallStatement functionCallStatement) {

        }

        public virtual void Visit(FunctionBody functionBody) {

        }

        public virtual void PreVisit(FunctionNode node) {

        }

        public virtual void PreVisit(IdNode node) {

        }

        public virtual void PreVisit(IntNode node) {

        }

        public virtual void PreVisit(RootNode node) {

        }

        public virtual void PreVisit(FunctionCallStatement functionCallStatement) {

        }

        public virtual void PreVisit(FunctionBody functionBody) {

        }
    }
}
