using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    /// <summary>
    /// FileExplorerDialog class which handles File input/output for the program.
    /// <list type="bullet">
    /// <item>Date: 3/29/23</item>
    /// <item>Programmer(s): Justin Reyes</item>
    /// </list>
    /// Contains two methods:
    /// <list type="number">
    /// <item>SaveFile() does file output</item>
    /// <item>OpenFile() does file input</item>
    /// </list>
    /// </summary>
    public class FileExplorerDialog
    {
        /// <summary>
        /// Launches a SaveFileDialog to save the pictureBox's image to the location that the user selects.
        /// <list type="bullet">
        /// <item>Date: 3/29/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="pictureBox">Reference to the pictureBox.</param>
        public void SaveFile(PictureBox pictureBox)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif";
            sfd.FilterIndex = 1;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image.Save(sfd.FileName);
            }
        }

        /// <summary>
        /// Launches an OpenFileDialog to load a selected image to the pictureBox.
        /// <list type="bullet">
        /// <item>Date: 3/29/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="orig">Reference to the original Bitmap.</param>
        /// <returns>Bitmap object containing the opened image</returns>
        public Bitmap OpenFile(Bitmap orig)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            Bitmap bmp = orig;

            ofd.FileName = "";
            ofd.Filter = "All Picture Files (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif|PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif";
            ofd.FilterIndex = 1;
            ofd.Title = "Open";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                System.Drawing.Image image = System.Drawing.Image.FromFile(ofd.FileName);

                orig = (Bitmap)image;
                bmp = new Bitmap(image.Width, image.Height,
                    System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(orig, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    g.Dispose();
                }
            }

            return bmp;
        }
    }
}