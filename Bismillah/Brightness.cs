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
    public partial class Brightness : Form
    {
        Bitmap objBitmap;
        Bitmap objBitmap1;

        public Brightness()
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

        private void OK_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            int a = (int)Convert.ToSingle(textBox3.Text);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int xg = (int)((w.R + w.G + w.B) / 3);
                    int xb = (int)xg + a;
                    if (xb > 255)
                        xb = 255;
                    else if (xb < 0)
                        xb = 0;
                    Color new_w = Color.FromArgb(xb, xb, xb);
                    objBitmap1.SetPixel(x, y, new_w);
                }
            pictureBox2.Image = objBitmap1;
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
