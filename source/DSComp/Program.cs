using DSComp.Visitors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DSComp
{
    class Program
    {
        static void Main(string[] args) {
            var file = "source.dss";
            var fi = new FileInfo(file);

            // Lexical
            var tokenStream = new Tokenizer(fi).GetTokenStream();
            Print(tokenStream);

            // Syntax
            var root = new Parser(tokenStream).GetRoot();

            // Semantics
            var globalSymbolTable = new GlobalSymbolTable();
            root.Accept(new PopulationVisitor(globalSymbolTable));
            root.Accept(new IntegerVisitor(globalSymbolTable));
            root.Accept(new FCallValidator(globalSymbolTable));
            Console.WriteLine("\r\n\r\n[SYMBOL TABLES]");
            Print(globalSymbolTable);

            // Codegen
            var codeOutput = new CodeOutput();
            root.Accept(new CodeGenVisitor(globalSymbolTable, codeOutput));

            string outputFilePath = "source.c";
            File.WriteAllLines(outputFilePath, codeOutput.Lines);
        }

        private static void Print(SymbolTable symbolTable, int indentationLevel = 0) {
            if (!symbolTable.Entries.Any()) {
                return;
            }
            string indent = new string('\t', indentationLevel);
            string bars = new string('=', indentationLevel + 20);
            Console.WriteLine($"{indent}{bars}");
            Console.WriteLine($"{indent}[TYPE] - [IDENTIFIER] - [META DATA]");

            foreach (var entry in symbolTable.Entries) {
                Console.WriteLine($"{indent}{entry.Type} - {entry.Identifier} - {entry.MetaData}");
                Print(entry.Scope, indentationLevel + 1);
            }
            Console.WriteLine($"{indent}{bars}");
        }

        private static void Print(Queue<Token> tokenStream) {
            Console.WriteLine("[TOKENS]");
            foreach (var token in tokenStream) {
                Console.WriteLine($"{{{token.Type}: {token.Content}}}");
            }
        }
    }
}
