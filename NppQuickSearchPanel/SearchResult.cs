using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NppQuickSearchPanel
{
    class SearchResult
    {
        public int Position { get; set; }
        public int LineNumber { get; set; }

        public SearchResult(int position, int lineNumber)
        {
            this.Position = position;
            this.LineNumber = lineNumber;
        }
    }
}
