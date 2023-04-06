using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    public class ColorTool : PixelForgeryTool
    {
        ColorDialog cd = new ColorDialog();

        public void selectColor()
        {
            if (cd.ShowDialog() == DialogResult.OK)
            {
                currentColor = cd.Color;
            }
        }

    }
}