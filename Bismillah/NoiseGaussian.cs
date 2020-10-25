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
    public partial class NoiseGaussian : Form
    {

        Bitmap objBitmap1;
        Bitmap objBitmap2;

        public NoiseGaussian()
        {
            InitializeComponent();
        }

        public void setBitmap1(Bitmap bitmap)
        {
            objBitmap1 = bitmap;
            pictureBox2.Image = objBitmap1;
        }

        public void setBitmap2(Bitmap bitmap)
        {
            objBitmap2 = bitmap;
            pictureBox2.Image = objBitmap2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objBitmap2 = new Bitmap(objBitmap1); //menyimpan file objBitmap1 ke objBitmap 2
            Random r = new Random(); //obj r menampung warna secara random 
            for (int x = 0; x < objBitmap1.Width; x++)
            { //looping untuk width dengan mengambil nilai grayscale
                for (int y = 0; y < objBitmap1.Height; y++)
                { //looping untuk height dengan mengambil nilai grayscale
                    Color w = objBitmap1.GetPixel(x, y);//mengambil pixel RGB pada image
                    int xg = w.R; //menghitung nilai R baru
                    int xb = xg; //menampung nilai xg ke xb
                    int nr = r.Next(0, 100); //nilai r antara 0 hingga 100
                    if (nr < Convert.ToSingle(gsbox.Text)) //jika nilai nr kurang dari gaussian 
                    {
                        int ns = r.Next(0, 256) - 128; //bilangan acak antara -128 sd 128
                        xb = (int)(xg + ns); //nilai xg ditambah nilai ns
                        if (xb < 0) xb = -xb; // jika nilai xb kurang dari 0
                        if (xb > 255) xb = 255; //jika nilai xb lebih besar dari 255
                    }
                    Color wb = Color.FromArgb(xb, xb, xb); //mengganti nilai pixel baru
                    objBitmap2.SetPixel(x, y, wb); //menyetting nilai pixel baru
                }
                pictureBox2.Image = objBitmap2; //menampilkan pada pictureBox2
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MiniPhotoShopDey mini = new MiniPhotoShopDey();
            mini.Show();
            //mini.setBitmap1(objBitmap);
            mini.setBitmap2(objBitmap2);
            this.Hide();
        }

        private void NoiseGaussian_Load(object sender, EventArgs e)
        {

        }
    }
}
