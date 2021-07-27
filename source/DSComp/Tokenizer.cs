using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DSComp
{
    public class Tokenizer
    {
        private int _scanPtr;
        private readonly string _fileContent;
        private bool EOF => _scanPtr >= _fileContent.Length;

        private readonly string[] Digit = Range('0', '9');
        private readonly string[] Whitespace = ToArray(" ", "\t", "\0", "\r", "\n");
        private readonly string[] Letter = Range('a', 'z').Union(Range('A', 'Z')).ToArray();

        public Tokenizer(FileInfo fi) {
            this._scanPtr = 0;
            this._fileContent = File.ReadAllText(fi.FullName);
        }

        public Queue<Token> GetTokenStream() {
            var tokenStream = new Queue<Token>();

            while (!EOF) {
                // If whitespace, do nothing.
                if (Match(Whitespace, out var _))
                    continue;

                // Open, close parenthesis
                if (Match("(")) {
                    tokenStream.Enqueue(new Token("("));
                    continue;
                }
                if (Match(")")) {
                    tokenStream.Enqueue(new Token(")"));
                    continue;
                }
                if (Match("{")) {
                    tokenStream.Enqueue(new Token("{"));
                    continue;
                }
                if (Match("}")) {
                    tokenStream.Enqueue(new Token("}"));
                    continue;
                }

                if (Match(";")) {
                    tokenStream.Enqueue(new Token(";"));
                    continue;
                }

                // Dynamic content
                var token = new Token();

                // Integer
                while (Match(Digit, out var digit)) {
                    token.Content += digit;
                }
                if (token.HasContent) {
                    token.Type = "int";
                    tokenStream.Enqueue(token);
                    continue;
                }

                // Identifier
                while (Match(Letter, out var letter)) {
                    token.Content += letter;
                }
                if (token.HasContent) {
                    token.Type = "id";
                    tokenStream.Enqueue(token);
                    continue;
                }

                token = new Token()
                {
                    Type = "Unknown",
                    Content = this._fileContent[_scanPtr++].ToString()
                };
                tokenStream.Enqueue(token);
            }

            return tokenStream;
        }

        private void IncrementPtr(string? match) {
            this._scanPtr += match?.Length ?? 0;
        }

        private bool Match(string lookahead) {
            if (this._scanPtr + lookahead.Length > this._fileContent.Length)
                return false;
            var hasMatch = this._fileContent.Substring(this._scanPtr, lookahead.Length) == lookahead;
            if (hasMatch) {
                IncrementPtr(lookahead);
            }
            return hasMatch;
        }

        private bool Match(string[] possibilities, out string? match) {
            foreach (var possibility in possibilities) {
                if (Match(possibility)) {
                    match = possibility;
                    return true;
                }
            }
            match = null;
            return false;
        }

        private static string[] Range(char v1, char v2) {
            var lst = new List<string>();
            for (int i = v1; i <= v2; i++) {
                lst.Add($"{(char)i}");
            }
            return lst.ToArray();
        }

        private static string[] ToArray(params string[] values) => values;
    }
}
