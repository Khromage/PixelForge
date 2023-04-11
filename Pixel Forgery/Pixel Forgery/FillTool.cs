using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    public class FillTool : PixelForgeryTool
    {
        public override void useTool(object sender, MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Color replacedColor = bmp.GetPixel(e.X, e.Y);                   // Color to be replaced
            int[,] points = new int[bmp.Width, bmp.Height];                 // Marks points that have already been checked
            Queue<Point> queue = new Queue<Point>();                        // Queue needed for breadth-first algo

            // Initial point from mouse click
            queue.Enqueue(new Point(e.X, e.Y));
            points[e.X, e.Y] = 1;

            while (queue.Count != 0)
            {
                bmp.SetPixel(queue.Peek().X, queue.Peek().Y, currentColor);
                Point current = queue.Dequeue();

                if (current.Y - 1 >= 0 && points[current.X, current.Y - 1] == 0 && bmp.GetPixel(current.X, current.Y - 1) == replacedColor)
                {
                    Point up = new Point(current.X, current.Y - 1);
                    points[up.X, up.Y] = 1;
                    queue.Enqueue(up);
                }

                if (current.X + 1 < bmp.Width && points[current.X + 1, current.Y] == 0 && bmp.GetPixel(current.X + 1, current.Y) == replacedColor)
                {
                    Point right = new Point(current.X + 1, current.Y);
                    points[right.X, right.Y] = 1;
                    queue.Enqueue(right);
                }

                if (current.Y + 1 < bmp.Height && points[current.X, current.Y + 1] == 0 && bmp.GetPixel(current.X, current.Y + 1) == replacedColor)
                {
                    Point down = new Point(current.X, current.Y + 1);
                    points[down.X, down.Y] = 1;
                    queue.Enqueue(down);
                }

                if (current.X - 1 >= 0 && points[current.X - 1, current.Y] == 0 && bmp.GetPixel(current.X - 1, current.Y) == replacedColor)
                {
                    Point left = new Point(current.X - 1, current.Y);
                    points[left.X, left.Y] = 1;
                    queue.Enqueue(left);
                }
            }

            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }
    }
}