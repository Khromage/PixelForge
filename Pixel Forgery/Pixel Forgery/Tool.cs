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
        public Boolean isDrawing = false;
        public Pen p = new Pen(Color.Black, 5);

        public Color currentColor 
        {
            set { p.Color = value; }
            get { return p.Color; }
        }

        public virtual void useTool(object sender, MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
        }
    }
}