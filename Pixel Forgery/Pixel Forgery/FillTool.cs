using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    /// <summary>
    /// FillTool class created for flood filling the canvas
    /// <list type="bullet">
    /// <item>Date: 4/10/23</item>
    /// <item>Programmer(s): Justin Reyes</item>
    /// </list>
    /// Contains several methods:
    /// <list type="number">
    /// <item>UseTool() is an overridden method to the Tool class</item>
    /// <item>DfsFill() uses the Depth-First Search algorithm to flood fill the canvas</item>
    /// <item>SetColor() is a helper function for DfsFill() which sets a pixel to the currentColor</item>
    /// <item>AddPoint() is a helper function for DfsFill() which scans and adds a point to the DFS stack</item>
    /// <item>IsInside() is a helper function for DfsFill() which checks if a point is still inside the canvas</item>
    /// </list>
    /// </summary>
    public class FillTool : PixelForgeryTool
    {
        /// <summary>
        /// Overloads the PixelForgeryTool's UseTool method with the Fill Tool method.
        /// <list type="bullet">
        /// <item>Date: 4/10/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="e">An EventListener used checking for Mouse location.</param>
        /// <param name="pictureBox1">Reference to the canvas.</param>
        public override void UseTool(MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
            // Set stopwatch for Fill Tool algorithm testing
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Do Fill algorithm
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            if(bmp.GetPixel(e.X, e.Y).ToArgb() != currentColor.ToArgb())
                DfsFill(e, pictureBox1);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("Fill RunTime " + elapsedTime);
        }

        /// <summary>
        /// Uses Depth-First Search to do a flood fill starting from the current mouse location.
        /// <list type="bullet">
        /// <item>Date: 4/15/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="e">An EventListener used checking for Mouse location.</param>
        /// <param name="pictureBox1">Reference to the canvas.</param>
        public void DfsFill(MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            int x = e.X, y = e.Y, w = bmp.Width, h = bmp.Height;
            Rectangle r = new Rectangle(0, 0, w, h);

            // Lock Bits to optimize pixel setting
            System.Drawing.Imaging.BitmapData bmpData =
               bmp.LockBits(r, System.Drawing.Imaging.ImageLockMode.ReadWrite,
               bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy bitmap to rgb array
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            int[,] mask = new int[w, h];                                                                
            Stack<Point> stack = new Stack<Point>();

            int currByte = (x + y * w) * 4;
            int G = rgbValues[currByte], B = rgbValues[currByte + 1], R = rgbValues[currByte + 2], A = rgbValues[currByte + 3];
            Color replacedColor = Color.FromArgb(A, R, G, B);

            stack.Push(new Point(x, y));
            mask[x, y] = 1;

            while (stack.Count != 0)
            {
                Point current = stack.Pop();
                SetColor(current.X, current.Y, w, rgbValues);

                // Check neighboring points
                AddPoint(current.X - 1, current.Y, w, h, mask, rgbValues, replacedColor, stack);
                AddPoint(current.X, current.Y + 1, w, h, mask, rgbValues, replacedColor, stack);
                AddPoint(current.X + 1, current.Y, w, h, mask, rgbValues, replacedColor, stack);
                AddPoint(current.X, current.Y - 1, w, h, mask, rgbValues, replacedColor, stack);
            }

            // Copy rgb array to bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits
            bmp.UnlockBits(bmpData);

            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Sets the rgb values of the given pixel position.
        /// <list type="bullet">
        /// <item>Date: 4/15/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="x">Horizontal location of the point.</param>
        /// <param name="y">Vertical location of the point.</param>
        /// <param name="w">Width of the canvas.</param>
        /// <param name="rgbValues">Byte array of rgb values in the bitmap.</param>
        public void SetColor(int x, int y, int w, byte[] rgbValues)
        {
            int currByte = (x + y * w) * 4;
            rgbValues[currByte] = currentColor.B;
            rgbValues[currByte + 1] = currentColor.G;
            rgbValues[currByte + 2] = currentColor.R;
            rgbValues[currByte + 3] = currentColor.A;
        }

        /// <summary>
        /// Validates and adds a Point to the DFS stack.
        /// <list type="bullet">
        /// <item>Date: 4/15/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="x">Horizontal location of the point.</param>
        /// <param name="y">Vertical location of the point.</param>
        /// <param name="w">Width of the canvas.</param>
        /// <param name="h">Height of the canvas.</param>
        /// <param name="mask">2D integer array showing which points have been checked.</param>
        /// <param name="rgbValues">Byte array of rgb values in the bitmap.</param>
        /// <param name="replacedColor">Color that needs to be replaced in the flood fill.</param>
        /// <param name="stack">Stack structure used for DFS algorithm.</param>
        public void AddPoint(int x, int y, int w, int h, int[,] mask, byte[] rgbValues, Color replacedColor, Stack<Point> stack)
        {
            if (IsInside(x, y, w, h) && mask[x, y] == 0)
            {
                int currByte = (x + y * w) * 4;
                int G = rgbValues[currByte], B = rgbValues[currByte + 1], R = rgbValues[currByte + 2], A = rgbValues[currByte + 3];
                Color currentColor = Color.FromArgb(A, R, G, B);

                if (currentColor.ToArgb() == replacedColor.ToArgb())
                {
                    mask[x, y] = 1;
                    stack.Push(new Point(x, y));
                }
            }
        }

        /// <summary>
        /// Checks whether the given position is inside the grid.
        /// <list type="bullet">
        /// <item>Date: 4/15/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="x">Horizontal location of the point.</param>
        /// <param name="y">Vertical location of the point.</param>
        /// <param name="width">Width of the canvas.</param>
        /// <param name="height">Height of the canvas.</param>
        /// <returns>Returns false if the point is outside the canvas, else true</returns>
        public Boolean IsInside(int x, int y, int width, int height)
        {
            if (x < 0 || y < 0 || x >= width || y >= height) return false;
            else return true;
        }
    }
}