using DSComp.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSComp
{
    public class Parser
    {
        private Queue<Token> _tokenStream;

        public Parser(Queue<Token> tokenStream) {
            this._tokenStream = tokenStream;
        }

        internal RootNode GetRoot() {
            var programNode = new RootNode();

            while (this._tokenStream.Any()) {
                if (GetFunctionNode(out var function)) {
                    programNode.Children.Add(function);
                }
            }

            return programNode;
        }

        private bool GetFunctionNode(out FunctionNode function) {

            // Just lines of PRINT
            if (Lookahead("id", out var functionName)) {
                function = new FunctionNode(functionName);

                if (Lookahead("(", ")")) {
                    if (GetFunctionBody(out var functionBody)) {
                        function.Children.Add(functionBody);
                        return true;
                    }
                }
            }

            Console.WriteLine("Failed to get function node");
            function = null;
            return false;
        }

        private bool GetFunctionBody(out FunctionBody functionBody) {
            functionBody = new FunctionBody();

            if (Lookahead("{")) {

                while (GetFunctionStatement(out var statement)) {
                    functionBody.Children.Add(statement);
                }

                // Make sure we close the function block
                if (Lookahead("}")) {
                    return true;
                }
            }

            Console.WriteLine("Failed to get function body");
            return false;
        }

        private bool GetFunctionStatement(out StatementNode statement) {
            if (Lookahead("id", out var functionName)) {
                statement = new FunctionCallStatement(functionName);
                if (Lookahead("(")) {
                    if (Lookahead("id", out var id)) {
                        statement.Children.Add(new IdNode(id));
                    }
                    else if (Lookahead("int", out var num)) {
                        statement.Children.Add(new IntNode(num));
                    }
                    else {
                        // No params
                    }

                    if (Lookahead(")", ";")) {
                        return true;
                    }
                }
            }

            Console.WriteLine("Failed to get function statement");
            statement = null;
            return false;
        }

        private bool Lookahead(params string[] lookaheads) {
            for (int i = 0; i < lookaheads.Length; i++) {
                if (!Lookahead(lookaheads[i])) {
                    return false;
                }
            }
            return true;
        }

        private bool Lookahead(string lookahead) {
            if (this._tokenStream.Peek().Type == lookahead) {
                this._tokenStream.Dequeue();
                return true;
            }
            return false;
        }

        private bool Lookahead(string lookahead, out Token token) {
            if (this._tokenStream.Peek().Type == lookahead) {
                token = this._tokenStream.Dequeue();
                return true;
            }
            token = new Token();
            return false;
        }
    }
}