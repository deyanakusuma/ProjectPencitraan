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
    public partial class GrafikAutoLevel : Form
    {
        Bitmap objBitmap;
        Bitmap objBitmap1;

        public GrafikAutoLevel()
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

        private void button1_Click(object sender, EventArgs e)
        {
            float[] h = new float[256]; //inisialisasi variabel h dengan tipe float
            int i;//inisialisasi nilai i
            objBitmap1 = new Bitmap(objBitmap); //memasukkan nilai objBitmap1 kedalam objBitmap4
            int xgmax = 0; //inisialisasi xgmax
            int xgmin = 255; //inisialisasi xgmin
            for (int x = 0; x < objBitmap.Width; x++)
            { //menghitung jumlah pixel horizontal
                for (int y = 0; y < objBitmap.Height; y++)
                { //menghitung jumlah pixel vertical
                    Color w = objBitmap.GetPixel(x, y);//membaca data pixel RGB pada image
                    int xg = (int)((w.R + w.G + w.R) / 3);//menghitung rata-rata derajat keabuan
                    if (xg > xgmax) xgmax = xg; //jika xg lebih besar dari xgmax, maka xgmax = xg
                    if (xg < xgmin) xgmin = xg; //jika xg lebih kecil dari xgmin, maka xgmin = xg
                }
            }
            for (int x = 0; x < objBitmap.Width; x++)
            { //menghitung jumlah pixel horizontal
                for (int y = 0; y < objBitmap.Height; y++)
                { //menghitung jumlah pixel vertical
                    Color w = objBitmap.GetPixel(x, y); //membaca data pixel RGB pada image
                    int xg = (int)((w.R + w.G + w.B) / 3);//menghitung rata-rata derajat keabuan
                    int xb = (int)(255 * (xg - xgmin) / (xgmax - xgmin)); //melakukan perhitungan nilai xb
                    h[xb] = h[xb] + 1; //inkrement nilai h[xb] dengan ditambah 1
                    Color new_w = Color.FromArgb(xb, xb, xb); //membuat RGB baru
                    objBitmap1.SetPixel(x, y, new_w); //menyetting RGB baru
                }
            }
            pictureBox2.Image = objBitmap1;//menampilkan hasil RGB baru ke pictureBox2
            for (i = 0; i < 256; i++) //melakukan looping untuk menampilkan hasil pada chart
            {
                chart1.Series["Series1"].Points.AddXY(i, h[i]);//hasil ditampilkan pada chart1
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MiniPhotoShopDey mini = new MiniPhotoShopDey();
            mini.Show();
            mini.setBitmap(objBitmap);
            mini.setBitmap1(objBitmap1);
            this.Hide();
        }
    }
}
