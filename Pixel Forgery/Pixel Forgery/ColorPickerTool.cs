using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pixel_Forgery
{
    /// <summary>
    /// Constructor for the ColorPickerTool that allows selection of the tool from the menu bar.
    /// <list type="bullet">
    /// <item>Date: 4/16/23</item>
    /// <item>Programmer(s): Gregory Khrom-Abramyan</item>
    /// </list>
    /// </summary>
    public class ColorPickerTool : PixelForgeryTool
    {
        /// <summary>
        /// UseTool override for ColorPicker
        /// <list type="bullet">
        /// <item>Date: 4/16/23</item>
        /// <item>Programmer(s): Gregory Khrom-Abramyan</item>
        /// </list>
        /// </summary>
        /// <param name="e">Reference to mouse</param>
        /// <param name="pictureBox1">Reference to pictureBox</param>
        public override void UseTool(MouseEventArgs e, System.Windows.Forms.PictureBox pictureBox1)
        {
            // method not used
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            pickedColor = bmp.GetPixel(e.X, e.Y);
        }
    }
}