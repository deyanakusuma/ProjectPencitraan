using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Bismillah
{
    public partial class MiniPhotoShopDey : Form
    {
        Bitmap objBitmap;
        Bitmap objBitmap1;
        Bitmap objBitmap2;
        Bitmap objBitmap3;
        Bitmap objBitmap4;
        Bitmap objBitmapFG;
        Bitmap objBitmapS;
        Bitmap objBitmapSo;
        //private int childFormNumber = 0;

        public MiniPhotoShopDey()
        {
            InitializeComponent();
        }

        public void setBitmap(Bitmap bitmap) {
            objBitmap = bitmap;
            pictureBox1.Image = objBitmap;
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

        public void setBitmap4(Bitmap bitmap)
        {
            objBitmapSo = bitmap;
            pictureBox2.Image = objBitmapSo;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objBitmap;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = saveFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap1.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    objBitmap1.SetPixel(x, y, w);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    objBitmap1.SetPixel(x, objBitmap.Height - 1 - y, w);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    objBitmap1.SetPixel(objBitmap.Width - 1 - x, y, w);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void rotate90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap, new Size(objBitmap.Height, objBitmap.Width));
            for (int x = 0; x < objBitmap.Height; x++)
                for (int y = 0; y < objBitmap.Width; y++)
                {
                    Color w = objBitmap.GetPixel(y, objBitmap.Height - 1 - x);
                    objBitmap1.SetPixel(x, y, w);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void rotate180ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    objBitmap1.SetPixel(objBitmap.Width - 1 - x, objBitmap.Height - 1 - y, w);
                }
            pictureBox2.Image = objBitmap1; 
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
            {
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int layer_red = w.R;
                    Color new_w = Color.FromArgb(layer_red, 0, 0);
                    objBitmap1.SetPixel(x, y, new_w);
                }
                pictureBox2.Image = objBitmap1;
            }
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
            {
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int layer_green = w.G;
                    Color new_w = Color.FromArgb(0, layer_green, 0);
                    objBitmap1.SetPixel(x, y, new_w);
                }
                pictureBox2.Image = objBitmap1;
            }
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
            {
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int layer_blue = w.B;
                    Color new_w = Color.FromArgb(0, 0, layer_blue);
                    objBitmap1.SetPixel(x, y, new_w);
                }
                pictureBox2.Image = objBitmap1;
            }
        }

        private void sephiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
            {
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    Color new_w = Color.FromArgb((byte)(w.R), (byte)(w.R * 0.82), (byte)(w.R * 0.28));
                    objBitmap1.SetPixel(x, y, new_w);
                }
                pictureBox2.Image = objBitmap1;
            }
        }

        private void grayscaleAsliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap1.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((r + g + b) / 3);
                    Color wb = Color.FromArgb(xg, xg, xg);
                    objBitmap1.SetPixel(x, y, wb);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void grayscaleRedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
            {
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int abu_red = w.R;
                    Color new_w = Color.FromArgb(abu_red, abu_red, abu_red);
                    objBitmap1.SetPixel(x, y, new_w);
                }
                pictureBox2.Image = objBitmap1;
            }
        }

        private void grayscaleGreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
            {
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int abu_hijau = w.G;
                    Color new_w = Color.FromArgb(abu_hijau, abu_hijau, abu_hijau);
                    objBitmap1.SetPixel(x, y, new_w);
                }
                pictureBox2.Image = objBitmap1;
            }
        }

        private void grayscaleBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
            {
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int abu_biru = w.B;
                    Color new_w = Color.FromArgb(abu_biru, abu_biru, abu_biru);
                    objBitmap1.SetPixel(x, y, new_w);
                }
                pictureBox2.Image = objBitmap1;
            }
        }

        private void kuantisasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kuantisasi kn = new Kuantisasi();
            kn.Show();
            kn.setBitmap(objBitmap);
            this.Hide();
        }

        private void keabuanRataRataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            int rata = 0;
            int avg;
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int red = w.R;
                    int green = w.G;
                    int blue = w.B;
                    rata += (int)((red + green + blue) / 3);
                }
            avg = rata / (objBitmap.Width * objBitmap.Height);

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
                    if (xg >= avg)
                    {
                        xbw = 255;
                    }
                    Color new_w = Color.FromArgb(xbw, xbw, xbw);
                    objBitmap1.SetPixel(x, y, new_w);
                }
                pictureBox2.Image = objBitmap1;
            }
        }

        private void inputTresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Treshold tr = new Treshold();
            tr.Show();
            tr.setBitmap(objBitmap);
            this.Hide();
        }

        private void inversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
            {
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int xg = (int)((w.R + w.G + w.B) / 3);
                    int xi = 255 - xg;
                    Color new_w = Color.FromArgb(xi, xi, xi);
                    objBitmap1.SetPixel(x, y, new_w);
                }
                pictureBox2.Image = objBitmap1;
            }
        }

        private void autoLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            int xgmax = 0;
            int xgmin = 255;
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int xg = (int)((w.R + w.G + w.B) / 3);
                    if (xg > xgmax) xgmax = xg;
                    if (xg < xgmin) xgmin = xg;
                }
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int xg = (int)((w.R + w.G + w.B) / 3);
                    int xb = (int)(128 * (xg - xgmin) / (xgmax - xgmin));
                    Color new_w = Color.FromArgb(xb, xb, xb);
                    objBitmap1.SetPixel(x, y, new_w);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void brihtnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brightness bri = new Brightness();
            bri.Show();
            bri.setBitmap(objBitmap);
            this.Hide();
        }

        private void contrassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contrass con = new Contrass();
            con.Show();
            con.setBitmap(objBitmap);
            this.Hide();
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Histogram his = new Histogram();
            his.Show();
            his.setBitmap(objBitmap);
            //his.setBitmap1(objBitmap1);
            this.Hide();
        }

        private void cDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cdf c = new Cdf();
            c.Show();
            c.setBitmap(objBitmap);
            this.Hide();
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pdf p = new Pdf();
            p.Show();
            p.setBitmap(objBitmap);
            this.Hide();
        }

        private void equalizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Equalization eq = new Equalization();
            eq.Show();
            eq.setBitmap(objBitmap);
            this.Hide();
        }

        private void grafikAutoLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrafikAutoLevel gto = new GrafikAutoLevel();
            gto.Show();
            gto.setBitmap(objBitmap);
            this.Hide();
        }

        private void filterNode4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float[] a = new float[5];
            a[0] = (float)0.2;
            a[1] = (float)0.2;
            a[2] = (float)0.2;
            a[3] = (float)0.2;
            a[4] = (float)0.2;
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width - 1; x++)
                for (int y = 1; y < objBitmap.Height - 1; y++)
                {
                    Color w1 = objBitmap.GetPixel(x - 1, y);
                    Color w2 = objBitmap.GetPixel(x + 1, y);
                    Color w3 = objBitmap.GetPixel(x, y - 1);
                    Color w4 = objBitmap.GetPixel(x, y + 1);
                    Color w = objBitmap.GetPixel(x, y);
                    int x1 = (w1.R + w1.G + w1.B) / 3;
                    int x2 = (w2.R + w2.G + w2.B) / 3;
                    int x3 = (w3.R + w3.G + w3.B) / 3;
                    int x4 = (w4.R + w4.G + w4.B) / 3;
                    int xg = (w.R + w.G + w.B) / 3;
                    int xb = (int)(a[0] * xg);
                    xb = (int)(xb + a[1] * x1 + a[2] * x2 + a[3] * x3 + a[4] * x4);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objBitmap1.SetPixel(x, y, wb);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void filterNode8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float[] a = new float[10];
            a[1] = (float)0.1;
            a[2] = (float)0.1;
            a[3] = (float)0.1;
            a[4] = (float)0.1;
            a[5] = (float)0.2;
            a[6] = (float)0.1;
            a[7] = (float)0.1;
            a[8] = (float)0.1;
            a[9] = (float)0.1;
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width - 1; x++)
                for (int y = 1; y < objBitmap.Height - 1; y++)
                {
                    Color w1 = objBitmap.GetPixel(x - 1, y - 1);
                    Color w2 = objBitmap.GetPixel(x - 1, y);
                    Color w3 = objBitmap.GetPixel(x - 1, y + 1);
                    Color w4 = objBitmap.GetPixel(x, y - 1);
                    Color w5 = objBitmap.GetPixel(x, y);
                    Color w6 = objBitmap.GetPixel(x, y + 1);
                    Color w7 = objBitmap.GetPixel(x + 1, y - 1);
                    Color w8 = objBitmap.GetPixel(x + 1, y);
                    Color w9 = objBitmap.GetPixel(x + 1, y + 1);
                    int x1 = (w1.R + w1.G + w1.B) / 3;
                    int x2 = (w2.R + w2.G + w2.B) / 3;
                    int x3 = (w3.R + w3.G + w3.B) / 3;
                    int x4 = (w4.R + w4.G + w4.B) / 3;
                    int x5 = (w5.R + w5.G + w5.B) / 3;
                    int x6 = (w6.R + w6.G + w6.B) / 3;
                    int x7 = (w7.R + w7.G + w7.B) / 3;
                    int x8 = (w8.R + w8.G + w8.B) / 3;
                    int x9 = (w9.R + w9.G + w9.B) / 3;
                    int xb = (int)(a[1] * x1 + a[2] * x2 + a[3] * x3);
                    xb = (int)(xb + a[4] * x4 + a[5] * x5 + a[6] * x6);
                    xb = (int)(xb + a[7] * x7 + a[8] * x8 + a[9] * x9);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objBitmap1.SetPixel(x, y, wb);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void fRataRataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap3 = new Bitmap(objBitmap1); //objBitmap3 manampung nilai objBitmap1
            for (int x = 1; x < objBitmap1.Width - 1; x++)  //looping untuk width dengan mengambil hasil greyscale
                for (int y = 1; y < objBitmap1.Height - 1; y++) //looping untuk height dengan mengambil hasil greyscale
                {
                    Color w1 = objBitmap1.GetPixel(x - 1, y - 1); //untuk mengambil warna dari pixel dengan posisi x-1 , y-1
                    Color w2 = objBitmap1.GetPixel(x - 1, y); //untuk mengambil warna dari pixel dengan posisi x-1 , y
                    Color w3 = objBitmap1.GetPixel(x - 1, y + 1); //untuk mengambil warna dari pixel dengan posisi x-1 , y+1
                    Color w4 = objBitmap1.GetPixel(x, y - 1); //untuk mengambil warna dari pixel dengan posisi x, y-1
                    Color w5 = objBitmap1.GetPixel(x, y); //untuk mengambil warna dari pixel dengan posisi x , y
                    Color w6 = objBitmap1.GetPixel(x, y + 1); //untuk mengambil warna dari pixel dengan posisi x , y+1
                    Color w7 = objBitmap1.GetPixel(x + 1, y - 1); //untuk mengambil warna dari pixel dengan posisi x+1 , y-1
                    Color w8 = objBitmap1.GetPixel(x + 1, y); //untuk mengambil warna dari pixel dengan posisi x+1 , y
                    Color w9 = objBitmap1.GetPixel(x + 1, y + 1); //untuk mengambil warna dari pixel dengan posisi x+1 , y+1
                    int x1 = w1.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x1                    
                    int x2 = w2.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x2
                    int x3 = w3.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x3
                    int x4 = w4.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x4
                    int x5 = w5.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x5
                    int x6 = w6.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x6
                    int x7 = w7.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x7
                    int x8 = w8.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x8
                    int x9 = w9.R; //dari pengambilan warna tersebut dikalikan dengan warna merah ditampung pada x9
                    int xb = (int)((x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9) / 9); // menghitung filter rata - rata dari seluruh pixel yg telah diaktifkan
                    if (xb < 0) xb = 0; //jika nilai xb kurang dari 0
                    if (xb > 255) xb = 255; //menghitung tracehold untuk mengubah filter dan efeknya
                    Color wb = Color.FromArgb(xb, xb, xb);  //mengubah pixel warna RGB baru
                    objBitmap3.SetPixel(x, y, wb); //menyetting warna RGB baru
                }
            pictureBox2.Image = objBitmap3; //menampilkannya pada pictureBox3
        }

        private void fRataRataDanGaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoiseGaussian ng = new NoiseGaussian();
            ng.Show();
            ng.setBitmap1(objBitmap1);
            this.Hide();
        }

        private void fRataRataDanGaussianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NoiseGaussian1 ng = new NoiseGaussian1();
            ng.Show();
            ng.setBitmap1(objBitmap1);
            this.Hide();
        }

        private void fSobelGrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSobelGrey sg = new FSobelGrey();
            sg.Show();
            sg.setBitmap1(objBitmap1);
            this.Hide();
        }

        private void fSobelDanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSobelRataGau sob = new FSobelRataGau();
            sob.Show();
            sob.setBitmap1(objBitmap1);
            this.Hide();
        }

        private void sharpnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmapS = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((r + g + b) / 3);
                    Color wb = Color.FromArgb(xg, xg, xg);
                    objBitmap.SetPixel(x, y, wb);
                }
            for (int x = 1; x < objBitmap.Width-1; x++)
                for (int y = 1; y < objBitmap.Height-1; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int xg = w.R;
                    Color w1 = objBitmap.GetPixel(x - 1, y - 1);
                    Color w2 = objBitmap.GetPixel(x - 1, y);
                    Color w3 = objBitmap.GetPixel(x - 1, y + 1);
                    Color w4 = objBitmap.GetPixel(x, y - 1);
                    Color w5 = objBitmap.GetPixel(x, y);
                    Color w6 = objBitmap.GetPixel(x, y + 1);
                    Color w7 = objBitmap.GetPixel(x + 1, y - 1);
                    Color w8 = objBitmap.GetPixel(x + 1, y);
                    Color w9 = objBitmap.GetPixel(x + 1, y + 1);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int x5 = w5.R;
                    int x6 = w6.R;
                    int x7 = w7.R;
                    int x8 = w8.R;
                    int x9 = w9.R;
                    int xt1 = (int)((x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9)/9);
                    int xt2 = (int)(-x1 - 2*x2 - x3 + x7 + 2*x8 + x9);
                    int xt3 = (int)(-x1 - 2 * x4 -  x7 + x3+ 2 * x6 + x9);
                    int xb = (int)(xt1 + xt2+xt3);
                    if (xb < 0) xb = -xb;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objBitmapS.SetPixel(x, y, wb);
                }
               pictureBox2.Image = objBitmapS;
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DasarBrightness db = new DasarBrightness();
            db.Show();
            db.setBitmap(objBitmap);
            this.Hide();

        }

        private void contrassToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DasarContrass dc = new DasarContrass();
            dc.Show();
            dc.setBitmap(objBitmap);
            this.Hide();
        }

        private void inversToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int r = (int)(255-w.R);
                    int g = (int)(255-w.G);
                    int b = (int)(255-w.B);
                    Color wb = Color.FromArgb(r, g, b);
                    objBitmap1.SetPixel(x, y, wb);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void autoLevelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            int rmin = 255;
            int gmin = 255;
            int bmin = 255;
            int rmax = 0;
            int gmax = 0;
            int bmax = 0;
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    if (r < rmin) rmin = r;
                    if (r > rmax) rmax = r;
                    if (g < gmin) gmin = g;
                    if (g > gmax) gmax = g;
                    if (b < bmin) bmin = b;
                    if (b > bmax) bmax = b;
                }
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int rbaru = (int)(255 * (r - rmin) / (rmax - rmin));
                    int gbaru = (int)(255 * (g - gmin) / (gmax - gmin));
                    int bbaru = (int)(255 * (b - bmin) / (bmax - bmin));
                    Color wb = Color.FromArgb(rbaru, gbaru, bbaru);
                    objBitmap1.SetPixel(x, y, wb);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void noiseGaussianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            Random r = new Random();
            Color wb;
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    int p = r.Next(0, 100);
                    Color w = objBitmap.GetPixel(x, y);
                    wb = w;
                    if (p < 20)
                    {
                        int nr = r.Next(0, 200);
                        int rb = w.R + nr - 100;
                        if (rb < 0) rb = 0;
                        if (rb > 255) rb = 255;
                        int gb = w.G + nr - 100;
                        if (gb < 0) gb = 0;
                        if (gb > 255) gb = 255;
                        int bb = w.B + nr - 100;
                        if (bb < 0) bb = 0;
                        if (bb > 255) bb = 255;
                        wb = Color.FromArgb(rb, gb, bb);
                    }
                    objBitmap1.SetPixel(x, y, wb);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void filterRataRataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width-1; x++)
                for (int y = 1; y < objBitmap.Height-1; y++)
                {
                    Color w1 = objBitmap.GetPixel(x - 1, y - 1);
                    Color w2 = objBitmap.GetPixel(x - 1, y);
                    Color w3 = objBitmap.GetPixel(x - 1, y + 1);
                    Color w4 = objBitmap.GetPixel(x, y - 1);
                    Color w5 = objBitmap.GetPixel(x, y);
                    Color w6 = objBitmap.GetPixel(x, y + 1);
                    Color w7 = objBitmap.GetPixel(x + 1, y - 1);
                    Color w8 = objBitmap.GetPixel(x + 1, y);
                    Color w9 = objBitmap.GetPixel(x + 1, y + 1);
                    int r = (int)((w1.R + w2.R + w3.R + w4.R + w5.R + w6.R + w7.R + w8.R + w9.R) / 9);
                    int g = (int)((w1.G + w2.G + w3.G + w4.G + w5.G + w6.G + w7.G + w8.G + w9.G) / 9);
                    int b = (int)((w1.B + w2.B + w3.B + w4.B + w5.B + w6.B + w7.B + w8.B + w9.B) / 9);
                    Color wb = Color.FromArgb(r, g, b);
                    objBitmap1.SetPixel(x, y, wb);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void deteksiTepiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width - 1; x++)
                for (int y = 1; y < objBitmap.Height - 1; y++)
                {
                    Color w1 = objBitmap.GetPixel(x - 1, y - 1);
                    Color w2 = objBitmap.GetPixel(x - 1, y);
                    Color w3 = objBitmap.GetPixel(x - 1, y + 1);
                    Color w4 = objBitmap.GetPixel(x, y - 1);
                    Color w5 = objBitmap.GetPixel(x, y);
                    Color w6 = objBitmap.GetPixel(x, y + 1);
                    Color w7 = objBitmap.GetPixel(x + 1, y - 1);
                    Color w8 = objBitmap.GetPixel(x + 1, y);
                    Color w9 = objBitmap.GetPixel(x + 1, y + 1);
                    int rh = (int)(-w1.R - w4.R - w7.R + w3.R + w6.R + w9.R);
                    int gh = (int)(-w1.G - w4.G - w7.G + w3.G + w6.G + w9.G);
                    int bh = (int)(-w1.B - w4.B - w7.B + w3.B + w6.B + w9.B);
                    int rv = (int)(-w1.R - w2.R - w3.R + w7.R + w8.R + w9.R);
                    int gv = (int)(-w1.G - w2.G - w3.G + w7.G + w8.G + w9.G);
                    int bv = (int)(-w1.B - w2.B - w3.B + w7.B + w8.B + w9.B);
                    int r = (int)(rh + rv);
                    if (r < 0) r = -r;
                    if (r > 255) r = 255;
                    int g = (int)(gh + gv);
                    if (g < 0) g = -g;
                    if (g > 255) g = 255;
                    int b = (int)(bh + bv);
                    if (b < 0) b = -b;
                    if (b > 255) b = 255;
                    Color wb = Color.FromArgb(r, g, b);
                    objBitmap1.SetPixel(x, y, wb);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void sharpnessToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width - 1; x++)
            for (int y = 1; y < objBitmap.Height - 1; y++)
            {
                Color w1 = objBitmap.GetPixel(x - 1, y - 1);
                Color w2 = objBitmap.GetPixel(x - 1, y);
                Color w3 = objBitmap.GetPixel(x - 1, y + 1);
                Color w4 = objBitmap.GetPixel(x, y - 1);
                Color w5 = objBitmap.GetPixel(x, y);
                Color w6 = objBitmap.GetPixel(x, y + 1);
                Color w7 = objBitmap.GetPixel(x + 1, y - 1);
                Color w8 = objBitmap.GetPixel(x + 1, y);
                Color w9 = objBitmap.GetPixel(x + 1, y + 1);
                int rh = (int)(-w1.R - w4.R - w7.R + w3.R + w6.R + w9.R);
                int gh = (int)(-w1.G - w4.G - w7.G + w3.G + w6.G + w9.G);
                int bh = (int)(-w1.B - w4.B - w7.B + w3.B + w6.B + w9.B);
                int rv = (int)(-w1.R - w2.R - w3.R + w7.R + w8.R + w9.R);
                int gv = (int)(-w1.G - w2.G - w3.G + w7.G + w8.G + w9.G);
                int bv = (int)(-w1.B - w2.B - w3.B + w7.B + w8.B + w9.B);
                int rr = (int)((w1.R + w2.R + w3.R + w4.R + w5.R + w6.R + w7.R + w8.R + w9.R) / 9); 
                int gr = (int)((w1.G + w2.G + w3.G + w4.G + w5.G + w6.G + w7.G + w8.G + w9.G) / 9);
                int br = (int)((w1.B + w2.B + w3.B + w4.B + w5.B + w6.B + w7.B + w8.B + w9.B) / 9);
                int r = (int)(rr + rh + rv);
                if (r < 0) r = -r;
                if (r > 255) r = 255;
                int g = (int)(gr + gh + gv);
                if (g < 0) g = -g;
                if (g > 255) g = 255;
                int b = (int)(br + bh + bv);
                if (b < 0) b = -b;
                if (b > 255) b = 255;
                Color wb = Color.FromArgb(r, g, b);
                objBitmap1.SetPixel(x, y, wb);
            }
            pictureBox2.Image = objBitmap1;
        }
    }
}
