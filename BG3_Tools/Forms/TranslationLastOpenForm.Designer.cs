namespace BG3_Tools.Forms
{
    partial class TranslationLastOpenForm
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
            this.panelLastOpen = new System.Windows.Forms.Panel();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.listViewLastFile = new System.Windows.Forms.ListView();
            this.nameFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.panelLastOpen.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLastOpen
            // 
            this.panelLastOpen.Controls.Add(this.buttonRefresh);
            this.panelLastOpen.Controls.Add(this.buttonOpen);
            this.panelLastOpen.Controls.Add(this.listViewLastFile);
            this.panelLastOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLastOpen.Location = new System.Drawing.Point(0, 0);
            this.panelLastOpen.Name = "panelLastOpen";
            this.panelLastOpen.Size = new System.Drawing.Size(1133, 689);
            this.panelLastOpen.TabIndex = 5;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.Location = new System.Drawing.Point(988, 624);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(133, 55);
            this.buttonOpen.TabIndex = 1;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // listViewLastFile
            // 
            this.listViewLastFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameFile,
            this.dateTime,
            this.size});
            this.listViewLastFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewLastFile.HideSelection = false;
            this.listViewLastFile.Location = new System.Drawing.Point(0, 0);
            this.listViewLastFile.MultiSelect = false;
            this.listViewLastFile.Name = "listViewLastFile";
            this.listViewLastFile.ShowGroups = false;
            this.listViewLastFile.Size = new System.Drawing.Size(1133, 618);
            this.listViewLastFile.TabIndex = 0;
            this.listViewLastFile.UseCompatibleStateImageBehavior = false;
            this.listViewLastFile.View = System.Windows.Forms.View.Details;
            // 
            // nameFile
            // 
            this.nameFile.Text = "Name";
            this.nameFile.Width = 798;
            // 
            // dateTime
            // 
            this.dateTime.Text = "Date";
            this.dateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTime.Width = 229;
            // 
            // size
            // 
            this.size.Text = "Size";
            this.size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.size.Width = 98;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(849, 624);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(133, 55);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // TranslationLastOpenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 689);
            this.Controls.Add(this.panelLastOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "TranslationLastOpenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Last Open";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TranslationLastOpenForm_FormClosing);
            this.Load += new System.EventHandler(this.TranslationLastOpenForm_Load);
            this.Shown += new System.EventHandler(this.TranslationLastOpenForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.TranslationLastOpenForm_VisibleChanged);
            this.panelLastOpen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.ColumnHeader nameFile;
        private System.Windows.Forms.ColumnHeader dateTime;
        private System.Windows.Forms.ColumnHeader size;
        public System.Windows.Forms.ListView listViewLastFile;
        public System.Windows.Forms.Panel panelLastOpen;
        private System.Windows.Forms.Button buttonRefresh;
    }
}