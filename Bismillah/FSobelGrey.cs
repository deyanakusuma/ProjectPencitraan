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
    public partial class FSobelGrey : Form
    {
        Bitmap objBitmap1;
        Bitmap objBitmap2;
        //Bitmap objBitmapFG;

        public FSobelGrey()
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
            objBitmap2 = new Bitmap(objBitmap1); //objBitmap5 manmpung nilai grayscale dari objBitmap1
            for (int x = 1; x < objBitmap1.Width - 1; x++) //looping untuk width dengan mengambil hasil greyscale
                for (int y = 1; y < objBitmap1.Height - 1; y++) //looping untuk height dengan mengambil hasil greyscale
                {
                    Color w1 = objBitmap1.GetPixel(x - 1, y - 1); //untuk mengambil warna dari pixel dengan posisi x-1 , y-1
                    Color w2 = objBitmap1.GetPixel(x - 1, y); //untuk mengambil warna dari pixel dengan posisi x-1 , y
                    Color w3 = objBitmap1.GetPixel(x - 1, y + 1); //untuk mengambil warna dari pixel dengan posisi x-1 , y+1
                    Color w4 = objBitmap1.GetPixel(x, y - 1); //untuk mengambil warna dari pixel dengan posisi x, y-1
                    Color w5 = objBitmap1.GetPixel(x, y); //untuk mengambil warna dari pixel dengan posisi x, y
                    Color w6 = objBitmap1.GetPixel(x, y + 1); //untuk mengambil warna dari pixel dengan posisi x, y+1
                    Color w7 = objBitmap1.GetPixel(x + 1, y - 1); //untuk mengambil warna dari pixel dengan posisi x-1 , y-1
                    Color w8 = objBitmap1.GetPixel(x + 1, y); //untuk mengambil warna dari pixel dengan posisi x+1 , y
                    Color w9 = objBitmap1.GetPixel(x - 1, y + 1); //untuk mengambil warna dari pixel dengan posisi x-1 , y+1
                    int x1 = w1.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x1
                    int x2 = w2.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x2
                    int x3 = w3.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x3
                    int x4 = w4.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x4
                    int x5 = w5.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x5
                    int x6 = w6.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x6
                    int x7 = w7.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x7
                    int x8 = w8.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x8
                    int x9 = w9.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x9
                    int xh = (int)(-x1 - 2 * x4 - x7 + x3 + 2 * x6 + x9); // variabel xh diperoleh dari rumus sobel untuk mencari garis tepi pada bagian pixel horizontal
                    int xv = (int)(-x1 - 2 * x2 - x3 + x7 + 2 * x8 + x9); // variabel xv diperoleh dari rumus sobel untuk mencari garis tepi pada bagian pixel vertical
                    int xb = (int)(xh + xv); //dari hasil deteksi garis tepi pada pixel horizontal dan vertical dijumlahkan 
                    if (xb < 0) xb = -xb; //jika nilai xb lebih kecil dari 0 maka xb diset negatif
                    if (xb > 255) xb = 255; //jika xb lebih besar dari 225 maka pixel xb itu diubah menjadi 255
                    Color wb = Color.FromArgb(xb, xb, xb);  //mengubah warna RGB baru dengan nilai sobel
                    objBitmap2.SetPixel(x, y, wb); //menyetting nilai RGB baru
                }
            pictureBox2.Image = objBitmap2; //menampilkan pada pictureBox5
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MiniPhotoShopDey mini = new MiniPhotoShopDey();
            mini.Show();
            mini.setBitmap2(objBitmap2);
            //mini.setBitmap3(objBitmapFG);
            this.Hide();
        }
    }
}
