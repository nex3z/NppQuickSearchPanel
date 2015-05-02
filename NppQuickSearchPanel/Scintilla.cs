using System;
using System.Collections.Generic;
using System.Text;
using NppPluginNET;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NppQuickSearchPanel
{
    class Scintilla : IDisposable
    {
        IntPtr curScintilla;
        bool disposed = false;

        public Scintilla() 
        {
            curScintilla = PluginBase.GetCurrentScintilla();
        }

        public int GetCurrentPos()
        {
            int currentPos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_GETCURRENTPOS, 0, 0);
            return currentPos;
        }

        public int GetAnchor()
        {
            int anchor = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_GETANCHOR, 0, 0);
            return anchor;
        }

        public void GoToPos(int pos)
        {
            Win32.SendMessage(curScintilla, SciMsg.SCI_GOTOPOS, pos, 0);
        }

        public void SetSearchAnchor()
        {
            Win32.SendMessage(curScintilla, SciMsg.SCI_SEARCHANCHOR, 0, 0);
        }

        public int GetLength()
        {
            int length = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_GETLENGTH, 0, 0);
            return length;
        }

        public void ScrollCaret()
        {
            Win32.SendMessage(curScintilla, SciMsg.SCI_SCROLLCARET, 0, 0);
        }
            
        public int SearchNext(string keywords, bool isRegExp, bool wholeWord, bool matchCase)
        {
            int flag = 0;

            if (wholeWord)
                flag += (int)SciMsg.SCFIND_WHOLEWORD;
            if (matchCase)
                flag += (int)SciMsg.SCFIND_MATCHCASE;
            if (isRegExp)
                flag += (int)SciMsg.SCFIND_REGEXP;

            int pos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_SEARCHNEXT, flag, keywords);
            return pos;
        }

        public int SearchPrev(string keywords, bool isRegExp, bool wholeWord, bool matchCase)
        {
            int flag = 0;

            if (wholeWord)
                flag += (int)SciMsg.SCFIND_WHOLEWORD;
            if (matchCase)
                flag += (int)SciMsg.SCFIND_MATCHCASE;
            if (isRegExp)
                flag += (int)SciMsg.SCFIND_REGEXP;

            int pos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_SEARCHPREV, flag, keywords);
            return pos;
        }

        public int SearchForward(string keywords, bool isRegExp, bool wholeWord, bool matchCase)
        {
            int currPos = this.GetCurrentPos();
            int anchor = this.GetAnchor();
            int startPos = currPos > anchor ? currPos : anchor;
            this.GoToPos(startPos);

            this.SetSearchAnchor();
            int pos = this.SearchNext(keywords, isRegExp, wholeWord, matchCase);
            this.ScrollCaret();
            return pos;
        }

        public int SearchForward(string keywords, bool isRegExp, bool wholeWord, bool matchCase, bool wrapSearch)
        {
            int pos = SearchForward(keywords, isRegExp, wholeWord, matchCase);
            if (pos == -1 && wrapSearch)
            {
                this.GoToPos(0);
                this.SetSearchAnchor();
                pos = this.SearchNext(keywords, isRegExp, wholeWord, matchCase);
            }
            this.ScrollCaret();
            return pos;
        }

        public int SearchBackward(string keywords, bool isRegExp, bool wholeWord, bool matchCase)
        {
            int currPos = this.GetCurrentPos();
            int anchor = this.GetAnchor();
            int startPos = currPos < anchor ? currPos : anchor;
            this.GoToPos(startPos);

            this.SetSearchAnchor();
            int pos = this.SearchPrev(keywords, isRegExp, wholeWord, matchCase);
            this.ScrollCaret();
            return pos;
        }

        public int SearchBackward(string keywords, bool isRegExp, bool wholeWord, bool matchCase, bool wrapSearch)
        {
            int pos = SearchBackward(keywords, isRegExp, wholeWord, matchCase);
            if (pos == -1 && wrapSearch)
            {
                int textLength = this.GetLength();
                this.GoToPos(textLength);
                pos = SearchBackward(keywords, isRegExp, wholeWord, matchCase);
            }
            this.ScrollCaret();
            return pos;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                CloseHandle(curScintilla);
                curScintilla = IntPtr.Zero;
                disposed = true;
            }
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        ~Scintilla()
        {
            Dispose(false);
        }
    }
}
