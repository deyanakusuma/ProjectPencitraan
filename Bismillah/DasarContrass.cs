using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bismillah
{
    public partial class DasarContrass : Form
    {
        Bitmap objBitmap;
        Bitmap objBitmap1;

        public DasarContrass()
        {
            InitializeComponent();
        }

        public void setBitmap(Bitmap bitmap)
        {
            objBitmap = bitmap;
            pictureBox1.Image = objBitmap;
        }

        public void setBitmap1(Bitmap bitmap)
        {
            objBitmap1 = bitmap;
            pictureBox2.Image = objBitmap1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float a = (float)(hScrollBar1.Value / 100.0);
            //button3.Text = a.ToString();
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int r = (int)(a * (float)w.R);
                    int g = (int)(a * (float)w.G);
                    int b = (int)(a * (float)w.B);
                    if (r < 0) r = 0;
                    if (r > 255) r = 255;
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;
                    Color wb = Color.FromArgb(r, g, b);
                    objBitmap1.SetPixel(x, y, wb);
                }
            pictureBox2.Image = objBitmap1;
            hScrollBar1.Value = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MiniPhotoShopDey mini = new MiniPhotoShopDey();
            mini.Show();
            mini.setBitmap(objBitmap);
            mini.setBitmap1(objBitmap1);
            this.Hide();
        }
    }
}
