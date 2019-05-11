using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace oopProject
{
    
    public partial class Form1 : Form
    {
       
        Athena Ava;//Main Object with handles all task
        bool open = false;//A flag to check if any image is opened or not
        Image openimg;//saving a orignal image
        Bitmap bmp, bmp_origna;//making copies in bitmap
        public Form1()
        {
            InitializeComponent();
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//ORIGNAL
        {

            if (open == true)
            {
                NewMethod();
               
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (open == true)
            {
                NewMethod();//reload orignal image 
                bmp = Ava.Mint(bmp);
                pictureBox1.Image = bmp;
            }

        }
        private void button3_Click(object sender, EventArgs e)//SEPIA
        {
            if (open == true)
            {
                NewMethod();
                bmp = Ava.Sepia(bmp);
              
            }
                pictureBox1.Image = bmp;
        }
        
        private void button5_Click(object sender, EventArgs e)//GREYSCALE
        {
            if (open == true)
            {
                 NewMethod();
                 bmp = new Bitmap(pictureBox1.Image);

                bmp = Ava.GreyScale(bmp);

                pictureBox1.Image = bmp;
            }
        }
        private void button4_Click(object sender, EventArgs e)//NEGATIVE
        {
            if (open == true)
            {
                NewMethod();
                Ava.GreyScale(bmp); ;
                pictureBox1.Image = bmp;

            }
        }
        private void button6_Click(object sender, EventArgs e)//TWILIGHT
        {
            if (open == true)
            {
                 NewMethod();
                Ava.Twilight(bmp);
                pictureBox1.Image = bmp;
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            NewMethod();
            int v1, v2, v3,a,r,g,b;
           
            bmp = new Bitmap(pictureBox1.Image);
            int width = bmp.Width;
            int height = bmp.Height;
            Color p;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = bmp.GetPixel(x, y);
                     a = p.A;
                     r = p.R;
                     g = p.G;
                     b = p.B;
                    if (checkBox1.Checked)
                    {
                        v1 = Convert.ToInt32(textBox1.Text);
                        v2 = Convert.ToInt32(textBox2.Text);
                        v3 = Convert.ToInt32(textBox3.Text);
                        if (v1+r > 255)
                        {
                            r = 255;
                        }
                        else { r = r + v1; }
                        
                        if (v2+g > 255)
                        {
                            g = 255;
                        }
                        else { g = g + v2; }
                        if (v3+b > 255)
                        {
                            b = 255;
                        }
                        else { b = b + v3; }
                        bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    }
                    else
                    {
                        v1 = trackBar1.Value;
                        v2 = trackBar2.Value;
                        v3 = trackBar3.Value;
                        if (v1 + r > 255)
                        {
                            r = 255;
                        }
                        else { r = r + v1; }

                        if (v2 + g > 255)
                        {
                            g = 255;
                        }
                        else { g = g + v2; }
                        if (v3 + b > 255)
                        {
                            b = 255;
                        }
                        else { b = b + v3; }
                        bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    }
                      
                }

            }
            
            label1.Text = Convert.ToString(trackBar1.Value);
            label2.Text = Convert.ToString(trackBar2.Value);
            label3.Text = Convert.ToString(trackBar3.Value);
            pictureBox1.Image = bmp;
        }

        private void NewMethod()
        {
            pictureBox1.Image = openimg;
            bmp = new Bitmap(pictureBox1.Image);
            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {


            DialogResult dir = openFileDialog1.ShowDialog();
            if (dir == DialogResult.OK)
            {
                openimg = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = openimg;
                open = true;
            }
             bmp = new Bitmap(pictureBox1.Image);
             bmp_origna = new Bitmap(pictureBox1.Image);
            int width = bmp.Width;
            int height = bmp.Height;
            label4.Text = Convert.ToString(height);
            label5.Text = Convert.ToString(width);
            label6.Text = "=" + Convert.ToString(width*height);
            Athena Execute = new Athena();
            Ava = Execute;//copying Execute to a globle object Ava

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)//MERGE
        {
            if (open == true)
            {
                NewMethod();
                bmp = Ava.Merge(bmp);
                pictureBox1.Image = bmp;
            }
        }
        private void Button11_Click(object sender, EventArgs e)
        { 
            
            if (open == true)
            {
                NewMethod();
                bmp = new Bitmap(pictureBox1.Image);
                int bright = Convert.ToInt32(label7.Text); ;
                int br, bg, bb;
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
                        br = r + bright;
                        bg = g + bright;
                        bb = b + bright;
                        if (br >= 0 && br <= 255)
                        {
                            r = br;
                        }
                        else
                        {
                            if (br < 0)
                            {
                                r = 1;
                            }
                            if (br > 255)
                            {
                                r = 254;
                            }
                        }
                        if (bb >= 0 && bb <= 255)
                        {
                            b = bb;
                        }
                        else
                        {
                            if (bb < 0)
                            {
                                b = 1;
                            }
                            if (bb > 255)
                            {
                                b = 254;
                            }
                        }
                        if (bg >= 0 && bg <= 255)
                        {
                            g = bg;
                        }
                        else
                        {
                            if (bg < 0)
                            {
                                g = 1;
                            }
                            if (bg > 255)
                            {
                                g = 254;
                            }
                        }
                        bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                    }
                }
                pictureBox1.Image = bmp;
            }
        }

     

        private void button13_Click(object sender, EventArgs e)
        {
            if (open == true)
            {
                 bmp = new Bitmap(pictureBox1.Image);
                int width = bmp.Width;
                int height = bmp.Height;
                Color t;
                Color p;
                for (int y = 0; y < height/2; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        p = bmp.GetPixel(x, y);
                        int a = p.A;
                        int r = p.R;
                        int g = p.G;
                        int b = p.B;
                        t = bmp.GetPixel(width-x-1, height-y-1);
                        int a2 = t.A;
                        int r2= t.R;
                        int g2 = t.G;
                        int b2 = t.B;
                        bmp.SetPixel(x, y, Color.FromArgb(a2, r2, g2, b2));
                        bmp.SetPixel(width-x-1, height-y-1, Color.FromArgb(a, r, g, b));
                    }
                }
                pictureBox1.Image = bmp;
 
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Image Png files (*.*)|*.*";//Png set as primary format
           ImageFormat format = ImageFormat.Png;
            
            
            if(save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image.Save(save.FileName+".Png", ImageFormat.Png);
            }
        }

   
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
             bmp = Ava.GreyScale(bmp);
            if (open == true)
            {//
                bmp = new Bitmap(pictureBox1.Image);
                int width = bmp.Width;
                int height = bmp.Height;
                Color p;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        double[] Total = new double[3];// matrix to save RGB value
                        int FilterSize = Convert.ToInt32(label12.Text);
                        for(int i1 =y;i1<y+ FilterSize && i1<height;i1++ )
                        {
                            for(int j1=x;j1<x+ FilterSize && j1<width;j1++)
                            {
                                if (i1 < Height && j1 < Width && i1 > 0 && j1 > 0 )
                                {
                                    p = bmp.GetPixel(j1, i1);
                                    Total[0] += p.R;
                                    Total[1] += p.G;
                                    Total[2] += p.B;
                                }
                            }
                        }
                        int sum = FilterSize * FilterSize;
                        Total[0] = Total[0] / sum;
                        Total[1] = Total[1] / sum;
                        Total[2] = Total[2] / sum;
                        int r = Convert.ToInt32(Total[0]);
                        int g = Convert.ToInt32(Total[1]);
                        int b = Convert.ToInt32(Total[2]);

                        bmp.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                    }
                }
                Color p2;
                Bitmap bmp2 = new Bitmap(openimg);
                for (int y = 0; y < height -1; y++)
                {
                    for (int x = 0; x < width-1; x++)
                    {
                        p = bmp.GetPixel(x, y);
                        p2 = bmp2.GetPixel(x,y);
                        int a = p.A;
                        int r = p.R;
                        int g = p.G;
                        int b = p.B;
                        int a2 = p2.A;
                        int r2 = p2.R;
                        int g2 = p2.G;
                        int b2 = p2.B;
                      
                        if (r > r2)
                        {
                            r = r - r2;
                        }
                       
                        if (g > g2)
                        {
                            g = g - g2;
                        }
                      
                        if (b > b2)
                        {
                            b = b - b2;
                        }
                       
                        bmp.SetPixel(x,y, Color.FromArgb(a, r, g, b));
                    }
                }
               
             
                pictureBox1.Image = bmp;
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)//MIRROR
        {
            if (open == true)
            {
                 bmp = new Bitmap(pictureBox1.Image);
                int width = bmp.Width;
                int height = bmp.Height;
                Color t;
                Color p;
                for (int y = 1; y < height ; y++)
                {
                    for (int x = 1; x < width; x++)
                    {
                        
                        p = bmp.GetPixel(x, y);
                        int a = p.A;
                        int r = p.R;
                        int g = p.G;
                        int b = p.B;
                        /*t = bmp.GetPixel(width - x, y);
                        int a2 = t.A;
                        int r2 = t.R;
                        int g2 = t.G;
                        int b2 = t.B;
                        bmp.SetPixel(x, y, Color.FromArgb(a2, r2, g2, b2));
                    */    bmp.SetPixel(width - x, y, Color.FromArgb(a, r%(r+g+b), g% (r + g + b), b% (r + g + b)));
                  
                    }
                }
                pictureBox1.Image = bmp;

            }
        }

     
        //code connot be remove as it messes with the design
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {

        }

        private void increment(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(label7.Text);
            if(i<100)
            { 
             i= Convert.ToInt32(label7.Text);
            i+=10;
            label7.Text = i.ToString();
            }
        }
        private void decrement(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(label7.Text);
            if (i > -100)
            {
                i = Convert.ToInt32(label7.Text);
                i -= 10;
                label7.Text = i.ToString();
            }
        }

        private void increment1(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(label12.Text);
            if (i<10)
            {
                i = Convert.ToInt32(label12.Text);
                i += 1;
                label12.Text = i.ToString();
            }
        }

        private void decrement1(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(label12.Text);
            if (i > 1)
            {
                i = Convert.ToInt32(label12.Text);
                i -= 1;
                label12.Text = i.ToString();
            }
        }

        
    }
    }


