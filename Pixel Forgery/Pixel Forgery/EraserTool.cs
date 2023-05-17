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
    /// EraserTool class controls the construction and use of the eraser
    /// <list type="bullet">
    /// <item>Date: 3/13/23</item>
    /// <item>Programmer(s): Justin Reyes, Lilianna Rosales</item>
    /// </list>
    /// Contains 1 method:
    /// <list type="number">
    /// <item>UseTool() which erases pixels from pictureBox1 by changing their color to white.</item>
    /// </list>
    /// Contains 1 property variable:
    /// <list type="number">
    /// <item>EraserWidth which gets and sets the eraser pen width.</item>
    /// </list>
    /// </summary>
    public class EraserTool : PixelForgeryTool
    {
        /// <summary>
        /// Property variable for setting and getting the 
        /// eraser pen width
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        public float EraserWidth
        {
            set { pen.Width = value; }
            get { return pen.Width; }
        }

        /// <summary>
        /// Constructor for creating an <see cref="EraserTool"/> object.
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        public EraserTool() : base()
        {
            // Create the pen object only once. This makes it easier to 
            // edit the pen width and color
            pen = new Pen(Color.White, 20);
        }

        /// <summary>
        /// Erases pixels from pictureBox1 by changing their color to white.
        /// <list type="bullet">
        /// <item>Date: 3/13/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="e">is the mouse event parameter and contains data like location and mouse button click type</param>
        /// <param name="pictureBox1">Reference to the pictureBox.</param>
        public override void UseTool(MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.SmoothingMode = SmoothingMode.HighQuality;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Point point1 = new Point(startX, startY);
            Point point2 = new Point(e.X, e.Y);
            if (isDrawing == true)
            {
                g.DrawLine(pen, point1, point2);
                startX = e.X;
                startY = e.Y;
            }
            pictureBox1.Refresh();
        }
    }
}