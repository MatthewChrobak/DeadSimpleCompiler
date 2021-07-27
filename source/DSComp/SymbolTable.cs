using System;
using System.Collections.Generic;
using System.Linq;

namespace DSComp
{
    public class SymbolTable
    {
        public readonly List<SymbolTableEntry> Entries = new List<SymbolTableEntry>();

        public SymbolTable() {
        }

        public SymbolTableEntry CreateUnique(string type, string identifier) {

            if (Exists(type, identifier)) {
                Console.WriteLine("The {type} {content} already exists in this scope");
                return Get(type, identifier);
            }

            return Create(type, identifier);
        }

        public SymbolTableEntry Create(string type, string identifier) {
            var entry = new SymbolTableEntry()
            {
                Identifier = identifier,
                Type = type
            };
            this.Entries.Add(entry);
            return entry;
        }

        public SymbolTableEntry Get(Guid guid) {
            return this.Entries.Single(entry => entry.Guid == guid);
        }

        public SymbolTableEntry CreateUnique(string type, string identifier, string meta) {

            if (Exists(type, identifier, meta)) {
                Console.WriteLine("The {type} {content} already exists in this scope");
                return Get(type, identifier, meta);
            }

            return Create(type, identifier, meta);
        }

        public SymbolTableEntry Create(string type, string identifier, string meta) {
            var entry = new SymbolTableEntry()
            {
                Identifier = identifier,
                Type = type,
                MetaData = meta
            };
            this.Entries.Add(entry);
            return entry;
        }

        public SymbolTableEntry Get(string type, string identifier, string meta) {
            return this.Entries.Single(entry => entry.Type == type && entry.Identifier == identifier);
        }

        public SymbolTableEntry Get(string type, string identifier) {
            return this.Entries.Single(entry => entry.Type == type && entry.Identifier == identifier);
        }

        public SymbolTableEntry Get(string identifier) {
            return this.Entries.Single(entry => entry.Identifier == identifier);
        }

        public bool Exists(string type, string identifier, string meta) {
            return this.Entries.Any(entry => entry.Type == type && entry.Identifier == identifier && entry.MetaData == meta);
        }

        public bool Exists(string type, string identifier) {
            return this.Entries.Any(entry => entry.Type == type && entry.Identifier == identifier);
        }
    }
}