using DSComp.Visitors;

namespace DSComp.Nodes
{
    public interface IVisitable
    {
        void Accept(Visitor visitor);
    }
}
