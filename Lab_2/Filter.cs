using System;
using System.Collections.Generic;
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
    public class Filter
    {
        public Image<Bgr, byte> sourceImage;

        public Image<Bgr, byte> LoadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog(); // открытие диалога выбора файла
            if (result == DialogResult.OK) // открытие выбранного файла
            {
                string fileName = openFileDialog.FileName;
                return new Image<Bgr, byte>(fileName);
            }
            return null;
        }
        public Image<Bgr, byte> Chanel(int i, Image<Bgr, byte> sourceImage)
        {
            var channel = sourceImage.Split()[i];
            Image<Bgr, byte> destImage = sourceImage.CopyBlank();

            VectorOfMat vm = new VectorOfMat();
            if (i == 0)
            {
                vm.Push(channel);
                vm.Push(channel.CopyBlank());
                vm.Push(channel.CopyBlank());
            }
            if (i == 1)
            {
                vm.Push(channel.CopyBlank());
                vm.Push(channel);
                vm.Push(channel.CopyBlank());
            }
            if (i == 2)
            {
                vm.Push(channel.CopyBlank());
                vm.Push(channel.CopyBlank());
                vm.Push(channel);
            }
            CvInvoke.Merge(vm, destImage);

            return destImage;
        }

        public Image<Gray, byte> BandW(Image<Bgr, byte> sourceImage)
        {
            var grayImage = new Image<Gray, byte>(sourceImage.Size);

            for (int y = 0; y < grayImage.Height; y++)
                for (int x = 0; x < grayImage.Width; x++)
                {
                    if ((0.299 * sourceImage.Data[y, x, 2] + 0.587 * sourceImage.Data[y, x, 1] + 0.114 * sourceImage.Data[y, x, 0]) > 255)
                        grayImage.Data[y, x, 0] = 255;
                    else
                        grayImage.Data[y, x, 0] = Convert.ToByte(0.299 * sourceImage.Data[y, x, 2] + 0.587 * sourceImage.Data[y, x, 1] + 0.114 * sourceImage.Data[y, x, 0]);
                }
            return grayImage;
        }

        public Image<Bgr, byte> Sepia(Image<Bgr, byte> sourceImage)
        {
            var SepImage = sourceImage.Copy();

            for (int y = 0; y < SepImage.Height; y++)
                for (int x = 0; x < SepImage.Width; x++)
                {
                    if ((0.393 * sourceImage.Data[y, x, 2] + 0.769 * sourceImage.Data[y, x, 1] + 0.189 * sourceImage.Data[y, x, 0]) > 255)
                        SepImage.Data[y, x, 2] = 255;
                    else
                        SepImage.Data[y, x, 2] = Convert.ToByte(0.393 * sourceImage.Data[y, x, 2] + 0.769 * sourceImage.Data[y, x, 1] + 0.189 * sourceImage.Data[y, x, 0]);

                    if ((0.349 * sourceImage.Data[y, x, 2] + 0.686 * sourceImage.Data[y, x, 1] + 0.168 * sourceImage.Data[y, x, 0]) > 255)
                        SepImage.Data[y, x, 1] = 255;
                    else
                        SepImage.Data[y, x, 1] = Convert.ToByte(0.349 * sourceImage.Data[y, x, 2] + 0.686 * sourceImage.Data[y, x, 1] + 0.168 * sourceImage.Data[y, x, 0]);

                    if ((0.272 * sourceImage.Data[y, x, 2] + 0.534 * sourceImage.Data[y, x, 1] + 0.131 * sourceImage.Data[y, x, 0]) > 255)
                        SepImage.Data[y, x, 0] = 255;
                    else
                        SepImage.Data[y, x, 0] = Convert.ToByte(0.272 * sourceImage.Data[y, x, 2] + 0.534 * sourceImage.Data[y, x, 1] + 0.131 * sourceImage.Data[y, x, 0]);
                }
            return SepImage;
        }

        public Image<Bgr, byte> Contrast(double c, Image<Bgr, byte> sourceImage)
        {
            var ContrastImage = sourceImage.Copy();

            for (int ch = 0; ch < 3; ch++)
                for (int y = 0; y < ContrastImage.Height; y++)
                    for (int x = 0; x < ContrastImage.Width; x++)
                    {
                        if ((ContrastImage.Data[y, x, ch] * c) > 255)
                            ContrastImage.Data[y, x, ch] = 255;
                        else
                            ContrastImage.Data[y, x, ch] = Convert.ToByte(ContrastImage.Data[y, x, ch] * c);
                    }
            return ContrastImage;
        }

        public Image<Bgr, byte> Brightness(int b, Image<Bgr, byte> sourceImage)
        {
            var BrightImage = sourceImage.Copy();

            for (int ch = 0; ch < 3; ch++)
                for (int y = 0; y < BrightImage.Height; y++)
                    for (int x = 0; x < BrightImage.Width; x++)
                    {
                        if ((BrightImage.Data[y, x, ch] + b) > 255)
                            BrightImage.Data[y, x, ch] = 255;
                        else if ((BrightImage.Data[y, x, ch] + b) < 0)
                            BrightImage.Data[y, x, ch] = 0;
                        else
                            BrightImage.Data[y, x, ch] = Convert.ToByte(BrightImage.Data[y, x, ch] + b);
                    }
            return BrightImage;
        }

        public Image<Bgr, byte> AddImg(double k1, double k2, Image<Bgr, byte> sourceImage, Image<Bgr, byte> sourceImage2)
        {
            var Imag1 = sourceImage.Copy().Resize(320, 240, Inter.Linear);
            var Imag2 = sourceImage2.Copy().Resize(320, 240, Inter.Linear);

            for (int ch = 0; ch < 3; ch++)
                for (int y = 0; y < Imag1.Height; y++)
                    for (int x = 0; x < Imag1.Width; x++)
                    {
                        if ((Imag1.Data[y, x, ch] * k1 + Imag2.Data[y, x, ch] * k2) > 255)
                            Imag1.Data[y, x, ch] = 255;
                        else if ((Imag1.Data[y, x, ch] * k1 + Imag2.Data[y, x, ch] * k2) < 0)
                            Imag1.Data[y, x, ch] = 0;
                        else
                            Imag1.Data[y, x, ch] = Convert.ToByte(Imag1.Data[y, x, ch] * k1 + Imag2.Data[y, x, ch] * k2);
                    }
            return Imag1;
        }

        public Image<Bgr, byte> ExcImg(double k1, double k2, Image<Bgr, byte> sourceImage, Image<Bgr, byte> sourceImage2)
        {
            var Imag1 = sourceImage.Copy().Resize(320, 240, Inter.Linear);
            var Imag2 = sourceImage2.Copy().Resize(320, 240, Inter.Linear);

            for (int ch = 0; ch < 3; ch++)
                for (int y = 0; y < Imag1.Height; y++)
                    for (int x = 0; x < Imag1.Width; x++)
                    {
                        if ((Imag1.Data[y, x, ch] > 250) && (Imag2.Data[y, x, ch] > 250))
                            Imag1.Data[y, x, ch] = 255;
                        else
                            Imag1.Data[y, x, ch] = 0;
                    }
            return Imag1;
        }

        public Image<Bgr, byte> CrossImg(double k1, double k2, Image<Bgr, byte> sourceImage, Image<Bgr, byte> sourceImage2)
        {
            var Imag1 = sourceImage.Copy().Resize(320, 240, Inter.Linear);
            var Imag2 = sourceImage2.Copy().Resize(320, 240, Inter.Linear);

            for (int ch = 0; ch < 3; ch++)
                for (int y = 0; y < Imag1.Height; y++)
                    for (int x = 0; x < Imag1.Width; x++)
                    {
                        if (Imag2.Data[y, x, ch] > 250)
                            Imag1.Data[y, x, ch] = 0;
                    }
            return Imag1;
        }



    }
}
