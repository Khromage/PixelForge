using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Pixel_Forgery
{
    public class ShapeTool : PixelForgeryTool
    {
        Rectangle r;
        Point locationX1Y1;
        Point locationXY;
        Color shapeColor;

        public override void useTool(object sender, MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            p.Color = currentColor;
            if (isDrawing == true)
            {
                 g.DrawRectangle(Pens.Black, GetRectangle());
            }
            pictureBox1.Refresh();
        }

        private Rectangle GetRectangle()
        {
            locationXY.X = startX;
            locationXY.Y = startY;
            locationX1Y1.X = endX;
            locationX1Y1.Y = endY;
            if(r == null)
                r = new Rectangle();
            r.X = Math.Min(locationXY.X, locationX1Y1.X);
            r.Y = Math.Min(locationXY.Y, locationX1Y1.Y);
            r.Width = Math.Abs(locationXY.X - locationX1Y1.X);
            r.Height = Math.Abs(locationXY.Y - locationX1Y1.Y);
            return r;
        }
    }
}

/*
 this is the working code, when written in the mouse event methods, It will draw but not as smoothly as just using the paint event method
 namespace DeleteThis
{
    public partial class Form1 : Form
    {

        Rectangle r;
        Point LocationXY;
        Point LocationX1Y1;
        bool IsMouseDown = false;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            LocationXY = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(IsMouseDown == true)
            {
                LocationX1Y1 = e.Location;
                g.DrawRectangle(Pens.Black, GetRect());
                Refresh();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            LocationX1Y1 = e.Location;
            Refresh();
            IsMouseDown = false;
            g.DrawRectangle(Pens.Black, GetRect());
        }

        private Rectangle GetRect()
        {
            r = new Rectangle();
            r.X = Math.Min(LocationXY.X, LocationX1Y1.X);
            r.Y = Math.Min(LocationXY.Y, LocationX1Y1.Y);
            r.Width = Math.Abs(LocationXY.X - LocationX1Y1.X);
            r.Height = Math.Abs(LocationXY.Y - LocationX1Y1.Y);
            return r;
        }
    }
}
 */
