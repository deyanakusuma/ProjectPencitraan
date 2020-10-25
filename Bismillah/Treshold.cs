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
    public partial class Treshold : Form
    {
        Bitmap objBitmap;
        Bitmap objBitmap1;

        public Treshold()
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
            int input = Convert.ToInt16(tresbox.Text);
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
            {
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int red = w.R;
                    int green = w.G;
                    int blue = w.B;
                    int xg = (int)((red + green + blue) / 3);
                    int xbw = 0;
                    if (xg >= input)
                    {
                        xbw = 255;
                    }
                    Color new_w = Color.FromArgb(xbw, xbw, xbw);
                    objBitmap1.SetPixel(x, y, new_w);
                }
                pictureBox2.Image = objBitmap1;
            }
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
