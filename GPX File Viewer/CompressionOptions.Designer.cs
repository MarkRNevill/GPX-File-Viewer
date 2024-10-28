namespace GPX_File_Viewer
{
    partial class CompressionOptions
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
            this.checkBoxCustom = new System.Windows.Forms.CheckBox();
            this.checkBoxElevation = new System.Windows.Forms.CheckBox();
            this.labelAccuracy = new System.Windows.Forms.Label();
            this.comboBoxAccuracy = new System.Windows.Forms.ComboBox();
            this.buttonCompressFile = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxCustom
            // 
            this.checkBoxCustom.AutoSize = true;
            this.checkBoxCustom.Location = new System.Drawing.Point(34, 96);
            this.checkBoxCustom.Name = "checkBoxCustom";
            this.checkBoxCustom.Size = new System.Drawing.Size(319, 17);
            this.checkBoxCustom.TabIndex = 17;
            this.checkBoxCustom.Text = "Retain custom data elements (heart rate, power etc) if present.";
            this.checkBoxCustom.UseVisualStyleBackColor = true;
            // 
            // checkBoxElevation
            // 
            this.checkBoxElevation.AutoSize = true;
            this.checkBoxElevation.Location = new System.Drawing.Point(34, 73);
            this.checkBoxElevation.Name = "checkBoxElevation";
            this.checkBoxElevation.Size = new System.Drawing.Size(176, 17);
            this.checkBoxElevation.TabIndex = 16;
            this.checkBoxElevation.Text = "Retain elevation data if present.";
            this.checkBoxElevation.UseVisualStyleBackColor = true;
            // 
            // labelAccuracy
            // 
            this.labelAccuracy.AutoSize = true;
            this.labelAccuracy.Location = new System.Drawing.Point(31, 47);
            this.labelAccuracy.Name = "labelAccuracy";
            this.labelAccuracy.Size = new System.Drawing.Size(206, 13);
            this.labelAccuracy.TabIndex = 14;
            this.labelAccuracy.Text = "Select desired level of accuracy in metres.";
            // 
            // comboBoxAccuracy
            // 
            this.comboBoxAccuracy.FormattingEnabled = true;
            this.comboBoxAccuracy.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "100"});
            this.comboBoxAccuracy.Location = new System.Drawing.Point(243, 44);
            this.comboBoxAccuracy.Name = "comboBoxAccuracy";
            this.comboBoxAccuracy.Size = new System.Drawing.Size(69, 21);
            this.comboBoxAccuracy.TabIndex = 13;
            // 
            // buttonCompressFile
            // 
            this.buttonCompressFile.Location = new System.Drawing.Point(62, 119);
            this.buttonCompressFile.Name = "buttonCompressFile";
            this.buttonCompressFile.Size = new System.Drawing.Size(75, 23);
            this.buttonCompressFile.TabIndex = 15;
            this.buttonCompressFile.Text = "Compress";
            this.buttonCompressFile.UseVisualStyleBackColor = true;
            this.buttonCompressFile.Click += new System.EventHandler(this.buttonCompressFile_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(158, 119);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 19;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // CompressionOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 164);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.checkBoxCustom);
            this.Controls.Add(this.checkBoxElevation);
            this.Controls.Add(this.buttonCompressFile);
            this.Controls.Add(this.labelAccuracy);
            this.Controls.Add(this.comboBoxAccuracy);
            this.Name = "CompressionOptions";
            this.Text = "Compression Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxCustom;
        private System.Windows.Forms.CheckBox checkBoxElevation;
        private System.Windows.Forms.Label labelAccuracy;
        private System.Windows.Forms.ComboBox comboBoxAccuracy;
        private System.Windows.Forms.Button buttonCompressFile;
        private System.Windows.Forms.Button buttonClose;
    }
}