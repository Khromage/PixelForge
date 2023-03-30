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


namespace Pixel_Forgery
{
    public partial class PixelForgeryGUI : Form
    {
        public PixelForgeryGUI()
        {
            InitializeComponent();
            BMP = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for(int x = 0; x < pictureBox1.Width; x++)
            {
                for(int y = 0; y < pictureBox1.Height; y++)
                {
                    BMP.SetPixel(x, y, Color.White);
                }
            }
            pictureBox1.Image = BMP;
            pictureBox1.BackColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Save File Button
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileExplorerDialog fd = new FileExplorerDialog();
            fd.saveFile(this.pictureBox1);
        }

        // Load File Button
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileExplorerDialog fd = new FileExplorerDialog();
            fd.loadFile(this.pictureBox1);
        }

        // Brush Tool Button
        private void toolStripButton1_Click(object sender, EventArgs e) // brush button in tool menu
        {
            // Switch the tool type to Brush Tool
            tool = new BrushTool();
            Console.WriteLine("Brush Tool Selected");
        }

        // Eraser Tool Button
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // Switch the tool type to Eraser Tool
            tool = new EraserTool();
            Console.WriteLine("Eraser Tool Selected");
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // update drawing status
            tool.isDrawing = true;
            tool.startX = e.X;
            tool.startY = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(tool.isDrawing == true)
            {
                tool.useTool(sender, e, pictureBox1);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // update drawing status
            tool.isDrawing = false;
            BMP = (Bitmap)pictureBox1.Image;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
