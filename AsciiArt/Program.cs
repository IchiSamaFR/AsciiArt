using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt
{
    class Program
    {
        public const string Shade = "@@BBRR##$$PPXX00wwooiiccvv::++!!~~\"\"...,,,";
        public const int MaxValue = 765;
        static void Main(string[] args)
        {
            WriteAscii(GetImage(@"C:\Users\IchiSamaFR\Pictures\Ressources\logo.png", 200));
            Console.ReadLine();
        }

        static Bitmap GetImage(string url, int size)
        {
            int width = size;
            int height = size;
            Bitmap original = (Bitmap)Image.FromFile(url);
            double ratioX = (double)width / (double)original.Width;
            double ratioY = (double)height / (double)original.Height;

            double ratio = ratioX < ratioY ? ratioX : ratioY;

            height = Convert.ToInt32(original.Height * ratio * 0.5f);
            width = Convert.ToInt32(original.Width * ratio);

            return new Bitmap(original, new Size(width, height));
        }

        static void WriteAscii(Bitmap img)
        {
            for (int y = 0; y < img.Height; y++)
            {
                string toShow = "";
                for (int x = 0; x < img.Width; x++)
                {
                    Color c = img.GetPixel(x, y);
                    float value = 1 - (float)(c.R + c.G + c.B) / (float)MaxValue;
                    toShow += Shade[(int)(value * (Shade.Length - 1))].ToString();
                }
                Console.WriteLine(toShow);
            }
        }
    }
}
