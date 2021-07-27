using System;

namespace DSComp
{
    public class SymbolTableEntry
    {
        public string Type { get; set; }
        public string Identifier { get; set; }
        public string MetaData { get; set; }

        public SymbolTable Scope { get; private set; } = new SymbolTable();

        public Guid Guid = Guid.NewGuid();
    }
}
