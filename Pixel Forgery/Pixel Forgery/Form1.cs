using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pixel_Forgery
{
    public partial class PixelForge : Form
    {
        public PixelForge()
        {
            InitializeComponent();
            BMP = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = BMP;
            pictureBox1.BackColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e) // brush button in tool menu
        {
/*
            Random r = new Random();
            for (int x = 1; x < 500; x++)
            {
                BMP.SetPixel(x, r.Next(500), Color.Black);

            }
            panel1.BackgroundImage = BMP;
*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
        private void paintOnCanvas(int x, int y)
        {
            Graphics gfx = Graphics.FromImage(pictureBox1.Image);
            gfx.FillEllipse(new SolidBrush(Color.Black), x - 5, y - 5, 10, 10);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // update drawing status
            isDrawing = true;

            paintOnCanvas(e.X, e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isDrawing == true)
            {
                paintOnCanvas(e.X, e.Y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // update drawing status
            isDrawing = false;
        }
    }
}
