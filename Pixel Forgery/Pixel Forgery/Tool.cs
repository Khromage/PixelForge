using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    public abstract class PixelForgeryTool
    {
        public int startX;
        public int startY;
        public int endX;
        public int endY;
        public int typeOfTool;
        public Boolean isDrawing = false;
        public Pen p = new Pen(Color.Black, 5);

        public Color currentColor 
        {
            set { p.Color = value; }
            get { return p.Color; }
        }
        public Color pickedColor;

        public virtual void useTool(MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
        }

        public virtual void drawOutline(PaintEventArgs e) 
        {
        }

        //for polygon draw
        public virtual void points(List<Point> points)
        {
        }
    }
}