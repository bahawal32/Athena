using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace oopProject
{
    class Athena
    {
    
        public Athena()
        {
           
        }
        public Bitmap Mint(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            Color p;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = bmp.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R / 2;
                    int g = p.G / 2;
                    int b = p.B;
                    int avg = (r + g + b) / 3;
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, avg));

                }
            }
            return bmp;
        }
        public Bitmap Sepia(Bitmap bmp)
        {
           
            int width = bmp.Width;
            int height = bmp.Height;
            Color p;
            int a, r, g, b, x;
            double tr, tg, tb;
            for (int y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    p = bmp.GetPixel(x, y);
                    a = p.A;
                    r = p.R;
                    g = p.G;
                    b = p.B;
                    tr = 0.393 * r + 0.769 * g + 0.189 * b;
                    tg = 0.349 * r + 0.686 * g + 0.168 * b;
                    tb = 0.272 * r + 0.534 * g + 0.131 * b;
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = Convert.ToInt32(tr);
                    }
                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = Convert.ToInt32(tg);
                    }
                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = Convert.ToInt32(tb);
                    }
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }

            }
            return bmp;
        }
        public Bitmap GreyScale(Bitmap bmp)
        {
     
            int width = bmp.Width;
            int height = bmp.Height;
            Color p;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = bmp.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    int avg = (r + g + b) / 3;
                    bmp.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));

                }
            }
                return bmp;
        }
        public Bitmap Twilight(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            Color p;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = bmp.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    bmp.SetPixel(x, y, Color.FromArgb(a, 210 * b / 255, 150 * g / 255, 62 * b / 255));
                }
            }
            return bmp;
        }
        public Bitmap Negative(Bitmap bmp)
        {
           
            int width = bmp.Width;
            int height = bmp.Height;
            Color p;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = bmp.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    int avg = (r + g + b) / 3;
                    bmp.SetPixel(x, y, Color.FromArgb(a, 255 - avg, 255 - avg, 255 - avg));

                }
            }
            return bmp;
        }
        public Bitmap Merge(Bitmap bmp)
        {
         
            double tr, tg, tb;
            int width = bmp.Width;
            int height = bmp.Height;
            Color p;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    p = bmp.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    int avg = (r + g + b) / 3;
                    if (y < height / 2)
                    {
                        if (x < width / 2)
                            bmp.SetPixel(x, y, Color.FromArgb(a, 210 * b / 255, 150 * g / 255, 62 * b / 255));
                        else
                            bmp.SetPixel(x, y, Color.FromArgb(a, r * 50 / 255, g * 150 / 255, b * 250 / 255));
                    }
                    else
                    {
                        if (x < width / 2)
                        {
                            tr = 0.393 * r + 0.769 * g + 0.189 * b;
                            tg = 0.349 * r + 0.686 * g + 0.168 * b;
                            tb = 0.272 * r + 0.534 * g + 0.131 * b;
                            if (tr > 255)
                            {
                                r = 255;
                            }
                            else
                            {
                                r = Convert.ToInt32(tr);
                            }
                            if (tg > 255)
                            {
                                g = 255;
                            }
                            else
                            {
                                g = Convert.ToInt32(tg);
                            }
                            if (tb > 255)
                            {
                                b = 255;
                            }
                            else
                            {
                                b = Convert.ToInt32(tb);
                            }
                            bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                        }
                        else
                            bmp.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                    }
                }
            }
            return bmp;
        }
    }
}

