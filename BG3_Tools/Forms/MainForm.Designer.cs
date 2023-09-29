namespace BG3_Tools
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.genToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translationEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metaEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pACToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTheApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1588, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // genToolStripMenuItem
            // 
            this.genToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uIDToolStripMenuItem,
            this.translationEditorToolStripMenuItem,
            this.metaEditorToolStripMenuItem,
            this.pACToolStripMenuItem});
            this.genToolStripMenuItem.Name = "genToolStripMenuItem";
            this.genToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.genToolStripMenuItem.Text = "Tools";
            // 
            // uIDToolStripMenuItem
            // 
            this.uIDToolStripMenuItem.Name = "uIDToolStripMenuItem";
            this.uIDToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.uIDToolStripMenuItem.Text = "uID Generate";
            this.uIDToolStripMenuItem.Click += new System.EventHandler(this.uIDToolStripMenuItem_Click);
            // 
            // translationEditorToolStripMenuItem
            // 
            this.translationEditorToolStripMenuItem.Name = "translationEditorToolStripMenuItem";
            this.translationEditorToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.translationEditorToolStripMenuItem.Text = "Translation Editor";
            this.translationEditorToolStripMenuItem.Click += new System.EventHandler(this.translationEditorToolStripMenuItem_Click);
            // 
            // metaEditorToolStripMenuItem
            // 
            this.metaEditorToolStripMenuItem.Name = "metaEditorToolStripMenuItem";
            this.metaEditorToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.metaEditorToolStripMenuItem.Text = "Meta Editor";
            this.metaEditorToolStripMenuItem.Click += new System.EventHandler(this.metaEditorToolStripMenuItem_Click);
            // 
            // pACToolStripMenuItem
            // 
            this.pACToolStripMenuItem.Name = "pACToolStripMenuItem";
            this.pACToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.pACToolStripMenuItem.Text = "PAK Editor";
            this.pACToolStripMenuItem.Click += new System.EventHandler(this.pACToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutTheApplicationToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutTheApplicationToolStripMenuItem
            // 
            this.aboutTheApplicationToolStripMenuItem.Name = "aboutTheApplicationToolStripMenuItem";
            this.aboutTheApplicationToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.aboutTheApplicationToolStripMenuItem.Text = "About the application";
            this.aboutTheApplicationToolStripMenuItem.Click += new System.EventHandler(this.aboutTheApplicationToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1588, 892);
            this.Controls.Add(this.menuStripMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "BG3 Tools";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem genToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutTheApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metaEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translationEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pACToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
    }
}