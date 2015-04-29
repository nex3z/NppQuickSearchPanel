namespace NppQuickSearchPanel
{
    partial class frmQuickSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpDlg = new System.Windows.Forms.TableLayoutPanel();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.flpMatchOption = new System.Windows.Forms.FlowLayoutPanel();
            this.chkMatchWord = new System.Windows.Forms.CheckBox();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.chkWrap = new System.Windows.Forms.CheckBox();
            this.lblSepLine2 = new System.Windows.Forms.Label();
            this.flpSearchMode = new System.Windows.Forms.FlowLayoutPanel();
            this.rbtnNromal = new System.Windows.Forms.RadioButton();
            this.rbtnRegExp = new System.Windows.Forms.RadioButton();
            this.tlpButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.lstEntry = new System.Windows.Forms.ListBox();
            this.tlpDlg.SuspendLayout();
            this.flpMatchOption.SuspendLayout();
            this.flpSearchMode.SuspendLayout();
            this.tlpButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpDlg
            // 
            this.tlpDlg.ColumnCount = 1;
            this.tlpDlg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDlg.Controls.Add(this.txtKeywords, 0, 2);
            this.tlpDlg.Controls.Add(this.flpMatchOption, 0, 0);
            this.tlpDlg.Controls.Add(this.lblSepLine2, 0, 1);
            this.tlpDlg.Controls.Add(this.flpSearchMode, 0, 3);
            this.tlpDlg.Controls.Add(this.tlpButton, 0, 4);
            this.tlpDlg.Controls.Add(this.lstEntry, 0, 5);
            this.tlpDlg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDlg.Location = new System.Drawing.Point(0, 0);
            this.tlpDlg.Name = "tlpDlg";
            this.tlpDlg.RowCount = 6;
            this.tlpDlg.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDlg.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDlg.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDlg.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDlg.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDlg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDlg.Size = new System.Drawing.Size(387, 497);
            this.tlpDlg.TabIndex = 0;
            // 
            // txtKeywords
            // 
            this.txtKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeywords.Location = new System.Drawing.Point(3, 33);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(381, 21);
            this.txtKeywords.TabIndex = 1;
            // 
            // flpMatchOption
            // 
            this.flpMatchOption.AutoSize = true;
            this.flpMatchOption.Controls.Add(this.chkMatchWord);
            this.flpMatchOption.Controls.Add(this.chkMatchCase);
            this.flpMatchOption.Controls.Add(this.chkWrap);
            this.flpMatchOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMatchOption.Location = new System.Drawing.Point(3, 3);
            this.flpMatchOption.Name = "flpMatchOption";
            this.flpMatchOption.Size = new System.Drawing.Size(381, 22);
            this.flpMatchOption.TabIndex = 2;
            // 
            // chkMatchWord
            // 
            this.chkMatchWord.AutoSize = true;
            this.chkMatchWord.Location = new System.Drawing.Point(3, 3);
            this.chkMatchWord.Name = "chkMatchWord";
            this.chkMatchWord.Size = new System.Drawing.Size(84, 16);
            this.chkMatchWord.TabIndex = 0;
            this.chkMatchWord.Text = "Match Word";
            this.chkMatchWord.UseVisualStyleBackColor = true;
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(93, 3);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(84, 16);
            this.chkMatchCase.TabIndex = 1;
            this.chkMatchCase.Text = "Match Case";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // chkWrap
            // 
            this.chkWrap.AutoSize = true;
            this.chkWrap.Checked = true;
            this.chkWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWrap.Location = new System.Drawing.Point(183, 3);
            this.chkWrap.Name = "chkWrap";
            this.chkWrap.Size = new System.Drawing.Size(90, 16);
            this.chkWrap.TabIndex = 2;
            this.chkWrap.Text = "Wrap Search";
            this.chkWrap.UseVisualStyleBackColor = true;
            // 
            // lblSepLine2
            // 
            this.lblSepLine2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSepLine2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSepLine2.Location = new System.Drawing.Point(3, 28);
            this.lblSepLine2.Name = "lblSepLine2";
            this.lblSepLine2.Size = new System.Drawing.Size(381, 2);
            this.lblSepLine2.TabIndex = 3;
            // 
            // flpSearchMode
            // 
            this.flpSearchMode.AutoSize = true;
            this.flpSearchMode.Controls.Add(this.rbtnNromal);
            this.flpSearchMode.Controls.Add(this.rbtnRegExp);
            this.flpSearchMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSearchMode.Location = new System.Drawing.Point(3, 60);
            this.flpSearchMode.Name = "flpSearchMode";
            this.flpSearchMode.Size = new System.Drawing.Size(381, 22);
            this.flpSearchMode.TabIndex = 4;
            // 
            // rbtnNromal
            // 
            this.rbtnNromal.AutoSize = true;
            this.rbtnNromal.Checked = true;
            this.rbtnNromal.Location = new System.Drawing.Point(3, 3);
            this.rbtnNromal.Name = "rbtnNromal";
            this.rbtnNromal.Size = new System.Drawing.Size(59, 16);
            this.rbtnNromal.TabIndex = 0;
            this.rbtnNromal.TabStop = true;
            this.rbtnNromal.Text = "Normal";
            this.rbtnNromal.UseVisualStyleBackColor = true;
            // 
            // rbtnRegExp
            // 
            this.rbtnRegExp.AutoSize = true;
            this.rbtnRegExp.Location = new System.Drawing.Point(68, 3);
            this.rbtnRegExp.Name = "rbtnRegExp";
            this.rbtnRegExp.Size = new System.Drawing.Size(131, 16);
            this.rbtnRegExp.TabIndex = 1;
            this.rbtnRegExp.Text = "Regular Expression";
            this.rbtnRegExp.UseVisualStyleBackColor = true;
            // 
            // tlpButton
            // 
            this.tlpButton.AutoSize = true;
            this.tlpButton.ColumnCount = 4;
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.Controls.Add(this.btnAdd, 0, 0);
            this.tlpButton.Controls.Add(this.btnRemove, 1, 0);
            this.tlpButton.Controls.Add(this.btnExport, 2, 0);
            this.tlpButton.Controls.Add(this.btnImport, 3, 0);
            this.tlpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButton.Location = new System.Drawing.Point(3, 88);
            this.tlpButton.Name = "tlpButton";
            this.tlpButton.RowCount = 1;
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton.Size = new System.Drawing.Size(381, 29);
            this.tlpButton.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemove.Location = new System.Drawing.Point(98, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(89, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Location = new System.Drawing.Point(193, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(89, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImport.Location = new System.Drawing.Point(288, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(90, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import...";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lstEntry
            // 
            this.lstEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEntry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstEntry.FormattingEnabled = true;
            this.lstEntry.ItemHeight = 12;
            this.lstEntry.Location = new System.Drawing.Point(3, 123);
            this.lstEntry.Name = "lstEntry";
            this.lstEntry.Size = new System.Drawing.Size(381, 371);
            this.lstEntry.TabIndex = 8;
            this.lstEntry.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstEntry_DrawItem);
            // 
            // frmQuickSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 497);
            this.Controls.Add(this.tlpDlg);
            this.Name = "frmQuickSearch";
            this.Text = "Quick Search Panel";
            this.tlpDlg.ResumeLayout(false);
            this.tlpDlg.PerformLayout();
            this.flpMatchOption.ResumeLayout(false);
            this.flpMatchOption.PerformLayout();
            this.flpSearchMode.ResumeLayout(false);
            this.flpSearchMode.PerformLayout();
            this.tlpButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpDlg;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.FlowLayoutPanel flpMatchOption;
        private System.Windows.Forms.CheckBox chkMatchWord;
        private System.Windows.Forms.CheckBox chkMatchCase;
        private System.Windows.Forms.CheckBox chkWrap;
        private System.Windows.Forms.Label lblSepLine2;
        private System.Windows.Forms.FlowLayoutPanel flpSearchMode;
        private System.Windows.Forms.RadioButton rbtnNromal;
        private System.Windows.Forms.RadioButton rbtnRegExp;
        private System.Windows.Forms.TableLayoutPanel tlpButton;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ListBox lstEntry;

    }
}