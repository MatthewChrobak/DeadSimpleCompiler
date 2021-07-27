using System;
using System.Collections.Generic;

namespace DSComp
{
    public class CodeOutput
    {
        private int IndentationLevel = 0;

        public readonly List<string> Lines = new List<string>();

        public void IncreaseIndent() {
            IndentationLevel++;
        }

        public void DecreaseIndent() {
            IndentationLevel--;
            IndentationLevel = Math.Max(0, IndentationLevel);
        }

        public void AddLine(string line) {
            this.Lines.Add(new string('\t', IndentationLevel) + line);
        }
    }
}