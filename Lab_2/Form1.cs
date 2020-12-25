using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace Lab_2
{
   

    public partial class Form1 : Form
    {
        Image<Bgr, byte> sourceImage;
        Image<Bgr, byte> sourceImage2;

        int i;
        int c = 2;
        int b = 2;
        double k1 = 0.5;
        double k2 = 0.5;


        public Form1()
        {
            InitializeComponent();

            trackBar1.Minimum = 0;
            trackBar1.Maximum = 5;
            trackBar1.TickFrequency = 1;
            trackBar1.Value = c;
            trackBar2.Minimum = 0;
            trackBar2.Maximum = 100;
            trackBar2.TickFrequency = 1;
            trackBar2.Value = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sourceImage = new Filter().LoadImage();

            imageBox1.Image = sourceImage.Resize(320, 240, Inter.Linear);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i = 2;
            imageBox2.Image = new Filter().Chanel(i, sourceImage).Resize(320, 240, Inter.Linear);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i = 1;
            imageBox2.Image = new Filter().Chanel(i, sourceImage).Resize(320, 240, Inter.Linear);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            i = 0;
            imageBox2.Image = new Filter().Chanel(i, sourceImage).Resize(320, 240, Inter.Linear);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            imageBox2.Image = new Filter().BandW(sourceImage).Resize(320, 240, Inter.Linear);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            imageBox2.Image = new Filter().Sepia(sourceImage).Resize(320, 240, Inter.Linear);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            imageBox2.Image = new Filter().Contrast(c, sourceImage).Resize(320, 240, Inter.Linear);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            imageBox2.Image = new Filter().Brightness(b, sourceImage).Resize(320, 240, Inter.Linear);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sourceImage2 = new Filter().LoadImage();

            if (double.TryParse(textBox1.Text, out k1) && double.TryParse(textBox2.Text, out k2))
            {
                if ((k1 >= 0 && k1 <= 1) && (k2 >= 0 && k2 <= 1))
                {
                    imageBox2.Image = new Filter().AddImg(k1, k2, sourceImage, sourceImage2).Resize(320, 240, Inter.Linear);
                    return;
                }
            }
            MessageBox.Show("Введите коэффициент от 0 до 1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            sourceImage2 = new Filter().LoadImage();

            if (double.TryParse(textBox1.Text, out k1) && double.TryParse(textBox2.Text, out k2))
            {
                if ((k1 >= 0 && k1 <= 1) && (k2 >= 0 && k2 <= 1))
                {
                    imageBox2.Image = new Filter().ExcImg(k1, k2, sourceImage, sourceImage2).Resize(320, 240, Inter.Linear);
                    return;
                }
            }
            MessageBox.Show("Введите коэффициент от 0 до 1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            sourceImage2 = new Filter().LoadImage();

            if (double.TryParse(textBox1.Text, out k1) && double.TryParse(textBox2.Text, out k2))
            {
                if ((k1 >= 0 && k1 <= 1) && (k2 >= 0 && k2 <= 1))
                {
                    imageBox2.Image = new Filter().CrossImg(k1, k2, sourceImage, sourceImage2).Resize(320, 240, Inter.Linear);
                    return;
                }
            }
            MessageBox.Show("Введите коэффициент от 0 до 1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            c = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            b = trackBar2.Value;
        }

        
    }
}
