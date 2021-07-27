using DSComp.Visitors;
using System;
using System.Collections.Generic;

namespace DSComp.Nodes
{
    public abstract class Node : IVisitable
    {
        public List<Node> Children { get; private set; } = new List<Node>();
        public string Content { get; set; } = string.Empty;

        public void Accept(Visitor visitor) {
            ApplyPreVisit(visitor, this);

            foreach (var child in this.Children) {
                child.Accept(visitor);
            }

            ApplyVisitor(visitor, this);
        }

        private static void ApplyVisitor(Visitor visitor, Node node) {
            switch (node) {
                case RootNode rootNode:
                    visitor.Visit(rootNode);
                    break;
                case FunctionBody functionBody:
                    visitor.Visit(functionBody);
                    break;
                case FunctionCallStatement functionCallStatement:
                    visitor.Visit(functionCallStatement);
                    break;
                case FunctionNode functionNode:
                    visitor.Visit(functionNode);
                    break;
                case IdNode idNode:
                    visitor.Visit(idNode);
                    break;
                case IntNode intNode:
                    visitor.Visit(intNode);
                    break;
                default:
                    Console.WriteLine($"Unknown type: {node.GetType()}");
                    break;
            };
        }

        private static void ApplyPreVisit(Visitor visitor, Node node) {
            switch (node) {
                case RootNode rootNode:
                    visitor.PreVisit(rootNode);
                    break;
                case FunctionBody functionBody:
                    visitor.PreVisit(functionBody);
                    break;
                case FunctionCallStatement functionCallStatement:
                    visitor.PreVisit(functionCallStatement);
                    break;
                case FunctionNode functionNode:
                    visitor.PreVisit(functionNode);
                    break;
                case IdNode idNode:
                    visitor.PreVisit(idNode);
                    break;
                case IntNode intNode:
                    visitor.PreVisit(intNode);
                    break;
                default:
                    Console.WriteLine($"Unknown type: {node.GetType()}");
                    break;
            };
        }
    }
}
