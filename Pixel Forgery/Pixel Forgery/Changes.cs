using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    public class Changes
    {
        private LinkedList<System.Drawing.Image> undoStack;
        private LinkedList<System.Drawing.Image> redoStack;

        public Changes()
        {
            undoStack = new LinkedList<System.Drawing.Image>();
            redoStack = new LinkedList<System.Drawing.Image>();
        }

        // Add a new item to undo stack
        public void addChange(System.Windows.Forms.PictureBox pictureBox)
        {
            System.Drawing.Image curr = (System.Drawing.Image)pictureBox.Image.Clone();
            undoStack.AddLast(curr);
            if (undoStack.Count > 20) undoStack.RemoveFirst();

            redoStack.Clear();
            redoStack.AddLast(curr);
        }

        // Move top of undo stack to top of redo stack
        public void undoChange(System.Windows.Forms.PictureBox pictureBox)
        {
            if (undoStack.Count > 1)
            {
                System.Drawing.Image img = undoStack.Last();
                System.Drawing.Image old = (System.Drawing.Image)img.Clone();

                redoStack.AddLast(old);

                undoStack.RemoveLast();

                setNewImage(pictureBox);
            }
        }

        // Move top of redo stack to top of undo stack
        public void redoChange(System.Windows.Forms.PictureBox pictureBox)
        {
            if(redoStack.Count > 1)
            {
                System.Drawing.Image img = redoStack.Last();
                System.Drawing.Image curr = (System.Drawing.Image)img.Clone();

                undoStack.AddLast(curr);
                redoStack.RemoveLast();

                setNewImage(pictureBox);
            }
        }

        // Set picture box image to the top of undo stack
        public void setNewImage(System.Windows.Forms.PictureBox pictureBox)
        {
            System.Drawing.Image img = undoStack.Last();
            System.Drawing.Image current = (System.Drawing.Image)img.Clone();

            Bitmap orig = (Bitmap)current;
            Bitmap bmp = new Bitmap(orig.Width, orig.Height,
                System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(orig, new Rectangle(0, 0, bmp.Width, bmp.Height));
                g.Dispose();
            }

            pictureBox.Image = bmp;
        }

        // Clear the stacks (after saving, loading, or creating new images)
        public void clearStacks()
        {
            undoStack.Clear();
            redoStack.Clear();
        }
    }
}