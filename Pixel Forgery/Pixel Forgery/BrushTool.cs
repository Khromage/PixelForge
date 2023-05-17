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
    /// BrushTool class controls the construction and use of the brush
    /// <list type="bullet">
    /// <item>Date: 3/13/23</item>
    /// <item>Programmer(s): Justin Reyes, Lilianna Rosales</item>
    /// </list>
    /// Contains 1 method:
    /// <list type="number">
    /// <item>UseTool() which creates brush strokes by by changing color the pixels from pictureBox1</item>
    /// </list>
    /// Contains 1 property variable:
    /// <list type="number">
    /// <item>BrushWidth which gets and sets the brush pen width</item>
    /// </list>
    /// </summary>
    public class BrushTool : PixelForgeryTool
    {
        // Update (4/24): pen variable not needed as it's defined in the base class
        // Create the pen object only once. This makes it easier to 
        // edit the pen width and color
        //private Pen pen = new Pen(Color.Black, 5);

        /// <summary>
        /// Property variable for setting and getting the 
        /// brush pen width
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        public float BrushWidth
        {
            set { pen.Width = value; }
            get { return pen.Width; }
        }

        /// <summary>
        /// Creates brush strokes by by changing color the pixels from pictureBox1
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
            pen.Color = currentColor;
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