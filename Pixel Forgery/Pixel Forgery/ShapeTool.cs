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
    /// Shape tool class controls the type and method of construction for the user's desired drawing type.
    /// <list type="bullet">
    /// <item>Date: 04/05/2023 (initial commit)</item>
    /// <item>Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally, Lilianna Rosales</item>
    /// </list>
    /// Contains 3 methods:
    /// <list type="number">
    /// <item>useTool() is an overriden method that allows the tool to be drawn to the canvas</item>
    /// <item>DrawOutline() is an overriden method that allows the tool to have drag-and-drop functionality</item>
    /// <item>drawRectangle() is a private method that allows takes the mouse loction and creates a rectangle with it</item>
    /// </list>
    /// </summary>
    public class ShapeTool : PixelForgeryTool
    {
        Rectangle r;
        List<Point> pointsInTool; //= new List<Point>();
        int iterator = 0;
        Point locationX1Y1;
        Point locationXY;

        /// <summary>
        /// Contains a switch that checks the typeOfTool and calls the appropriate draw function.
        /// Draws to the pictureBox with Graphics g.
        /// <list type="bullet">
        /// <item>Date: 04/05/2023</item>
        /// <item>Programmer: Taylor Nastally</item>
        /// </list>
        /// </summary>
        /// <param name="e">is the mouse event parameter and contains data like location and mouse button click type</param>
        /// <param name="pictureBox1">is the actual picturebox from Form1 sent to the tool so new graphics will be saved</param>
        public override void UseTool(MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            p.Color = currentColor;
            switch (typeOfTool)
            {
                case 1:
                    g.DrawRectangle(p, GetRectangle());
                    break;
                case 2:
                    g.DrawEllipse(p, GetRectangle());
                    break;
                case 3:
                    if (pointsInTool != null && pointsInTool.Count > 1 && e.Button == MouseButtons.Right)
                        g.DrawLine(p, pointsInTool[pointsInTool.Count - 2], pointsInTool[pointsInTool.Count - 1]);
                    else if (pointsInTool != null && pointsInTool.Count > 2 && e.Button == MouseButtons.Left)
                        g.DrawLine(p, pointsInTool[pointsInTool.Count - 1], pointsInTool[0]);
                    break;
                default:
                    g.DrawRectangle(p, GetRectangle());
                    break;
            }
            pictureBox1.Refresh();
            g.Dispose();
        }

        /// <summary>
        /// Contains a switch to check and draw the appropriate shape based on type of tool.
        /// Draws with the passed Graphics g from onPaint in Form1.
        /// <list type="bullet">
        /// <item>Date: 04/11/2023</item>
        /// <item>Programmer(s): Justin Reyes, Taylor Nastally</item>
        /// </list>
        /// </summary>
        /// <param name="e">is the paint event handler and contains the graphics of the control</param>
        public override void DrawOutline(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            switch (typeOfTool)
            {
                case 1:
                    g.DrawRectangle(p, GetRectangle());
                    break;
                case 2:
                    g.DrawEllipse(p, GetRectangle());
                    break;
                case 3:
                    if(pointsInTool != null && pointsInTool.Count > 2)
                        g.DrawLine(p, pointsInTool[iterator], pointsInTool[iterator+1]);
                    break;
                default:
                    g.DrawRectangle(p, GetRectangle());
                    break;
            }
            // Don't do g.Dispose for this one; it removes the PaintEvent's graphics object which leads to an error
        }

        /// <summary>
        /// assigns the passed list to the tool object's list
        /// (previous work got wiped out by an accidental revert during a sync, polygon draw will be operational this weekend)
        /// <list type="bullet">
        /// <item>Date: 04/14/2023</item>
        /// <item>Programmer: Taylor Nastally</item>
        /// </list>
        /// </summary>
        /// <param name="points">is the list of Points used to draw polygons</param>
        public override void Points(List<Point> points)
        {
            if (this.pointsInTool == null)
                pointsInTool = new List<Point>();
            pointsInTool = points;
            Console.WriteLine("\n");
            foreach (var point in pointsInTool)
            {
                Console.WriteLine("{0}, ", point);
            }
        }

        /// <summary>
        /// Creates new rectangle based off of the mouse location, if NULL
        /// else redraws the rectangle
        /// <list type="bullet">
        /// <item>Date: 04/05/2023</item>
        /// <item>Programmer: Taylor Nastally</item>
        /// </list>
        /// </summary>
        /// <returns>Rectangle showing where the shape should be drawn.</returns>
        private Rectangle GetRectangle()
        {
            locationXY.X = startX;
            locationXY.Y = startY;
            locationX1Y1.X = endX;
            locationX1Y1.Y = endY;
            if(this.r == null)
                r = new Rectangle();
            this.r.X = Math.Min(locationXY.X, locationX1Y1.X);
            this.r.Y = Math.Min(locationXY.Y, locationX1Y1.Y);
            this.r.Width = Math.Abs(locationXY.X - locationX1Y1.X);
            this.r.Height = Math.Abs(locationXY.Y - locationX1Y1.Y);
            return this.r;
        }
    }
}