using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPX_File_Viewer
{
    public partial class CompressionOptions : Form
    {
        private bool canCompress = false;
        public delegate void CompressionDelegate(CompressionArguments compargs);
        public CompressionDelegate compressionDelegate;
        public CompressionOptions()
        {
            InitializeComponent();
            this.CenterToParent();
            comboBoxAccuracy.SelectedItem = comboBoxAccuracy.Items[0];
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (canCompress)
            {
                

            }
            this.Close();
        }

        private void buttonCompressFile_Click(object sender, EventArgs e)
        {
            CompressionArguments args = new CompressionArguments();
            args.Accuracy = Convert.ToInt32(comboBoxAccuracy.SelectedItem);
            args.RetainCustomData = checkBoxCustom.Checked;
            args.RetainElevation = checkBoxElevation.Checked;
            compressionDelegate(args);
            canCompress = true;
            this.Close();

        }
    }
}
