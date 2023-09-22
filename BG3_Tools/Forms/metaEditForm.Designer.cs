namespace BG3_Tools.Forms
{
    partial class metaEditForm
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
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxIsHandle = new System.Windows.Forms.CheckBox();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "(*.lsx)|*.lsx";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "(*.lsx)|*.lsx";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.Location = new System.Drawing.Point(776, 516);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 32);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(863, 510);
            this.dataGridView1.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(695, 516);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 32);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 516);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generate ID";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxIsHandle
            // 
            this.checkBoxIsHandle.AutoSize = true;
            this.checkBoxIsHandle.Checked = true;
            this.checkBoxIsHandle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsHandle.Location = new System.Drawing.Point(12, 525);
            this.checkBoxIsHandle.Name = "checkBoxIsHandle";
            this.checkBoxIsHandle.Size = new System.Drawing.Size(77, 17);
            this.checkBoxIsHandle.TabIndex = 6;
            this.checkBoxIsHandle.Text = "Is Handle?";
            this.checkBoxIsHandle.UseVisualStyleBackColor = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.FillWeight = 160F;
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 120;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idDataGridViewTextBoxColumn.Width = 160;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.MinimumWidth = 32;
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(BG3_Tools.Models.Attribute);
            this.bindingSource1.Filter = "";
            // 
            // metaEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 555);
            this.Controls.Add(this.checkBoxIsHandle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonOpen);
            this.Name = "metaEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meta Editor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxIsHandle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
    }
}