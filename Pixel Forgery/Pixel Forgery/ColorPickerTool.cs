using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    public class ColorPickerTool : PixelForgeryTool
    {
        public override void useTool(object sender, MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            pickedColor = bmp.GetPixel(e.X, e.Y);
            currentColor = pickedColor;
        }
    }
}