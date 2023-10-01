namespace BG3_Tools.Forms
{
    partial class activeForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabelApp = new System.Windows.Forms.LinkLabel();
            this.buttonSkip = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.labelDesc = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.bSend = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.panelCode = new System.Windows.Forms.Panel();
            this.richTextBoxCodeErr = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.linkLabelApp);
            this.panel1.Controls.Add(this.buttonSkip);
            this.panel1.Controls.Add(this.buttonShow);
            this.panel1.Controls.Add(this.labelDesc);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.bSend);
            this.panel1.Controls.Add(this.bClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 121);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(10, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 67);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabelApp
            // 
            this.linkLabelApp.AutoSize = true;
            this.linkLabelApp.Location = new System.Drawing.Point(81, 78);
            this.linkLabelApp.Name = "linkLabelApp";
            this.linkLabelApp.Size = new System.Drawing.Size(31, 13);
            this.linkLabelApp.TabIndex = 6;
            this.linkLabelApp.TabStop = true;
            this.linkLabelApp.Text = "{link}";
            this.linkLabelApp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelApp_LinkClicked);
            // 
            // buttonSkip
            // 
            this.buttonSkip.Location = new System.Drawing.Point(294, 94);
            this.buttonSkip.Name = "buttonSkip";
            this.buttonSkip.Size = new System.Drawing.Size(75, 23);
            this.buttonSkip.TabIndex = 5;
            this.buttonSkip.Text = "Skip";
            this.buttonSkip.UseVisualStyleBackColor = true;
            this.buttonSkip.Click += new System.EventHandler(this.buttonSkip_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(6, 94);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(75, 23);
            this.buttonShow.TabIndex = 4;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // labelDesc
            // 
            this.labelDesc.Location = new System.Drawing.Point(81, 22);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(361, 69);
            this.labelDesc.TabIndex = 3;
            this.labelDesc.Text = "{Description}\r\n\r\n";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(3, 3);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(54, 15);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "{TITLE}";
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(375, 94);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(75, 23);
            this.bSend.TabIndex = 1;
            this.bSend.Text = "Send";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(213, 94);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 0;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // panelCode
            // 
            this.panelCode.Controls.Add(this.richTextBoxCodeErr);
            this.panelCode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCode.Location = new System.Drawing.Point(0, 123);
            this.panelCode.Name = "panelCode";
            this.panelCode.Size = new System.Drawing.Size(454, 133);
            this.panelCode.TabIndex = 2;
            // 
            // richTextBoxCodeErr
            // 
            this.richTextBoxCodeErr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxCodeErr.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxCodeErr.Name = "richTextBoxCodeErr";
            this.richTextBoxCodeErr.Size = new System.Drawing.Size(454, 133);
            this.richTextBoxCodeErr.TabIndex = 1;
            this.richTextBoxCodeErr.Text = "";
            // 
            // activeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(454, 256);
            this.Controls.Add(this.panelCode);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "activeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ErrorForm_FormClosed);
            this.Shown += new System.EventHandler(this.ErrorForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelCode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.Panel panelCode;
        private System.Windows.Forms.RichTextBox richTextBoxCodeErr;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonSkip;
        private System.Windows.Forms.LinkLabel linkLabelApp;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}