using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    /// <summary>
    /// Date: 4/01/23
    /// Programmer(s): Justin Reyes
    /// Changes class which implements Undo/Redo functionality by passing image states between two linked lists (LL).
    /// Contains 6 methods:
    /// Changes() which is the constructor for the class that instantiates the LLs.
    /// addChange() which saves a new image state.
    /// undoChange() which reverts to a previous image state.
    /// redoChange() which reverts to an undone image state.
    /// setNewImage() which is a helper function to undoChange() and redoChange() and sets the pictureBox to the right image state.
    /// clearStacks() which resets the two LLs.
    /// The FILO functionality of Stacks is the most important part of the class's methods.
    /// However, a linked-list is used instead to limit the number of images saved by removing from the bottom of the "Stack".
    /// </summary>
    public class Changes
    {
        private LinkedList<System.Drawing.Image> undoStack;
        private LinkedList<System.Drawing.Image> redoStack;

        /// <summary>
        /// Date: 4/01/23
        /// Programmer(s): Justin Reyes
        /// Constructor for the Changes class.
        /// Instantiates the undoStack and redoStack linked-lists.
        /// </summary>
        public Changes()
        {
            undoStack = new LinkedList<System.Drawing.Image>();
            redoStack = new LinkedList<System.Drawing.Image>();
        }

        /// <summary>
        /// Date: 4/01/23
        /// Programmer(s): Justin Reyes
        /// Add a new item to undoStack and reset redoStack.
        /// </summary>
        /// <param name="pictureBox">Reference to the pictureBox.</param>
        public void addChange(System.Windows.Forms.PictureBox pictureBox)
        {
            System.Drawing.Image curr = (System.Drawing.Image)pictureBox.Image.Clone();
            undoStack.AddLast(curr);
            if (undoStack.Count > 20) undoStack.RemoveFirst();

            redoStack.Clear();
            redoStack.AddLast(curr);
        }

        /// <summary>
        /// Date: 4/01/23
        /// Programmer(s): Justin Reyes
        /// Move top of undoStack to top of redoStack and set the new image.
        /// </summary>
        /// <param name="pictureBox">Reference to the pictureBox.</param>
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
        
        /// <summary>
        /// Date: 4/01/23
        /// Programmer(s): Justin Reyes
        /// Move top of redoStack to top of undoStack
        /// </summary>
        /// <param name="pictureBox">Reference to the pictureBox.</param>
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

        /// <summary>
        /// Date: 4/01/23
        /// Programmer(s): Justin Reyes
        /// Set picture box image to the top of undoStack.
        /// </summary>
        /// <param name="pictureBox">Reference to the pictureBox.</param>
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

            pictureBox.Width = bmp.Width;
            pictureBox.Height = bmp.Height;
            pictureBox.Image = bmp;
        }


        /// <summary>
        /// Date: 4/01/23
        /// Programmer(s): Justin Reyes
        /// Clear the two linked lists (after saving, loading, or creating new images).
        /// </summary>
        public void clearStacks()
        {
            undoStack.Clear();
            redoStack.Clear();
        }
    }
}