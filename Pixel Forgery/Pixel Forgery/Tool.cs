using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    /// <summary>
    /// Date: 3/13/23
    /// Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally, Lilianna Rosales
    /// Provides basic functionality needed for the use of tools withing Pixel_Forgery 
    /// Contains 3 method:
    /// UseTool() overritten by BrushTool, EraserTool, FillTool
    /// drawOutline() overritten by ShapeTool
    /// points() overritten by ShapeTool
    /// </summary>
    public abstract class PixelForgeryTool
    {
        public int startX;
        public int startY;
        public int endX;
        public int endY;
        public int typeOfTool;
        public Boolean isDrawing = false;
        public Pen p = new Pen(Color.Black, 5);

        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Lilianna Rosales
        /// Property variable for setting and getting the 
        /// current pen color
        /// </summary>
        public Color currentColor 
        {
            set { p.Color = value; }
            get { return p.Color; }
        }
        public Color pickedColor;

        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally, Lilianna Rosales
        /// Abstract method that is called upon using a tool.
        /// The specific tool with override the UseTool method.
        /// </summary>
        public virtual void UseTool(MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
        }

        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Taylor Nastally
        /// Abstract method that is called and overriden upon using the shapeTool.
        /// </summary>
        public virtual void drawOutline(PaintEventArgs e) 
        {
        }

        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Taylor Nastally
        /// Abstract method that is called and overriden upon using the shapeTool.
        /// </summary>
        public virtual void points(List<Point> points)
        {
        }
    }
}