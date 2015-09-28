using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NppQuickSearchPanel
{
    abstract class SearchQuery
    {
        public Entry entry;
        public SearchParameters par;

        public SearchQuery() { }

        public SearchQuery(Entry entry, SearchParameters par)
        {
            this.entry = entry;
            this.par = par;
        }

        abstract public SearchResult SearchForward();
        abstract public SearchResult SearchBackward();
    }
}
