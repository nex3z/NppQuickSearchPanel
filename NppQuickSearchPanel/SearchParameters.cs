using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NppQuickSearchPanel
{
    class SearchParameters
    {
        public bool MatchCase { get; set; }
        public bool MatchWord { get; set; }
        public bool WrapSearch { get; set; }

        public SearchParameters(bool matchCase, bool matchWord, bool wrapSearch)
        {
            this.MatchCase = matchCase;
            this.MatchWord = matchWord;
            this.WrapSearch = wrapSearch;
        }
    }
}
