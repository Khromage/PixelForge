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
    public class ShapeTool : PixelForgeryTool
    {
        Rectangle r;
        List<Point> pointsInTool = new List<Point>();
        Point locationX1Y1;
        Point locationXY;

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

        public override void points(object sender, List<Point> points)
        {
            pointsInTool = points;
        }

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