using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    public class EraserTool : PixelForgeryTool
    {
        // Create the pen object only once. This makes it easier to 
        // edit the pen width and color
        private Pen p = new Pen(Color.White, 20);

        /// <summary>
        /// Property variable for setting & getting the 
        /// eraser pen width
        /// </summary>
        public float EraserWidth
        {
            set { p.Width = value; }
            get { return p.Width; }
        }

        public override void useTool(object sender, MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.SmoothingMode = SmoothingMode.HighQuality;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Point point1 = new Point(startX, startY);
            Point point2 = new Point(e.X, e.Y);
            if (isDrawing == true)
            {
                g.DrawLine(p, point1, point2);
                startX = e.X;
                startY = e.Y;
            }
            pictureBox1.Refresh();
        }
    }
}