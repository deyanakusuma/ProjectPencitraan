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
    public partial class Equalization : Form
    {
        Bitmap objBitmap;
        Bitmap objBitmap1;

        public Equalization()
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
            float[] h = new float[256];//inisialisasi variabel h dengan tipe float
            float[] c = new float[256];//inisialisasi variabel c dengan tipe float
            int i;//inisialisasi i
            objBitmap1 = new Bitmap(objBitmap); //memasukkan nilai objBitmap1 kedalam objBitmap3
            for (i = 0; i < 256; i++) h[i] = 0; //melakukan looping untuk setiap perhitungan h[i] diberikan nilai 0
            for (int x = 0; x < objBitmap.Width; x++)
            { //menghitung jumlah pixel horizontal
                for (int y = 0; y < objBitmap.Height; y++)
                { //menghitung jumlah pixel vertical
                    Color w = objBitmap.GetPixel(x, y);//membaca data pixel RGB pada image
                    int xg = (int)((w.R + w.G + w.B) / 3);//menghitung rata-rata derajat keabuan
                    h[xg] = h[xg] + 1;//memberikan nilai h dengan index xg dengan perhitungan setiap h[xg] baru ditambah dengan 1
                }
            }
            c[0] = h[0];//memberikan nilai c[0] dengan h[0]
            for (i = 1; i < 256; i++) //melakukan looping
                c[i] = c[i - 1] + h[i]; //perhitungan nilai c[i] didapat dari c[i-1]+h[i]
            int nx = objBitmap.Width; //memasukkan nilai objBitmap1.Width kedalam variabel nx
            int ny = objBitmap.Height;//memasukkan nilai objBitmap1.Height kedalam variabel ny
            for (int x = 0; x < objBitmap.Width; x++)
            { //menghitung jumlah pixel horizontal
                for (int y = 0; y < objBitmap.Height; y++)
                { //menghitung jumlah pixel vertical
                    Color w = objBitmap.GetPixel(x, y);//membaca data pixel RGB pada image
                    int xg = (int)((w.R + w.G + w.B) / 3);//menghitung rata-rata derajat keabuan
                    int xb = (int)((255 * c[xg] / nx / ny)); //melakukan perhitungan nilai xb
                    h[xb] = h[xb] + 1; //inkrement nilai h[xb] dengan ditambah 1
                    Color wb = Color.FromArgb(xb, xb, xb); //membuat RGB baru
                    objBitmap1.SetPixel(x, y, wb);//menyetting RGB baru
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
