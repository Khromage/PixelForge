﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    /// <summary>
    /// Date: 3/29/23
    /// Programmer(s): Justin Reyes
    /// FileExplorerDialog class which handles File input/output for the program.
    /// Contains two methods:
    /// saveFile() does file output, loadFile() does file input
    /// </summary>
    public class FileExplorerDialog
    {
        /// <summary>
        /// Date: 3/29/23
        /// Programmer(s): Justin Reyes
        /// Launches a SaveFileDialog to save the pictureBox's image to the location that the user selects.
        /// </summary>
        /// <param name="pictureBox">Reference to the pictureBox.</param>
        public void saveFile(PictureBox pictureBox)
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
        /// Date: 3/29/23
        /// Programmer(s): Justin Reyes
        /// Launches an OpenFileDialog to load a selected image to the pictureBox.
        /// </summary>
        /// <param name="pictureBox">Reference to the pictureBox.</param>
        public void loadFile(PictureBox pictureBox)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.Filter = "All Picture Files (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif|PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif";
            ofd.FilterIndex = 1;
            ofd.Title = "Open";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(ofd.FileName);
                pictureBox.Width = image.Width;
                pictureBox.Height = image.Height;
                pictureBox.Image = image;

                // Always convert bmp format to 32 bits per pixel to make lock bits consistent
                Bitmap orig = (Bitmap)pictureBox.Image;
                Bitmap bmp = new Bitmap(orig.Width, orig.Height,
                    System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(orig, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    g.Dispose();
                }

                pictureBox.Image = bmp;
                pictureBox.Refresh();
            }
        }
    }
}