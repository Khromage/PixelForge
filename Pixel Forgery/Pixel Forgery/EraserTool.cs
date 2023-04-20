using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    /// <summary>
    /// Date: 3/13/23
    /// Programmer(s): Justin Reyes, Lilianna Rosales
    /// EraserTool class controls the construction and use of the eraser
    /// Contains 1 method:
    /// UseTool() which erases pixels from pictureBox1 by changing their color to white.
    /// Contains 1 property variable:
    /// EraserWidth which gets and sets the eraser pen width
    /// </summary>
    public class EraserTool : PixelForgeryTool
    {
        // Create the pen object only once. This makes it easier to 
        // edit the pen width and color
        private Pen p = new Pen(Color.White, 20);


        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Lilianna Rosales
        /// Property variable for setting and getting the 
        /// eraser pen width
        /// </summary>
        public float EraserWidth
        {
            set { p.Width = value; }
            get { return p.Width; }
        }

        /// <summary>
        /// Date: 3/13/23
        /// Programmer(s): Justin Reyes
        /// Erases pixels from pictureBox1 by changing their color to white.
        /// </summary>
        /// <param name="e">is the mouse event parameter and contains data like location and mouse button click type</param>
        /// <param name="pictureBox1">Reference to the pictureBox.</param>
        public override void UseTool(MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
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