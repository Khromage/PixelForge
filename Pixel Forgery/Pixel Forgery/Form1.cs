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
        }

        // Open File Button
        private void openButton_Click(object sender, EventArgs e)
        {
            FileExplorerDialog fd = new FileExplorerDialog();
            fd.loadFile(this.pictureBox);
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
            tool = new BrushTool();
        }

        // Eraser Tool Button
        private void eraserButton_Click(object sender, EventArgs e)
        {
            // Switch the tool type to Eraser Tool
            tool = new EraserTool();
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
                tool.useTool(sender, e, pictureBox);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Update drawing status
            tool.isDrawing = false;
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
            }
            else if (e.KeyCode == Keys.O && (e.Control)) // Ctrl+O for Open
            {
                FileExplorerDialog fd = new FileExplorerDialog();
                fd.loadFile(this.pictureBox);
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
    }
}
