namespace ExeConfigEditor
{
    partial class AddDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TbKeyBox = new System.Windows.Forms.TextBox();
            this.TbValueBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RbInsert = new System.Windows.Forms.RadioButton();
            this.PnlInsertPanel = new System.Windows.Forms.Panel();
            this.CmbBxConfigValues = new System.Windows.Forms.ComboBox();
            this.RbBefore = new System.Windows.Forms.RadioButton();
            this.RbInsertAfter = new System.Windows.Forms.RadioButton();
            this.RbPrepend = new System.Windows.Forms.RadioButton();
            this.RbAppend = new System.Windows.Forms.RadioButton();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.PnlInsertPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Value";
            // 
            // TbKeyBox
            // 
            this.TbKeyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbKeyBox.Location = new System.Drawing.Point(48, 12);
            this.TbKeyBox.Name = "TbKeyBox";
            this.TbKeyBox.Size = new System.Drawing.Size(169, 20);
            this.TbKeyBox.TabIndex = 2;
            // 
            // TbValueBox
            // 
            this.TbValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbValueBox.Location = new System.Drawing.Point(48, 45);
            this.TbValueBox.Name = "TbValueBox";
            this.TbValueBox.Size = new System.Drawing.Size(169, 20);
            this.TbValueBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 2);
            this.label3.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TbKeyBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TbValueBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 80);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RbInsert);
            this.groupBox1.Controls.Add(this.PnlInsertPanel);
            this.groupBox1.Controls.Add(this.RbPrepend);
            this.groupBox1.Controls.Add(this.RbAppend);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 93);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // RbInsert
            // 
            this.RbInsert.AutoSize = true;
            this.RbInsert.Location = new System.Drawing.Point(166, 19);
            this.RbInsert.Name = "RbInsert";
            this.RbInsert.Size = new System.Drawing.Size(51, 17);
            this.RbInsert.TabIndex = 3;
            this.RbInsert.TabStop = true;
            this.RbInsert.Tag = "2";
            this.RbInsert.Text = "Insert";
            this.RbInsert.UseVisualStyleBackColor = true;
            this.RbInsert.CheckedChanged += new System.EventHandler(this.RbAddMode_CheckChanged);
            // 
            // PnlInsertPanel
            // 
            this.PnlInsertPanel.Controls.Add(this.CmbBxConfigValues);
            this.PnlInsertPanel.Controls.Add(this.RbBefore);
            this.PnlInsertPanel.Controls.Add(this.RbInsertAfter);
            this.PnlInsertPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlInsertPanel.Location = new System.Drawing.Point(3, 44);
            this.PnlInsertPanel.Name = "PnlInsertPanel";
            this.PnlInsertPanel.Size = new System.Drawing.Size(223, 46);
            this.PnlInsertPanel.TabIndex = 2;
            // 
            // CmbBxConfigValues
            // 
            this.CmbBxConfigValues.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CmbBxConfigValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBxConfigValues.FormattingEnabled = true;
            this.CmbBxConfigValues.Location = new System.Drawing.Point(0, 25);
            this.CmbBxConfigValues.Name = "CmbBxConfigValues";
            this.CmbBxConfigValues.Size = new System.Drawing.Size(223, 21);
            this.CmbBxConfigValues.TabIndex = 6;
            this.CmbBxConfigValues.SelectedIndexChanged += new System.EventHandler(this.CmbBxConfigValues_SelectedIndexChanged);
            // 
            // RbBefore
            // 
            this.RbBefore.AutoSize = true;
            this.RbBefore.Location = new System.Drawing.Point(163, 3);
            this.RbBefore.Name = "RbBefore";
            this.RbBefore.Size = new System.Drawing.Size(56, 17);
            this.RbBefore.TabIndex = 5;
            this.RbBefore.TabStop = true;
            this.RbBefore.Tag = "1";
            this.RbBefore.Text = "Before";
            this.RbBefore.UseVisualStyleBackColor = true;
            this.RbBefore.CheckedChanged += new System.EventHandler(this.RbInsertMode_CheckedChanged);
            // 
            // RbInsertAfter
            // 
            this.RbInsertAfter.AutoSize = true;
            this.RbInsertAfter.Location = new System.Drawing.Point(8, 3);
            this.RbInsertAfter.Name = "RbInsertAfter";
            this.RbInsertAfter.Size = new System.Drawing.Size(47, 17);
            this.RbInsertAfter.TabIndex = 4;
            this.RbInsertAfter.TabStop = true;
            this.RbInsertAfter.Tag = "0";
            this.RbInsertAfter.Text = "After";
            this.RbInsertAfter.UseVisualStyleBackColor = true;
            this.RbInsertAfter.CheckedChanged += new System.EventHandler(this.RbInsertMode_CheckedChanged);
            // 
            // RbPrepend
            // 
            this.RbPrepend.AutoSize = true;
            this.RbPrepend.Location = new System.Drawing.Point(11, 19);
            this.RbPrepend.Name = "RbPrepend";
            this.RbPrepend.Size = new System.Drawing.Size(65, 17);
            this.RbPrepend.TabIndex = 1;
            this.RbPrepend.TabStop = true;
            this.RbPrepend.Tag = "0";
            this.RbPrepend.Text = "Prepend";
            this.RbPrepend.UseVisualStyleBackColor = true;
            this.RbPrepend.CheckedChanged += new System.EventHandler(this.RbAddMode_CheckChanged);
            // 
            // RbAppend
            // 
            this.RbAppend.AutoSize = true;
            this.RbAppend.Location = new System.Drawing.Point(90, 19);
            this.RbAppend.Name = "RbAppend";
            this.RbAppend.Size = new System.Drawing.Size(62, 17);
            this.RbAppend.TabIndex = 0;
            this.RbAppend.TabStop = true;
            this.RbAppend.Tag = "1";
            this.RbAppend.Text = "Append";
            this.RbAppend.UseVisualStyleBackColor = true;
            this.RbAppend.CheckedChanged += new System.EventHandler(this.RbAddMode_CheckChanged);
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.Location = new System.Drawing.Point(61, 185);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 7;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.Location = new System.Drawing.Point(142, 185);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // AddDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 219);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Node";
            this.Load += new System.EventHandler(this.AddDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PnlInsertPanel.ResumeLayout(false);
            this.PnlInsertPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbKeyBox;
        private System.Windows.Forms.TextBox TbValueBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RbInsert;
        private System.Windows.Forms.Panel PnlInsertPanel;
        private System.Windows.Forms.ComboBox CmbBxConfigValues;
        private System.Windows.Forms.RadioButton RbBefore;
        private System.Windows.Forms.RadioButton RbInsertAfter;
        private System.Windows.Forms.RadioButton RbPrepend;
        private System.Windows.Forms.RadioButton RbAppend;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
    }
}