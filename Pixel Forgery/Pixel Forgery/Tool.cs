using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    public abstract class PixelForgeryTool
    {
        public int startX;
        public int startY;
        public Boolean isDrawing = false;
        public virtual void useTool(object sender, MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
        }
    }
}