﻿namespace NppQuickSearchPanel
{
    partial class frmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnVisitSite = new System.Windows.Forms.Button();
            this.lblAbout = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(217, 152);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 21);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnVisitSite
            // 
            this.btnVisitSite.Location = new System.Drawing.Point(12, 152);
            this.btnVisitSite.Name = "btnVisitSite";
            this.btnVisitSite.Size = new System.Drawing.Size(75, 21);
            this.btnVisitSite.TabIndex = 0;
            this.btnVisitSite.Text = "Visit site";
            this.btnVisitSite.UseVisualStyleBackColor = true;
            this.btnVisitSite.Click += new System.EventHandler(this.btnVisitSite_Click);
            // 
            // lblAbout
            // 
            this.lblAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAbout.Location = new System.Drawing.Point(9, 8);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(286, 126);
            this.lblAbout.TabIndex = 2;
            this.lblAbout.Text = resources.GetString("lblAbout.Text");
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 181);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnVisitSite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnVisitSite;
        private System.Windows.Forms.Label lblAbout;






    }
}
