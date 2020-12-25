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
        int k = 1;
        int hsv = 0;
        int hsv_i = 100;
        int count = 0;
        int[] Mcount = new int[9];

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

            trackBar3.Minimum = 0;
            trackBar3.Maximum = 225;
            trackBar3.TickFrequency = 1;
            trackBar3.Value = hsv_i;
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

            imageBox2.Image = new Filter().AddImg(k, sourceImage, sourceImage2).Resize(320, 240, Inter.Linear);
                    
        }

        private void button10_Click(object sender, EventArgs e)
        {
            sourceImage2 = new Filter().LoadImage();

            imageBox2.Image = new Filter().ExcImg(sourceImage, sourceImage2).Resize(320, 240, Inter.Linear);
                    

        }

        private void button11_Click(object sender, EventArgs e)
        {
            sourceImage2 = new Filter().LoadImage();

            imageBox2.Image = new Filter().CrossImg(sourceImage, sourceImage2).Resize(320, 240, Inter.Linear);
                    
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hsv = 0;

            imageBox2.Image = new Filter().HSV_f(hsv, sourceImage, hsv_i).Resize(320, 240, Inter.Linear);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            hsv = 1;

            imageBox2.Image = new Filter().HSV_f(hsv, sourceImage, hsv_i).Resize(320, 240, Inter.Linear);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            hsv = 2;

            imageBox2.Image = new Filter().HSV_f(hsv, sourceImage, hsv_i).Resize(320, 240, Inter.Linear);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            imageBox2.Image = new Filter().BlurImg(sourceImage).Resize(320, 240, Inter.Linear);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            
             if (count < 9)
            {
                Mcount[count] = int.Parse(textBox1.Text);
                count++;

                label2.Text = "";
                label2.Text = Convert.ToString(count);
                
            }
            else
            {
                count = 0;
                label2.Text = "";
                label2.Text = Convert.ToString(count);

                
                imageBox2.Image = new Filter().SharpImg(Mcount[0], Mcount[1], Mcount[2], Mcount[3], Mcount[4], Mcount[5], Mcount[6], Mcount[7], Mcount[8], sourceImage).Resize(320, 240, Inter.Linear);
                    
            }
                
        }

        private void button17_Click(object sender, EventArgs e)
        {
            sourceImage2 = new Filter().LoadImage();

            imageBox2.Image = new Filter().Wclr(b, c, k, sourceImage, sourceImage2);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            imageBox2.Image = new Filter().Ctn(sourceImage).Resize(320, 240, Inter.Linear);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            c = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            b = trackBar2.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            hsv_i = trackBar3.Value;
        }

       
    }
}
