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
    /// Date: 04/05/2023 (initial commit)
    /// Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally, Lilianna Rosales
    /// Shape tool class controls the type and method of construction for the user's desired drawing type.
    /// Contains two use methods (useTool() and drawOutline()):
    /// useTool() controls the instancing of the shape, drawOutline() controls the dynamic drawing of the shape as the user drags the mouse.
    /// </summary>
    public class ShapeTool : PixelForgeryTool
    {
        Rectangle r;
        List<Point> pointsInTool = new List<Point>();
        Point locationX1Y1;
        Point locationXY;

        /// <summary>
        /// Date: 04/05/2023
        /// Programmer: Taylor Nastally
        /// Contains a switch that checks the typeOfTool and calls the appropriate draw function.
        /// Draws to the pictureBox with Graphics g.
        /// </summary>
        /// <param name="sender">Reference to the pictureBox object.</param>
        /// <param name="e">Event listener used to check the Mouse's location.</param>
        /// <param name="pictureBox1">Reference to the canvas.</param>
        public override void useTool(object sender, MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
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
                    g.DrawPolygon(p, pointsInTool.ToArray());
                    break;
                default:
                    g.DrawRectangle(p, GetRectangle());
                    break;
            }
            pictureBox1.Refresh();
            g.Dispose();
        }

        /// <summary>
        /// Date: 04/11/2023
        /// Programmer(s): Justin Reyes, Taylor Nastally
        /// Contains a switch to check and draw the appropriate shape based on type of tool.
        /// Draws with the passed Graphics g from onPaint in Form1.
        /// </summary>
        /// <param name="sender">Reference to the pictureBox object.</param>
        /// <param name="e">Event listener for the canvas's PaintEvent.</param>
        public override void drawOutline(object sender, PaintEventArgs e)
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
                    g.DrawPolygon(p, pointsInTool.ToArray());
                    break;
                default:
                    g.DrawRectangle(p, GetRectangle());
                    break;
            }
            // Don't do g.Dispose for this one; it removes the PaintEvent's graphics object which leads to an error
        }

        /// <summary>
        /// Date: 04/14/2023
        /// Programmer: Taylor Nastally
        /// Assigns the passed list to the tool object's list.
        /// </summary>
        /// <param name="sender">Reference to the pictureBox object.</param>
        /// <param name="points">List of points.</param>
        public override void points(object sender, List<Point> points)
        {
            pointsInTool = points;
        }

        /// <summary>
        /// Date: 04/05/2023
        /// Programmer: Taylor Nastally
        /// Creates new rectangle based off of the mouse location, if NULL
        /// else redraws the rectangle
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