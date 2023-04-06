using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace Pixel_Forgery
{
    public partial class PixelForgeryGUI : Form
    {
        private BrushTool brushTool = null;
        private EraserTool eraserTool = null;
        private ShapeTool shapeTool = null;

        public PixelForgeryGUI()
        {
            InitializeComponent();
            changes = new Changes();
            BMP = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = BMP;
            pictureBox.BackColor = Color.White;

            using (Graphics g = Graphics.FromImage(BMP))
            {
                Rectangle bg = new Rectangle(0, 0, BMP.Width, BMP.Height);
                g.FillRectangle(Brushes.White, bg);
            }
            changes.makeChange(pictureBox);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Save File Button
        private void saveButton_Click(object sender, EventArgs e)
        {
            FileExplorerDialog fd = new FileExplorerDialog();
            fd.saveFile(this.pictureBox);
            changes.clearStacks();
            changes.makeChange(pictureBox);
        }

        // Open File Button
        private void openButton_Click(object sender, EventArgs e)
        {
            FileExplorerDialog fd = new FileExplorerDialog();
            fd.loadFile(this.pictureBox);
            changes.clearStacks();
            changes.makeChange(pictureBox);
        }

        // Undo Changes Button
        private void undoButton_Click(object sender, EventArgs e)
        {
            changes.undoChange(pictureBox);
        }

        // Redo Changes Button
        private void redoButton_Click(object sender, EventArgs e)
        {
            changes.redoChange(pictureBox);
        }

        // Brush Tool Button
        private void brushButton_Click(object sender, EventArgs e)
        {
            // Switch the tool type to Brush Tool
            //tool = new BrushTool();

            if (brushTool == null)
                brushTool = new BrushTool();
            tool = brushTool;
        }

        // Eraser Tool Button
        private void eraserButton_Click(object sender, EventArgs e)
        {
            // Switch the tool type to Eraser Tool
            //tool = new EraserTool();

            if (eraserTool == null)
                eraserTool = new EraserTool();
            tool = eraserTool;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Update drawing status
            tool.isDrawing = true;
            tool.startX = e.X;
            tool.startY = e.Y;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(tool.isDrawing == true)
            {
                tool.endX = e.X;
                tool.endY = e.Y;
                tool.useTool(sender, e, pictureBox);
                Refresh();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Update drawing status
            tool.isDrawing = false;
            tool.endX = e.X;
            tool.endY = e.Y;
            changes.makeChange(pictureBox);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
        }
        
        // Keyboard Shortcuts
        private void PixelForgeryGUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && (e.Control)) // Ctrl+S for Save
            {
                FileExplorerDialog fd = new FileExplorerDialog();
                fd.saveFile(this.pictureBox);
                changes.clearStacks();
                changes.makeChange(pictureBox);
            }
            else if (e.KeyCode == Keys.O && (e.Control)) // Ctrl+O for Open
            {
                FileExplorerDialog fd = new FileExplorerDialog();
                fd.loadFile(this.pictureBox);
                changes.clearStacks();
                changes.makeChange(pictureBox);
            }
            else if (e.KeyCode == Keys.Z && (e.Control)) // Ctrl+Z for Undo
            {
                changes.undoChange(pictureBox);
            }
            else if (e.KeyCode == Keys.Y && (e.Control)) // Ctrl+Y for Redo
            {
                changes.redoChange(pictureBox);
            }
        }

        /// <summary>
        /// Populates the brush-size text box with the current brush size
        /// </summary>
        private void brushSizeToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            brushSizeTextBox.Text = brushTool.BrushWidth.ToString();
        }

        /// <summary>
        /// Populates the eraser-size text box with the current eraser size
        /// </summary>
        private void eraserSizeToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            eraserSizeTextBox.Text = eraserTool.EraserWidth.ToString();
        }

        /// <summary>
        /// Processes brush size changes. If an invalid value is input the brush size is
        /// set back to the default size of 5
        /// </summary>
        private void brushSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            string s = brushSizeTextBox.Text;

            if (float.TryParse(s, out float width) && width > 0)
                brushTool.BrushWidth = width;
            else
                brushTool.BrushWidth = 5;
        }

        /// <summary>
        /// Processes eraser size changes. If an invalid value is input the eraser size is
        /// set back to the default size of 20
        /// </summary>
        private void eraserSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            string s = eraserSizeTextBox.Text;

            if (float.TryParse(s, out float width) && width > 0)
                eraserTool.EraserWidth = width;
            else
                eraserTool.EraserWidth = 20;
        }

        /// <summary>
        /// Clears the brush-size text box when the user clicks inside the text box
        /// </summary>
        private void brushSizeTextBox_Click(object sender, EventArgs e)
        {
            brushSizeTextBox.Clear();
        }

        /// <summary>
        /// Clears the eraser-size text box when the user clicks inside the text box
        /// </summary>
        private void eraserSizeTextBox_Click(object sender, EventArgs e)
        {
            eraserSizeTextBox.Clear();
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(shapeTool == null)
                shapeTool = new ShapeTool();
            tool = shapeTool;
        }

        private void colorTool_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                tool.currentColor = cd.Color;
            }
        }
    }
}
