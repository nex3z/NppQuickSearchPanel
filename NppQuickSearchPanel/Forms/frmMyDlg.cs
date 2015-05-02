using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using NppPluginNET;

namespace NppQuickSearchPanel
{
    public partial class frmQuickSearch : Form
    {
        BindingList<Entry> entryList = new BindingList<Entry>(); 

        public frmQuickSearch()
        {
            InitializeComponent();
            lstEntry.DataSource = entryList;

            Configuration config = Configuration.Instance;
            chkMatchCase.Checked = config.matchCase;
            chkMatchWord.Checked = config.matchWord;
            chkWrap.Checked = config.wrapSearch;
            rbtnRegExp.Checked = config.isRegExp;
            rbtnNromal.Checked = !rbtnRegExp.Checked;

            string listFileName = Path.Combine(config.ConfigFilePath, Main.PluginName + ".xml");
            if (File.Exists(listFileName))
            {               
                PopulateListFromFile(listFileName);
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

                entryList.Add(newEntry);
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
            int index = lstEntry.SelectedIndex;
            if (index < 0)
                return;

            Entry keywords = entryList[index];
            IntPtr curScintilla = PluginBase.GetCurrentScintilla();

            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                // Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_LAUNCHFINDINFILESDLG, 0, 0);
            }
            else if ((ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                using(Scintilla sci = new Scintilla())
                {
                    int pos = sci.SearchBackward(keywords.ToString(), 
                        keywords.Type == KeywordsType.RegExp, chkMatchWord.Checked, chkMatchCase.Checked, chkWrap.Checked);
                }
            }
            else
            {
                using (Scintilla sci = new Scintilla())
                {
                    int pos = sci.SearchForward(keywords.ToString(), 
                        keywords.Type == KeywordsType.RegExp, chkMatchWord.Checked, chkMatchCase.Checked, chkWrap.Checked);
                }
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

        private void frmQuickSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            Configuration config = Configuration.Instance;
            config.matchCase = chkMatchCase.Checked;
            config.matchWord = chkMatchWord.Checked;
            config.wrapSearch = chkWrap.Checked;
            config.isRegExp = rbtnRegExp.Checked;

            string listFileName = Path.Combine(config.ConfigFilePath, Main.PluginName + ".xml");
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
    }
}
