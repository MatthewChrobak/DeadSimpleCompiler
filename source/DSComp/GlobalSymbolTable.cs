namespace DSComp
{
    public class GlobalSymbolTable : SymbolTable
    {
        public GlobalSymbolTable() {
            // Create the print statements
            this.CreateUnique("function", "Print", "int");
            this.CreateUnique("function", "Print", "id");
        }
    }
}
