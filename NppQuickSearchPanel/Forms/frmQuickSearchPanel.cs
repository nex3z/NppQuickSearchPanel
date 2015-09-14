using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Linq;
using NppPluginNET;

namespace NppQuickSearchPanel
{
    public partial class frmQuickSearch : Form
    {
        BindingList<Entry> entryList = new BindingList<Entry>();
        int lastSelectedIndex = -1;

        public frmQuickSearch()
        {
            InitializeComponent();
            lstEntry.DataSource = entryList;

            chkMatchCase.Checked = Settings.Configs.matchCase;
            chkMatchWord.Checked = Settings.Configs.matchWord;
            chkWrap.Checked = Settings.Configs.wrapSearch;
            rbtnRegExp.Checked = Settings.Configs.isRegExp;
            rbtnNromal.Checked = !rbtnRegExp.Checked;

            string listFileName = Path.Combine(Settings.ConfigDir, Main.PluginName + ".xml");
            if (File.Exists(listFileName))
            {               
                PopulateListFromFile(listFileName);
            }
        }

        private void txtKeywords_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string keywords = txtKeywords.Text;
                if (keywords != "")
                {
                    Entry newEntry = null;
                    if (rbtnNromal.Checked)
                        newEntry = new Entry(keywords, KeywordsType.Normal);
                    else
                        newEntry = new Entry(keywords, KeywordsType.RegExp);

                    entryList.Insert(0, newEntry);
                    lstEntry.SelectedIndex = 0;
                }
                e.SuppressKeyPress = true;
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            string keywords = txtKeywords.Text;
            if (keywords != "")
            {
                Entry newEntry = null;
                if (rbtnNromal.Checked)
                    newEntry = new Entry(keywords, KeywordsType.Normal);
                else
                    newEntry = new Entry(keywords, KeywordsType.RegExp);

                entryList.Insert(0, newEntry);
                lstEntry.SelectedIndex = 0;
            }
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            int index = lstEntry.SelectedIndex;
            if (index >= 0)
                entryList.RemoveAt(index);
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                PopulateListFromFile(openFileDlg.FileName);
            }
        }

        private void PopulateListFromFile(string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                XmlSerializer ser = new XmlSerializer(typeof(BindingList<Entry>));

                lstEntry.DataSource = null;
                entryList = (BindingList<Entry>)ser.Deserialize(fs);
                lstEntry.DataSource = entryList;

                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Open file error: " + ex.Message);
                lstEntry.DataSource = entryList;
                File.Delete(fileName);
            }
        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                SaveListToFile(saveFileDlg.FileName);
            }

        }

        private void SaveListToFile(string fileName)
        {
            try
            {
                TextWriter writer = new StreamWriter(fileName);
                XmlSerializer ser = new XmlSerializer(typeof(BindingList<Entry>));
                ser.Serialize(writer, entryList);
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save file error: " + ex.Message);
                File.Delete(fileName);
            }
        }

        private void lstEntry_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.DrawBackground();
            Graphics g = e.Graphics;

            // Hightlight selected item.
            g.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), e.Bounds);

            // Change font color according to KeywordsType.
            ListBox lb = (ListBox)sender;
            Entry entry = (Entry)lb.Items[e.Index];
            if (entry.Type == KeywordsType.Normal)
                g.DrawString(entry.ToString(), e.Font, new SolidBrush(Color.Black), new PointF(e.Bounds.X, e.Bounds.Y));
            else
                g.DrawString(entry.ToString(), e.Font, new SolidBrush(Color.Blue), new PointF(e.Bounds.X, e.Bounds.Y));
            
            e.DrawFocusRectangle();
        }

        private void lstEntry_MouseDown(object sender, MouseEventArgs e)
        {
            int index = lstEntry.IndexFromPoint(e.X, e.Y);
            bool isSelectedIndexChanged = false;

            if (index < 0)
                return;
            else if (index != lastSelectedIndex)
            {
                isSelectedIndexChanged = true;
                lastSelectedIndex = index;
            }

            Entry keywords = entryList[index];
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                lstEntry.SetSelected(index, true);
                Clipboard.SetText(keywords.ToString());
                Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_MENUCOMMAND, 0, NppMenuCmd.IDM_SEARCH_FIND);
                SendKeys.SendWait("^{v}");
            }
            else if ((ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                using(Scintilla sci = new Scintilla())
                {
                    int pos = sci.SearchBackward(keywords.ToString(), 
                        keywords.Type == KeywordsType.RegExp, chkMatchWord.Checked, chkMatchCase.Checked, chkWrap.Checked);
                    updateSearchResult(sci, pos);
                }
            }
            else
            {
                if (!isSelectedIndexChanged)
                {
                    using (Scintilla sci = new Scintilla())
                    {
                        int pos = sci.SearchForward(keywords.ToString(),
                            keywords.Type == KeywordsType.RegExp, chkMatchWord.Checked, chkMatchCase.Checked, chkWrap.Checked);
                        updateSearchResult(sci, pos);
                    }
                }
            }
        }

        private void updateSearchResult(Scintilla sci, int pos) 
        {
            if (pos < 0)
            {
                tsslSearchResult.Text = "Couldn't find the keyword.";
                tsslSearchResult.ForeColor = Color.Red;
            }
            else
            {
                int line = sci.GetLineFromPosition(pos);
                tsslSearchResult.Text = "Found at line " + (line + 1) + ".";
                tsslSearchResult.ForeColor = Color.Green;
            }
        }

        private void lstEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int index = lstEntry.SelectedIndex;
                if (index >= 0)
                    entryList.RemoveAt(index);
            }
        }

        private void tsbMoveUp_Click(object sender, EventArgs e)
        {
            int index = lstEntry.SelectedIndex;
            if (index < 1)
                return;

            Entry tmp = entryList[index];
            entryList[index] = entryList[index - 1];
            entryList[index - 1] = tmp;
            lstEntry.SelectedIndex = index - 1;
        }

        private void tsbMoveDown_Click(object sender, EventArgs e)
        {
            int index = lstEntry.SelectedIndex;
            if (index < 0 || index == entryList.Count - 1)
                return;

            Entry tmp = entryList[index];
            entryList[index] = entryList[index + 1];
            entryList[index + 1] = tmp;
            lstEntry.SelectedIndex = index + 1;
        }

        private void tsbRemoveDuplItem_Click(object sender, EventArgs e)
        {
            DialogResult MsgBoxResult = MessageBox.Show(
                "Are you sure you want to delete duplicated keywords in the list?",
                "Delete duplicated keywords",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);

            if (MsgBoxResult == DialogResult.Yes)
            {
                entryList = new BindingList<Entry>(entryList.Distinct().ToList());
                lstEntry.DataSource = entryList;
            }
        }

        private void frmQuickSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Configs.matchCase = chkMatchCase.Checked;
            Settings.Configs.matchWord = chkMatchWord.Checked;
            Settings.Configs.wrapSearch = chkWrap.Checked;
            Settings.Configs.isRegExp = rbtnRegExp.Checked;

            string listFileName = Path.Combine(Settings.ConfigDir, Main.PluginName + ".xml");
            SaveListToFile(listFileName);

       }

        private void lstEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstEntry.SelectedIndex;
            if (index < 0)
                return;
            txtKeywords.Text = entryList[index].Keywords;
            rbtnRegExp.Checked = entryList[index].Type == KeywordsType.RegExp;
            rbtnNromal.Checked = !rbtnRegExp.Checked;
        }

        private void frmQuickSearch_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETMENUITEMCHECK, PluginBase._funcItems.Items[Main.getDlgId()]._cmdID, 0);
            }
        }
    }
}
