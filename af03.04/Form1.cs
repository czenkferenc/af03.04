using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace af03._04
{
    public partial class Form1 : Form
    {
        Bitmap source, dest;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            source = new Bitmap(Image.FromFile(@"..\..\resurse\parrot.jpg"));
            pb1.Image = source;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dest = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    int t = (c.R + c.G + c.B) / 3;
                    dest.SetPixel(i, j, Color.FromArgb(t, t, t));
                }
            }
            pb2.Image = dest;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dest = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    //int t = (c.R + c.G + c.B) / 3;
                    int k = 100;
                    dest.SetPixel(i, j, Color.FromArgb(Math.Min(c.R + k,255), Math.Min(c.G + k, 255), Math.Min(c.B + k, 255)));
                }
            }
            pb2.Image = dest;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dest = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    //int t = (c.R + c.G + c.B) / 3;
                    int k = 100;
                    dest.SetPixel(i, j, Color.FromArgb(Math.Max(c.R - k, 0), Math.Max(c.G - k, 0), Math.Max(c.B - k, 0)));
                }
            }
            pb2.Image = dest;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dest = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    dest.SetPixel(i, j, Color.FromArgb(255-c.R,255-c.G,255-c.B));
                }
            }
            pb2.Image = dest;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dest = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    dest.SetPixel(i, j, Color.FromArgb(c.G, c.B, c.R));
                }
            }
            pb2.Image = dest;
        }

        private void btn_rotate_Click(object sender, EventArgs e)
        {
            dest = new Bitmap(source.Height, source.Width);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    dest.SetPixel(j,i, c);
                }
            }
            pb2.Image = dest;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            source = dest;
            pb1.Image = source;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dest = new Bitmap(source.Width, source.Height);
            int[,] a = new int[source.Width,source.Height+1];
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    int t = (c.R + c.G + c.B) / 3;
                    a[i, j] = t;
                }
            }
            int[,] b = a;
            for (int i = 1; i < source.Width-1; i++)
            {
                for (int j = 1; j < source.Height-1; j++)
                {
                    if (a[i, j] - b[i - 1, j - 1] > 25 ||
                        a[i, j] - b[i + 1, j + 1] > 25 ||
                        a[i, j] - b[i + 1, j ] > 25 ||
                        a[i, j] - b[i - 1, j] > 25 ||
                        a[i, j] - b[i + 1, j-1] > 25 ||
                        a[i, j] - b[i , j-1] > 25 ||
                        a[i, j] - b[i , j+1] > 25 ||
                        a[i, j] - b[i - 1, j + 1] > 25)
                        a[i, j] = 255;
                }
            }
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    if (a[i, j] == 255) dest.SetPixel(i, j, Color.FromArgb(a[i, j], 0, 0));
                    else dest.SetPixel(i, j, Color.FromArgb(a[i, j], a[i, j], a[i, j]));
                    //if (a[i, j] == 255) dest.SetPixel(i, j, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                    //else dest.SetPixel(i, j, c);
                }
            }
            pb2.Image = dest;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dest = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    dest.SetPixel(i, j, Color.FromArgb(255-c.R, 255-c.G, 255-c.B));
                }
            }
            pb2.Image = dest;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dest = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    int t = (c.R + c.G + c.B) / 3;
                    if(t<90)
                    {
                        dest.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        dest.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            pb2.Image = dest;

        }
    }
}
