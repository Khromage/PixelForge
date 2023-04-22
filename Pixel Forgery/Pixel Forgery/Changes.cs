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
    /// Changes class which implements Undo/Redo functionality by passing image states between two linked lists (LL).
    /// <list type="bullet">
    /// <item>Date: 4/01/23</item>
    /// <item>Programmer(s): Justin Reyes</item>
    /// </list>
    /// Contains 6 methods:
    /// <list type="number">
    /// <item>Changes() which is the constructor for the class that instantiates the LLs</item>
    /// <item>AddChange() which saves a new image state</item>
    /// <item>UndoChange() which reverts to a previous image state</item>
    /// <item>RedoChange() which reverts to an undone image state</item>
    /// <item>SetNewImage() which is a helper function to UndoChange() and RedoChange() and sets the pictureBox to the right image state</item>
    /// <item>ClearStacks() which resets the two LLs</item>
    /// </list>
    /// The FILO functionality of Stacks is the most important part of the class's methods.
    /// However, a linked-list is used instead to limit the number of images saved by removing from the bottom of the "Stack".
    /// </summary>
    public class Changes
    {
        private LinkedList<System.Drawing.Image> undoStack;
        private LinkedList<System.Drawing.Image> redoStack;

        /// <summary>
        /// Constructor for the Changes class.
        /// Instantiates the undoStack and redoStack linked-lists.
        /// <list type="bullet">
        /// <item>Date: 4/01/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        public Changes()
        {
            undoStack = new LinkedList<System.Drawing.Image>();
            redoStack = new LinkedList<System.Drawing.Image>();
        }

        /// <summary>
        /// Add a new item to undoStack and reset redoStack.
        /// <list type="bullet">
        /// <item>Date: 4/01/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="pictureBox">Reference to the pictureBox.</param>
        public void AddChange(System.Windows.Forms.PictureBox pictureBox)
        {
            System.Drawing.Image curr = (System.Drawing.Image)pictureBox.Image.Clone();
            undoStack.AddLast(curr);
            if (undoStack.Count > 20) undoStack.RemoveFirst();

            redoStack.Clear();
            redoStack.AddLast(curr);
        }

        /// <summary>
        /// Move top of undoStack to top of redoStack and set the new image.
        /// <list type="bullet">
        /// <item>Date: 4/01/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="pictureBox">Reference to the pictureBox.</param>
        public void UndoChange(System.Windows.Forms.PictureBox pictureBox)
        {
            if (undoStack.Count > 1)
            {
                System.Drawing.Image img = undoStack.Last();
                System.Drawing.Image old = (System.Drawing.Image)img.Clone();

                redoStack.AddLast(old);

                undoStack.RemoveLast();

                SetNewImage(pictureBox);
            }
        }

        /// <summary>
        /// Move top of redoStack to top of undoStack
        /// <list type="bullet">
        /// <item>Date: 4/01/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="pictureBox">Reference to the pictureBox.</param>
        public void RedoChange(System.Windows.Forms.PictureBox pictureBox)
        {
            if(redoStack.Count > 1)
            {
                System.Drawing.Image img = redoStack.Last();
                System.Drawing.Image curr = (System.Drawing.Image)img.Clone();

                undoStack.AddLast(curr);
                redoStack.RemoveLast();

                SetNewImage(pictureBox);
            }
        }

        /// <summary>
        /// Set picture box image to the top of undoStack.
        /// <list type="bullet">
        /// <item>Date: 4/01/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="pictureBox">Reference to the pictureBox.</param>
        public void SetNewImage(System.Windows.Forms.PictureBox pictureBox)
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
        /// Clear the two linked lists (after saving, loading, or creating new images).
        /// <list type="bullet">
        /// <item>Date: 4/01/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        public void ClearStacks()
        {
            undoStack.Clear();
            redoStack.Clear();
        }
    }
}