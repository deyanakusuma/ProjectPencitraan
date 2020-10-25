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
    public partial class NoiseGaussian1 : Form
    {
        Bitmap objBitmap1;
        Bitmap objBitmap2;
        Bitmap objBitmapFG;

        public NoiseGaussian1()
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

        public void setBitmap3(Bitmap bitmap)
        {
            objBitmapFG = bitmap;
            pictureBox2.Image = objBitmapFG;
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
            mini.setBitmap3(objBitmapFG);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            objBitmapFG = new Bitmap(objBitmap2); //objBitmap4 menampung nilai objBitmap2
            for (int x = 1; x < objBitmap2.Width - 1; x++) //looping untuk width dengan mengambil hasil nilai gaussian
                for (int y = 1; y < objBitmap2.Height - 1; y++) //looping untuk height dengan mengambil hasil gaussian
                {
                    Color w1 = objBitmap2.GetPixel(x - 1, y - 1); //untuk mengambil warna dari pixel gaussian dengan posisi x-1 , y-1
                    Color w2 = objBitmap2.GetPixel(x - 1, y); //untuk mengambil warna dari pixel gaussian dengan posisi x-1 , y
                    Color w3 = objBitmap2.GetPixel(x - 1, y + 1); //untuk mengambil warna dari pixel gaussian dengan posisi x-1 , y+1
                    Color w4 = objBitmap2.GetPixel(x, y - 1); //untuk mengambil warna dari pixel gaussian dengan posisi x, y-1
                    Color w5 = objBitmap2.GetPixel(x, y); //untuk mengambil warna dari pixel gaussian dengan posisi x,y
                    Color w6 = objBitmap2.GetPixel(x, y + 1); //untuk mengambil warna dari pixel gaussian dengan posisi x, y+1
                    Color w7 = objBitmap2.GetPixel(x + 1, y - 1); //untuk mengambil warna dari pixel gaussian dengan posisi x-1 , y-1
                    Color w8 = objBitmap2.GetPixel(x + 1, y); //untuk mengambil warna dari pixel gaussian dengan posisi x-1 , y
                    Color w9 = objBitmap2.GetPixel(x + 1, y + 1); //untuk mengambil warna dari pixel gaussian dengan posisi x-1 , y+1
                    int x1 = w1.R; //dari pengambilan warna tersebut dikalikan dengan warna merah dan ditampung pada x1
                    int x2 = w2.R; //dari pengambilan warna tersebut dikalikan dengan warna merah dan ditampung pada x2
                    int x3 = w3.R; //dari pengambilan warna tersebut dikalikan dengan warna merah dan ditampung pada x3
                    int x4 = w4.R; //dari pengambilan warna tersebut dikalikan dengan warna merah dan ditampung pada x4
                    int x5 = w5.R; //dari pengambilan warna tersebut dikalikan dengan warna merah dan ditampung pada x5
                    int x6 = w6.R; //dari pengambilan warna tersebut dikalikan dengan warna merah dan ditampung pada x6
                    int x7 = w7.R; //dari pengambilan warna tersebut dikalikan dengan warna merah dan ditampung pada x7
                    int x8 = w8.R; //dari pengambilan warna tersebut dikalikan dengan warna merah dan ditampung pada x8
                    int x9 = w9.R; //dari pengambilan warna tersebut dikalikan dengan warna merah dan ditampung pada x9
                    int xb = (int)((x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9) / 9); // menghitung filter rata - rata dari seluruh pixel yg telah diaktifkan
                    if (xb < 0) xb = 0; //jika nilai xb kurang dari 0
                    if (xb > 255) xb = 255; //menghitung tracehold untuk mengubah filter dan efeknya
                    Color wb = Color.FromArgb(xb, xb, xb); //mengubah pixel warna RGB baru
                    objBitmapFG.SetPixel(x, y, wb); //menyetting nilai RGB baru
                }
            pictureBox2.Image = objBitmapFG; //menampilkan pada pictureBox4
        }
    }
}
