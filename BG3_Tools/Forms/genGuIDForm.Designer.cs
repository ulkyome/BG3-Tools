namespace BG3_Tools.Forms
{
    partial class genGuIDForm
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
            this.textBoxUID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxIsHandle = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxHistory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBoxUID
            // 
            this.textBoxUID.Location = new System.Drawing.Point(12, 12);
            this.textBoxUID.Name = "textBoxUID";
            this.textBoxUID.Size = new System.Drawing.Size(367, 20);
            this.textBoxUID.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(385, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxIsHandle
            // 
            this.checkBoxIsHandle.AutoSize = true;
            this.checkBoxIsHandle.Checked = true;
            this.checkBoxIsHandle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsHandle.Location = new System.Drawing.Point(454, 15);
            this.checkBoxIsHandle.Name = "checkBoxIsHandle";
            this.checkBoxIsHandle.Size = new System.Drawing.Size(77, 17);
            this.checkBoxIsHandle.TabIndex = 2;
            this.checkBoxIsHandle.Text = "Is Handle?";
            this.checkBoxIsHandle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "History";
            // 
            // listBoxHistory
            // 
            this.listBoxHistory.FormattingEnabled = true;
            this.listBoxHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.listBoxHistory.Location = new System.Drawing.Point(12, 58);
            this.listBoxHistory.Name = "listBoxHistory";
            this.listBoxHistory.Size = new System.Drawing.Size(367, 277);
            this.listBoxHistory.TabIndex = 5;
            this.listBoxHistory.SelectedIndexChanged += new System.EventHandler(this.listBoxHistory_SelectedIndexChanged);
            // 
            // genGuID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 357);
            this.Controls.Add(this.listBoxHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxIsHandle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxUID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "genGuID";
            this.Text = "genGuID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxIsHandle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxHistory;
    }
}