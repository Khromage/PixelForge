using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    /// <summary>
    /// Provides basic functionality needed for the use of tools within Pixel_Forgery 
    /// <list type="bullet">
    /// <item>Date: 3/13/23</item>
    /// <item>Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally, Lilianna Rosales</item>
    /// </list>
    /// Contains 3 methods:
    /// <list type="number">
    /// <item>UseTool() overritten by BrushTool, EraserTool, FillTool</item>
    /// <item>DrawOutline() overritten by ShapeTool</item>
    /// <item>Points() overritten by ShapeTool</item>
    /// </list>
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
        /// Property variable for setting and getting the 
        /// current pen color
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        public Color currentColor 
        {
            set { p.Color = value; }
            get { return p.Color; }
        }
        /// <summary>
        /// Property variable for setting the color that the color picker hovers over
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Gregory Khrom-Abramyan</item>
        /// </list>
        /// </summary>
        public Color pickedColor;

        /// <summary>
        /// Abstract method that is called upon using a tool.
        /// The specific tool with override the UseTool method.
        /// <list type="bullet">
        /// <item>Date: 3/13/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        public virtual void UseTool(MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
        }

        /// <summary>
        /// Abstract method that is called and overriden upon using the shapeTool.
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Taylor Nastally</item>
        /// </list>
        /// </summary>
        public virtual void DrawOutline(PaintEventArgs e) 
        {
        }

        /// <summary>
        /// Abstract method that is called and overriden upon using the shapeTool.
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Taylor Nastally</item>
        /// </list>
        /// </summary>
        public virtual void Points(List<Point> points)
        {
        }
    }
}