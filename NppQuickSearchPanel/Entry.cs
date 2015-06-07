using System;
using System.Collections.Generic;
using System.Text;

namespace NppQuickSearchPanel
{
    public enum KeywordsType { Normal, RegExp };

    [Serializable]
    public class Entry : IEquatable<Entry>
    {
        public string Keywords { get; set; }
        public KeywordsType Type { get; set; }

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

        public bool Equals(Entry other)
        {
            if ((this.Keywords == other.Keywords) && (this.Type == other.Type))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int hashKeywords = Keywords.GetHashCode();
            int hashType = Type.GetHashCode();
            return hashKeywords ^ hashType;
        }
    }
}
