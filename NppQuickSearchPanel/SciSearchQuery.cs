using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NppQuickSearchPanel
{
    class SciSearchQuery : SearchQuery
    {

        public SciSearchQuery(Entry entry, SearchParameters par) : base(entry, par) { }

        override public SearchResult SearchForward()
        {
            int pos = -1, line = -1;
            using (Scintilla sci = new Scintilla())
            {
                pos = sci.SearchForward(
                    entry.ToString(),
                    entry.Type == KeywordsType.RegExp,
                    par.MatchWord,
                    par.MatchCase,
                    par.WrapSearch);
                line = sci.GetLineFromPosition(pos);
            }
            return new SearchResult(pos, line);
        }

        override public SearchResult SearchBackward()
        {
            int pos = -1, line = -1;
            using (Scintilla sci = new Scintilla())
            {
                pos = sci.SearchBackward(
                    entry.ToString(),
                    entry.Type == KeywordsType.RegExp,
                    par.MatchWord,
                    par.MatchCase,
                    par.WrapSearch);
                line = sci.GetLineFromPosition(pos);
            }
            return new SearchResult(pos, line);
        }
    }
}
