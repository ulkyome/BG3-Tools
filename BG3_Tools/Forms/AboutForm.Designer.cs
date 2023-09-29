namespace BG3_Tools.Forms
{
    partial class AboutForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NameApp = new System.Windows.Forms.Label();
            this.verApp = new System.Windows.Forms.Label();
            this.labelBName = new System.Windows.Forms.Label();
            this.richTextBoxDesc = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::BG3_Tools.Resource.bg_load;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(698, 396);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // NameApp
            // 
            this.NameApp.BackColor = System.Drawing.Color.Transparent;
            this.NameApp.Cursor = System.Windows.Forms.Cursors.No;
            this.NameApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameApp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.NameApp.Location = new System.Drawing.Point(5, 9);
            this.NameApp.Name = "NameApp";
            this.NameApp.Size = new System.Drawing.Size(690, 42);
            this.NameApp.TabIndex = 1;
            this.NameApp.Text = "Title";
            this.NameApp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // verApp
            // 
            this.verApp.AutoSize = true;
            this.verApp.Location = new System.Drawing.Point(8, 635);
            this.verApp.Name = "verApp";
            this.verApp.Size = new System.Drawing.Size(49, 13);
            this.verApp.TabIndex = 2;
            this.verApp.Text = "ver 0000";
            // 
            // labelBName
            // 
            this.labelBName.BackColor = System.Drawing.Color.Transparent;
            this.labelBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelBName.Location = new System.Drawing.Point(8, 368);
            this.labelBName.Name = "labelBName";
            this.labelBName.Size = new System.Drawing.Size(686, 23);
            this.labelBName.TabIndex = 3;
            this.labelBName.Text = "by Name";
            // 
            // richTextBoxDesc
            // 
            this.richTextBoxDesc.Enabled = false;
            this.richTextBoxDesc.Location = new System.Drawing.Point(0, 394);
            this.richTextBoxDesc.Name = "richTextBoxDesc";
            this.richTextBoxDesc.ReadOnly = true;
            this.richTextBoxDesc.Size = new System.Drawing.Size(698, 235);
            this.richTextBoxDesc.TabIndex = 4;
            this.richTextBoxDesc.Text = "";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 654);
            this.Controls.Add(this.richTextBoxDesc);
            this.Controls.Add(this.labelBName);
            this.Controls.Add(this.verApp);
            this.Controls.Add(this.NameApp);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label NameApp;
        private System.Windows.Forms.Label verApp;
        private System.Windows.Forms.Label labelBName;
        private System.Windows.Forms.RichTextBox richTextBoxDesc;
    }
}