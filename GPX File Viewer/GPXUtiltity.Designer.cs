namespace GPX_File_Viewer
{
    partial class GPXUtiltity
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.buttonSaveCompressedFile = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonOpenMap = new System.Windows.Forms.Button();
            this.dataGridViewStats = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCompress = new System.Windows.Forms.Button();
            this.buttonSelectFile2 = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonJoin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(364, 61);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFile.TabIndex = 0;
            this.buttonSelectFile.Text = "Select File 1";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.ButtonSelectFile_Click);
            // 
            // buttonSaveCompressedFile
            // 
            this.buttonSaveCompressedFile.Location = new System.Drawing.Point(292, 91);
            this.buttonSaveCompressedFile.Name = "buttonSaveCompressedFile";
            this.buttonSaveCompressedFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveCompressedFile.TabIndex = 9;
            this.buttonSaveCompressedFile.Text = "Save";
            this.buttonSaveCompressedFile.UseVisualStyleBackColor = true;
            this.buttonSaveCompressedFile.Click += new System.EventHandler(this.ButtonSaveAs_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(294, 29);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(92, 13);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "GPX File Utility";
            // 
            // buttonOpenMap
            // 
            this.buttonOpenMap.Location = new System.Drawing.Point(130, 91);
            this.buttonOpenMap.Name = "buttonOpenMap";
            this.buttonOpenMap.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenMap.TabIndex = 13;
            this.buttonOpenMap.Text = "Map";
            this.buttonOpenMap.UseVisualStyleBackColor = true;
            this.buttonOpenMap.Click += new System.EventHandler(this.ButtonMap_Click);
            // 
            // dataGridViewStats
            // 
            this.dataGridViewStats.AllowUserToAddRows = false;
            this.dataGridViewStats.AllowUserToDeleteRows = false;
            this.dataGridViewStats.AllowUserToResizeRows = false;
            this.dataGridViewStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewStats.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewStats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewStats.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewStats.Location = new System.Drawing.Point(33, 129);
            this.dataGridViewStats.MultiSelect = false;
            this.dataGridViewStats.Name = "dataGridViewStats";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewStats.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewStats.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewStats.ShowEditingIcon = false;
            this.dataGridViewStats.Size = new System.Drawing.Size(673, 170);
            this.dataGridViewStats.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Select the source GPX file to view or compress.";
            // 
            // buttonCompress
            // 
            this.buttonCompress.Location = new System.Drawing.Point(211, 91);
            this.buttonCompress.Name = "buttonCompress";
            this.buttonCompress.Size = new System.Drawing.Size(75, 23);
            this.buttonCompress.TabIndex = 16;
            this.buttonCompress.Text = "Compress";
            this.buttonCompress.UseVisualStyleBackColor = true;
            this.buttonCompress.Click += new System.EventHandler(this.ButtonCompress_Click);
            // 
            // buttonSelectFile2
            // 
            this.buttonSelectFile2.Location = new System.Drawing.Point(445, 61);
            this.buttonSelectFile2.Name = "buttonSelectFile2";
            this.buttonSelectFile2.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFile2.TabIndex = 17;
            this.buttonSelectFile2.Text = "Select File 2";
            this.buttonSelectFile2.UseVisualStyleBackColor = true;
            this.buttonSelectFile2.Visible = false;
            this.buttonSelectFile2.Click += new System.EventHandler(this.ButtonSelectFile2_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(526, 61);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 18;
            this.buttonClear.Text = "Clear File";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Visible = false;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // buttonJoin
            // 
            this.buttonJoin.Location = new System.Drawing.Point(373, 91);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(75, 23);
            this.buttonJoin.TabIndex = 19;
            this.buttonJoin.Text = "Join";
            this.buttonJoin.UseVisualStyleBackColor = true;
            // 
            // GPXUtiltity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 322);
            this.Controls.Add(this.buttonJoin);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSelectFile2);
            this.Controls.Add(this.buttonCompress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewStats);
            this.Controls.Add(this.buttonOpenMap);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonSaveCompressedFile);
            this.Controls.Add(this.buttonSelectFile);
            this.Name = "GPXUtiltity";
            this.Text = "GPX Utility";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Button buttonSaveCompressedFile;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonOpenMap;
        private System.Windows.Forms.DataGridView dataGridViewStats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCompress;
        private System.Windows.Forms.Button buttonSelectFile2;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonJoin;
    }
}

