using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_06_IUP
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        CircleDetect cf = new CircleDetect();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Image File";
            ofd.Filter = "Image (*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|" + "All File(*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String path = ofd.FileName.ToString();
                cf.LoadOriginal(path);
                pictureBox1.ImageLocation = path;
            }
        }

        private void btn_filter_Click(object sender, EventArgs e)
        {
            cf.Filter();
            pictureBox2.ImageLocation = "detected.jpg";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPEG files(*.jpeg)|*.jpeg"; // Saving file in jpeg Format
            if (DialogResult.OK == sfd.ShowDialog())
            {
                this.pictureBox2.Image.Save(sfd.FileName, ImageFormat.Jpeg);
            }
        }
    }
}
