using System.Windows.Forms.DataVisualization.Charting;

namespace GPX_File_Viewer
{
    partial class RouteViewForm
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
            mapOverlay.Dispose();
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.comboBoxProvider = new System.Windows.Forms.ComboBox();
            this.comboBoxMapType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMapType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChartElevation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ChartElevation)).BeginInit();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(12, 57);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(605, 282);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZoomIn.Location = new System.Drawing.Point(551, 10);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(31, 23);
            this.buttonZoomIn.TabIndex = 1;
            this.buttonZoomIn.Text = "+";
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZoomOut.Location = new System.Drawing.Point(588, 10);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(31, 23);
            this.buttonZoomOut.TabIndex = 2;
            this.buttonZoomOut.Text = "-";
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.Button2_Click);
            // 
            // comboBoxProvider
            // 
            this.comboBoxProvider.FormattingEnabled = true;
            this.comboBoxProvider.Items.AddRange(new object[] {
            "Google Maps",
            "Open Cycle Map",
            "Bing Maps",
            "Open Street Maps"});
            this.comboBoxProvider.Location = new System.Drawing.Point(92, 12);
            this.comboBoxProvider.Name = "comboBoxProvider";
            this.comboBoxProvider.Size = new System.Drawing.Size(135, 21);
            this.comboBoxProvider.TabIndex = 3;
            this.comboBoxProvider.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // comboBoxMapType
            // 
            this.comboBoxMapType.FormattingEnabled = true;
            this.comboBoxMapType.Items.AddRange(new object[] {
            "Google Maps",
            "Open Cycle Map",
            "Bing Maps",
            "Open Street Maps"});
            this.comboBoxMapType.Location = new System.Drawing.Point(314, 12);
            this.comboBoxMapType.Name = "comboBoxMapType";
            this.comboBoxMapType.Size = new System.Drawing.Size(135, 21);
            this.comboBoxMapType.TabIndex = 4;
            this.comboBoxMapType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMapType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Map Provider";
            // 
            // labelMapType
            // 
            this.labelMapType.AutoSize = true;
            this.labelMapType.Location = new System.Drawing.Point(238, 15);
            this.labelMapType.Name = "labelMapType";
            this.labelMapType.Size = new System.Drawing.Size(55, 13);
            this.labelMapType.TabIndex = 6;
            this.labelMapType.Text = "Map Type";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Zoom Map";
            // 
            // ChartElevation
            // 
            this.ChartElevation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.ChartElevation.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartElevation.Legends.Add(legend1);
            this.ChartElevation.Location = new System.Drawing.Point(12, 345);
            this.ChartElevation.Name = "ChartElevation";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ChartElevation.Series.Add(series1);
            this.ChartElevation.Size = new System.Drawing.Size(605, 96);
            this.ChartElevation.TabIndex = 8;
            this.ChartElevation.Text = "chart1";
            this.ChartElevation.Click += new System.EventHandler(this.ChartElevation_Click);
            // 
            // RouteViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 453);
            this.Controls.Add(this.ChartElevation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelMapType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxMapType);
            this.Controls.Add(this.comboBoxProvider);
            this.Controls.Add(this.buttonZoomOut);
            this.Controls.Add(this.buttonZoomIn);
            this.Controls.Add(this.gMapControl1);
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "RouteViewForm";
            this.Text = "Route Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.ChartElevation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.ComboBox comboBoxProvider;
        private System.Windows.Forms.ComboBox comboBoxMapType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMapType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartElevation;
    }
}