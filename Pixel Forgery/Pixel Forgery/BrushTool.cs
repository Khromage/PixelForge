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
    /// <summary>
    /// Date: 3/13/23
    /// Programmer(s): Justin Reyes, Lilianna Rosales
    /// BrushTool class controls the construction and use of the brush
    /// Contains 1 method:
    /// useTool() which creates brush strokes by by changing color the pixels from pictureBox1 
    /// Contains 1 property variable:
    /// BrushWidth which gets and sets the brush pen width
    /// </summary>
    public class BrushTool : PixelForgeryTool
    {
        // Create the pen object only once. This makes it easier to 
        // edit the pen width and color
        private Pen p = new Pen(Color.Black, 5);

        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Lilianna Rosales
        /// Property variable for setting and getting the 
        /// brush pen width
        /// </summary>
        public float BrushWidth
        {
            set { p.Width = value; }
            get { return p.Width; }
        }

        /// <summary>
        /// Date: 3/13/23
        /// Programmer(s): Justin Reyes
        /// Creates brush strokes by by changing color the pixels from pictureBox1
        /// </summary>
        /// <param name="e">is the mouse event parameter and contains data like location and mouse button click type</param>
        /// <param name="pictureBox1">Reference to the pictureBox.</param>
        public override void useTool(MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.SmoothingMode = SmoothingMode.HighQuality;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Point point1 = new Point(startX, startY);
            Point point2 = new Point(e.X, e.Y);
            p.Color = currentColor;
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