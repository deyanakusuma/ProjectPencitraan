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
    public partial class Histogram : Form
    {
        Bitmap objBitmap;
        Bitmap objBitmap1;

        public Histogram()
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
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int xg = (int)((w.R + w.G + w.B) / 3);
                    Color new_w = Color.FromArgb(xg, xg, xg);
                    objBitmap1.SetPixel(x, y, new_w);
                }
            pictureBox2.Image = objBitmap1;
            float[] h = new float[256];//inisialisasi variabel h dengan tipe float
            int i;//inisialisasi variabel i dengan tipe int
            for (i = 0; i < 256; i++)
            { //melakukan looping
                h[i] = 0; //memberikan nilai h dengan index dari masing-masing i
            }
            for (int x = 0; x < objBitmap.Width; x++)
            { //menghitung jumlah pixel horizontal
                for (int y = 0; y < objBitmap.Height; y++)
                { //menghitung jumlah pixel vertical
                    Color w = objBitmap.GetPixel(x, y);//membaca data pixel RGB pada image
                    int xg = (int)((w.R + w.G + w.B) / 3);//menghitung rata-rata derajat keabuan
                    h[xg] = h[xg] + 1;//memberikan nilai h dengan index xg dengan perhitungan setiap h[xg] baru ditambah dengan 1
                }
            }
            for (i = 0; i < 256; i++)
            { //melakukan looping untuk menampilkan hasil pada chart
                chart1.Series["Series1"].Points.AddXY(i, h[i]); //menampilkan hasil pada chart1
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
