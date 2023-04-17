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
        private Bitmap BMP;
        private Changes changes;
        private PixelForgeryTool tool;
        private BrushTool brushTool = new BrushTool();
        private EraserTool eraserTool = new EraserTool();
        private ShapeTool shapeTool = new ShapeTool();
        private ColorPickerTool colorPickerTool = new ColorPickerTool();
        private FillTool fillTool = new FillTool();
        private List<Point> points = new List<Point>();

        public PixelForgeryGUI()
        {
            InitializeComponent();
            changes = new Changes();
            BMP = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = BMP;
            pictureBox.BackColor = Color.White;
            colorChangeButton.BackColor = Color.Black;
            tool = brushTool;
            changeToolBackground(1);

            using (Graphics g = Graphics.FromImage(BMP))
            {
                Rectangle bg = new Rectangle(0, 0, BMP.Width, BMP.Height);
                g.FillRectangle(Brushes.White, bg);
            }
            changes.addChange(pictureBox);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// Creates a new canvas for the user to draw in, defaults to 918x595 pixels in size
        /// </summary>
        private void newButton_Click(object sender, EventArgs e)                // New Button
        {
            BMP = new Bitmap(918, 595);
            using (Graphics g = Graphics.FromImage(BMP))
            {
                Rectangle bg = new Rectangle(0, 0, BMP.Width, BMP.Height);
                g.FillRectangle(Brushes.White, bg);
            }
            pictureBox.Size = BMP.Size;
            pictureBox.Image = BMP;
            changes.clearStacks();
            changes.addChange(pictureBox);
        }

        /// <summary>
        /// Opens a save file dialog to let the user save the image
        /// </summary>
        private void saveButton_Click(object sender, EventArgs e)               // Save File Button
        {
            FileExplorerDialog fd = new FileExplorerDialog();
            fd.saveFile(this.pictureBox);
            changes.clearStacks();
            changes.addChange(pictureBox);
        }

        /// <summary>
        /// Opens an open file dialog to let the user open an image from their pc.
        /// </summary>
        private void openButton_Click(object sender, EventArgs e)               // Open File Button
        {   
            FileExplorerDialog fd = new FileExplorerDialog();
            fd.loadFile(this.pictureBox);
            BMP = (Bitmap)pictureBox.Image;
            changes.clearStacks();
            changes.addChange(pictureBox);
        }

        /// <summary>
        /// Opens a form that allows the user to set canvas dimensions.
        /// </summary>
        private void imagePropertiesButton_Click(object sender, EventArgs e)    // Image Properties Button
        {
            try
            {
                using(ImagePropertiesForm iForm = new ImagePropertiesForm())
                {
                    iForm.Owner = this;
                    iForm.Text = "";
                    iForm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        /// <summary>
        /// Reverts the image to its previous state.
        /// </summary>
        private void undoButton_Click(object sender, EventArgs e)               // Undo Changes Button
        {
            changes.undoChange(pictureBox);
        }

        /// <summary>
        /// Reverts an undone change
        /// </summary>
        private void redoButton_Click(object sender, EventArgs e)               // Redo Changes Button
        {
            changes.redoChange(pictureBox);
        }

        /// <summary>
        /// Switches the user's tool to the brush tool
        /// </summary>
        private void brushButton_Click(object sender, EventArgs e)              // Brush Tool Button
        {
            tool = brushTool;
            changeToolBackground(1);
        }

        /// <summary>
        /// Switches the user's tool to the eraser tool
        /// </summary>
        private void eraserButton_Click(object sender, EventArgs e)             // Eraser Tool Button
        {
            tool = eraserTool;
            changeToolBackground(2);
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
            tool = shapeTool;
            tool.typeOfTool = 1;
            changeToolBackground(3);
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = shapeTool;
            tool.typeOfTool = 2;
            changeToolBackground(3);
        }

        private void polygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = shapeTool;
            tool.typeOfTool = 3;
            changeToolBackground(3);
        }

        private void fillButton_Click(object sender, EventArgs e)
        {
            tool = fillTool;
            changeToolBackground(4);
        }

        private void colorTool_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                tool.currentColor = cd.Color;
                shapeTool.currentColor = cd.Color;
                brushTool.currentColor = cd.Color;
                fillTool.currentColor = cd.Color;
                colorChangeButton.BackColor = cd.Color;
            }
        }
        private void colorPickerButton_Click(object sender, EventArgs e)
        {

            tool = colorPickerTool;
            pickedcolordisplay.BackColor = tool.pickedColor;
            changeToolBackground(5);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    tool.isDrawing = true;
                    tool.startX = e.X;
                    tool.startY = e.Y;
                    if (tool == fillTool) tool.useTool(sender, e, pictureBox);
                    if (tool == shapeTool && tool.typeOfTool == 3) tool.points(sender, points);
                    if (tool == colorPickerTool)
                    {
                        tool.currentColor = tool.pickedColor;
                        shapeTool.currentColor = tool.pickedColor;
                        brushTool.currentColor = tool.pickedColor;
                        fillTool.currentColor = tool.pickedColor;
                        colorChangeButton.BackColor = tool.pickedColor;
                    }
                    break;
                case MouseButtons.Right:
                    tool.isDrawing = true;
                    points.Add(e.Location);
                    break;
                default:
                    Console.WriteLine("uhhhh... Eto..... Bleg?");
                    break;
            }
            
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(tool == colorPickerTool)
            {
                try
                {
                    tool.pickedColor = BMP.GetPixel(e.X, e.Y);
                    pickedcolordisplay.BackColor = tool.pickedColor;
                    if (pickedcolordisplay.BackColor.ToArgb() == 0) pickedcolordisplay.BackColor = Color.White;
                }
                catch (System.ArgumentException ex)
                {
                    Console.WriteLine(ex.Message + " Reverting to default color.");
                    tool.pickedColor = Color.White;
                    pickedcolordisplay.BackColor = Color.White;
                }
            }
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (tool.isDrawing == true)
                    {
                        tool.endX = e.X;
                        tool.endY = e.Y;
                        if (tool == brushTool || tool == eraserTool) tool.useTool(sender, e, pictureBox);
                    }
                    break;
                case MouseButtons.Right:
                    break;
                default:
                    break;
            }
            pictureBox.Refresh();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    tool.isDrawing = false;
                    tool.endX = e.X;
                    tool.endY = e.Y;
                    if (tool == shapeTool) tool.useTool(sender, e, pictureBox);
                    changes.addChange(pictureBox);
                    break;
                case MouseButtons.Right:
                    break;
                default:
                    break;
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
        }
        
        /// <summary>
        /// Allows the user to access menu bar functionality using pre-defined keyboard shortcuts
        /// </summary>
        private void PixelForgeryGUI_KeyDown(object sender, KeyEventArgs e)         // Keyboard Shortcuts
        {
            if (e.KeyCode == Keys.N && (e.Control)) // Ctrl+S for Save
            {
                BMP = new Bitmap(pictureBox.Width, pictureBox.Height);
                using (Graphics g = Graphics.FromImage(BMP))
                {
                    Rectangle bg = new Rectangle(0, 0, BMP.Width, BMP.Height);
                    g.FillRectangle(Brushes.White, bg);
                }
                pictureBox.Image = BMP;
                changes.clearStacks();
                changes.addChange(pictureBox);
            }
            else if (e.KeyCode == Keys.S && (e.Control)) // Ctrl+S for Save
            {
                FileExplorerDialog fd = new FileExplorerDialog();
                fd.saveFile(this.pictureBox);
                changes.clearStacks();
                changes.addChange(pictureBox);
            }
            else if (e.KeyCode == Keys.O && (e.Control)) // Ctrl+O for Open
            {
                FileExplorerDialog fd = new FileExplorerDialog();
                fd.loadFile(this.pictureBox);
                changes.clearStacks();
                changes.addChange(pictureBox);
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
        /// Temporarily updates the canvas.
        /// Actively shows what the shape being drawn looks like.
        /// </summary>
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if(tool.isDrawing && tool == shapeTool)
            {
                tool.drawOutline(sender, e);
            }
        }

        /// <summary>
        /// Changes the background color of buttons to indicate which tool is being currently used
        /// </summary>
        private void changeToolBackground(int i)
        {
            switch (i)
            {
                case 1:                             // Brush
                    brushButton.BackColor = Color.DarkGray;
                    eraserButton.BackColor = Color.DimGray;
                    shapeButton.BackColor = Color.DimGray;
                    fillButton.BackColor = Color.DimGray;
                    colorPickerButton.BackColor = Color.DimGray;
                    break;
                case 2:                             // Eraser
                    brushButton.BackColor = Color.DimGray;
                    eraserButton.BackColor = Color.DarkGray;
                    shapeButton.BackColor = Color.DimGray;
                    fillButton.BackColor = Color.DimGray;
                    colorPickerButton.BackColor = Color.DimGray;
                    break;
                case 3:                             // Shape
                    brushButton.BackColor = Color.DimGray;
                    eraserButton.BackColor = Color.DimGray;
                    shapeButton.BackColor = Color.DarkGray;
                    fillButton.BackColor = Color.DimGray;
                    colorPickerButton.BackColor = Color.DimGray;
                    break;
                case 4:                             // Fill
                    brushButton.BackColor = Color.DimGray;
                    eraserButton.BackColor = Color.DimGray;
                    shapeButton.BackColor = Color.DimGray;
                    fillButton.BackColor = Color.DarkGray;
                    colorPickerButton.BackColor = Color.DimGray;
                    break;
                case 5:                             // Color Picker
                    brushButton.BackColor = Color.DimGray;
                    eraserButton.BackColor = Color.DimGray;
                    shapeButton.BackColor = Color.DimGray;
                    fillButton.BackColor = Color.DimGray;
                    colorPickerButton.BackColor = Color.DarkGray;
                    break;
            }
        }
    }
}
