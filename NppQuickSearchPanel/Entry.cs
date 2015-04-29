using System;
using System.Collections.Generic;
using System.Text;

namespace NppQuickSearchPanel
{
    public enum KeywordsType { Normal, RegExp };

    [Serializable]
    public class Entry
    {
        public Entry(string keywords, KeywordsType type)
        {
            Keywords = keywords;
            Type = type;
        }

        public Entry() {}

        public override string ToString()
        {
            return Keywords;
        }

        public string Keywords { get; set; }
        public KeywordsType Type { get; set; }
    }
}
