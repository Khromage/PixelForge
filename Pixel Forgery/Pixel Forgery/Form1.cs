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
    /// <summary>
    /// Date: 2/26/23
    /// Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally, Lilianna Rosales
    /// GUI class which loads the essential tools for the software.
    /// Contains EventListeners for MouseEvents and KeyboardEvents.
    /// </summary>
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

        /// <summary>
        /// Date: 2/26/23
        /// Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally, Lilianna Rosales
        /// Constructor for the PixelForgeryGUI class.
        /// Initializes all the graphical objects in the GUI.
        /// Sets the canvas to a white background and the tool to the brush tool by default.
        /// </summary>
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

        /// <summary>
        /// Date: 4/16/23
        /// Programmer(s): Justin Reyes
        /// Creates a new canvas for the user to draw in, defaults to 918x595 pixels in size.
        /// </summary>
        /// <param name="sender">References the newButton object</param>
        /// <param name="e">An EventListener checking for when the Button is clicked</param>
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
        /// Date: 3/29/23
        /// Programmer(s): Justin Reyes
        /// Opens a save file dialog to let the user save the image.
        /// </summary>
        /// <param name="sender">References the saveButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void saveButton_Click(object sender, EventArgs e)               // Save File Button
        {
            FileExplorerDialog fd = new FileExplorerDialog();
            fd.saveFile(this.pictureBox);
            changes.clearStacks();
            changes.addChange(pictureBox);
        }

        /// <summary>
        /// Date: 3/29/23
        /// Programmer(s): Justin Reyes
        /// Opens an open file dialog to let the user open an image.
        /// </summary>
        /// <param name="sender">References the openButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void openButton_Click(object sender, EventArgs e)               // Open File Button
        {   
            FileExplorerDialog fd = new FileExplorerDialog();
            fd.loadFile(this.pictureBox);
            BMP = (Bitmap)pictureBox.Image;
            changes.clearStacks();
            changes.addChange(pictureBox);
        }

        /// <summary>
        /// Date: 4/16/23
        /// Programmer(s): Justin Reyes
        /// Opens a form that allows the user to set canvas dimensions.
        /// </summary>
        /// <param name="sender">References the imagePropertiesButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void imagePropertiesButton_Click(object sender, EventArgs e)    // Image Properties Button
        {
            try
            {
                using(ImagePropertiesForm iForm = new ImagePropertiesForm())
                {
                    bool changeSize = false;
                    int newWidth = pictureBox.Width, newHeight = pictureBox.Height;

                    iForm.Owner = this;
                    iForm.StartPosition = FormStartPosition.CenterParent;
                    iForm.ShowInTaskbar = false;
                    iForm.canvasWidth = pictureBox.Width;
                    iForm.canvasHeight = pictureBox.Height;
                    iForm.ShowDialog();

                    changeSize = iForm.changeSize;
                    newWidth = iForm.canvasWidth;
                    newHeight = iForm.canvasHeight;

                    if (changeSize)
                    {
                        System.Drawing.Image curr = (System.Drawing.Image)pictureBox.Image.Clone();
                        BMP = new Bitmap(newWidth, newHeight);
                        Graphics g = Graphics.FromImage(BMP);
                        g.FillRectangle(Brushes.White, new Rectangle(0, 0, BMP.Width, BMP.Height));
                        g.DrawImage(curr, 0, 0);

                        pictureBox.Image = BMP;
                        pictureBox.Size = BMP.Size;
                        pictureBox.Invalidate();
                        changes.addChange(pictureBox);
                    }

                    pictureBox.Refresh();
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        /// <summary>
        /// Date: 4/01/23
        /// Programmer(s): Justin Reyes
        /// Reverts the image to its previous state.
        /// </summary>
        /// <param name="sender">References the undoButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void undoButton_Click(object sender, EventArgs e)               // Undo Changes Button
        {
            changes.undoChange(pictureBox);
        }

        /// <summary>
        /// Date: 4/01/23
        /// Programmer(s): Justin Reyes
        /// Reverts an undone change
        /// </summary>
        /// <param name="sender">References the redoButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void redoButton_Click(object sender, EventArgs e)               // Redo Changes Button
        {
            changes.redoChange(pictureBox);
        }

        /// <summary>
        /// Date: 3/13/23
        /// Programmer(s): Gregory Khrom-Abramyan, Justin Reyes
        /// Changes the tool to the brush tool
        /// </summary>
        /// <param name="sender">References the brushButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void brushButton_Click(object sender, EventArgs e)              // Brush Tool Button
        {
            tool = brushTool;
            changeToolBackground(1);
        }

        /// <summary>
        /// Date: 3/13/23
        /// Programmer(s): Gregory Khrom-Abramyan, Justin Reyes
        /// Changes the tool to the eraser tool
        /// </summary>
        /// <param name="sender">References the eraserButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void eraserButton_Click(object sender, EventArgs e)             // Eraser Tool Button
        {
            tool = eraserTool;
            changeToolBackground(2);
        }

        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Lilianna Rosales
        /// Populates the text box with the brush width
        /// </summary>
        /// <param name="sender">References the brushSizeToolStripMenuItem object.</param>
        /// <param name="e">An EventListener checking for when the MenuItem is hovered over.</param>
        private void brushSizeToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            brushSizeTextBox.Text = brushTool.BrushWidth.ToString();
        }

        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Lilianna Rosales
        /// Populates the text box with the eraser width
        /// </summary>
        /// <param name="sender">References the eraserSizeToolStripMenuItem object.</param>
        /// <param name="e">An EventListener checking for when the MenuItem is hovered over.</param>
        private void eraserSizeToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            eraserSizeTextBox.Text = eraserTool.EraserWidth.ToString();
        }

        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Lilianna Rosales
        /// Populates the text box with the eraser width
        /// Processes brush size changes. If an invalid value is input the brush size is
        /// set back to the default size of 5
        /// </summary>
        /// <param name="sender">References the brushSizeTextBox object.</param>
        /// <param name="e">An EventListener checking for when the TextBox is changed.</param>
        private void brushSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            string s = brushSizeTextBox.Text;

            if (float.TryParse(s, out float width) && width > 0)
                brushTool.BrushWidth = width;
            else
                brushTool.BrushWidth = 5;
        }

        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Lilianna Rosales
        /// Processes eraser size changes. If an invalid value is input the eraser size is
        /// set back to the default size of 20
        /// </summary>
        /// <param name="sender">References the eraserSizeTextBox object.</param>
        /// <param name="e">An EventListener checking for when the TextBox is changed.</param>
        private void eraserSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            string s = eraserSizeTextBox.Text;

            if (float.TryParse(s, out float width) && width > 0)
                eraserTool.EraserWidth = width;
            else
                eraserTool.EraserWidth = 20;
        }

        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Lilianna Rosales
        /// Clears the brush-size text box when the user clicks inside the text box
        /// </summary>
        /// <param name="sender">References the brushSizeTextBox object.</param>
        /// <param name="e">An EventListener checking for when the TextBox is clicked.</param>
        private void brushSizeTextBox_Click(object sender, EventArgs e)
        {
            brushSizeTextBox.Clear();
        }

        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Lilianna Rosales
        /// Clears the eraser-size text box when the user clicks inside the text box
        /// </summary>
        /// <param name="sender">References the eraserSizeTextBox object.</param>
        /// <param name="e">An EventListener checking for when the TextBox is clicked.</param>
        private void eraserSizeTextBox_Click(object sender, EventArgs e)
        {
            eraserSizeTextBox.Clear();
        }

        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Taylor Nastally
        /// Changes the tool to the shape tool.
        /// Changes the type of shape tool to 1 (Rectangle).
        /// </summary>
        /// <param name="sender">References the rectangleToolMenuItem object.</param>
        /// <param name="e">An EventListener checking for when the MenuItem is clicked.</param>
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = shapeTool;
            tool.typeOfTool = 1;
            changeToolBackground(3);
        }

        /// <summary>
        /// Date: 4/14/23
        /// Programmer(s): Taylor Nastally
        /// Changes the tool to the shape tool.
        /// Changes the type of shape tool to 2 (Ellipse).
        /// </summary>
        /// <param name="sender">References the ellipseToolMenuItem object.</param>
        /// <param name="e">An EventListener checking for when the MenuItem is clicked.</param>
        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = shapeTool;
            tool.typeOfTool = 2;
            changeToolBackground(3);
        }

        /// <summary>
        /// Date: 4/14/23
        /// Programmer(s): Taylor Nastally
        /// Changes the tool to the shape tool.
        /// Changes the type of shape tool to 3 (Polygon).
        /// </summary>
        /// <param name="sender">References the polygonToolMenuItem object.</param>
        /// <param name="e">An EventListener checking for when the MenuItem is clicked.</param>
        private void polygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = shapeTool;
            tool.typeOfTool = 3;
            changeToolBackground(3);
        }

        /// <summary>
        /// Date: 4/10/23
        /// Programmer(s): Justin Reyes
        /// Changes the tool to the fill tool.
        /// </summary>
        /// <param name="sender">References the fillButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void fillButton_Click(object sender, EventArgs e)
        {
            tool = fillTool;
            changeToolBackground(4);
        }

        /// <summary>
        /// Date: 4/05/23
        /// Programmer(s): Gregory Khrom-Abramyan
        /// Opens the color selection dialog and when pressing "ok", applies the selected color to all tools.
        /// </summary>
        /// <param name="sender">References the colorTool object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
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

        /// <summary>
        /// Date: 4/16/23
        /// Programmer(s): Gregory Khrom-Abramyan
        /// Changes the tool to the color picker tool and updates the hovered color preview.
        /// </summary>
        /// <param name="sender">References the colorPickerButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void colorPickerButton_Click(object sender, EventArgs e)
        {

            tool = colorPickerTool;
            pickedcolordisplay.BackColor = tool.pickedColor;
            changeToolBackground(5);
        }

        /// <summary>
        /// Date: 3/08/23
        /// Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally
        /// Draws on the canvas using the currently selected tool.
        /// If the current tool is the color picker, the hovered color is applied to all tools.
        /// </summary>
        /// <param name="sender">References the pictureBox object.</param>
        /// <param name="e">An EventListener checking for when the pictureBox is clicked.</param>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    tool.isDrawing = true;
                    tool.startX = e.X;
                    tool.startY = e.Y;
                    if (tool == fillTool) tool.UseTool(e, pictureBox);
                    if (tool == shapeTool && tool.typeOfTool == 3) tool.points(points);
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

        /// <summary>
        /// Date: 3/08/23
        /// Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally
        /// If a drawing tool is in use, continues to draw and updates the mous position.
        /// If the color picker tool is in use, update the hovered color and apply the color to the color picker preview.
        /// </summary>
        /// <param name="sender">References the pictureBox object.</param>
        /// <param name="e">An EventListener checking for when the pictureBox is clicked.</param>
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
                        if (tool == brushTool || tool == eraserTool) tool.UseTool(e, pictureBox);
                    }
                    break;
                case MouseButtons.Right:
                    break;
                default:
                    break;
            }
            pictureBox.Refresh();
        }

        /// <summary>
        /// Date: 3/08/23
        /// Programmer(s): Justin Reyes, Taylor Nastally
        /// If a drawing tool is in use, stops drawing.
        /// If a shape tool is in use, applies the draw shape to changes.
        /// If the color picker tool is in use, update the hovered color and apply the color to the color picker preview.
        /// </summary>
        /// <param name="sender">References the pictureBox object.</param>
        /// <param name="e">An EventListener checking for when the pictureBox is clicked.</param>
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    tool.isDrawing = false;
                    tool.endX = e.X;
                    tool.endY = e.Y;
                    if (tool == shapeTool) tool.UseTool(e, pictureBox);
                    changes.addChange(pictureBox);
                    break;
                case MouseButtons.Right:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Date: 4/01/23
        /// Programmer(s): Justin Reyes
        /// Checks for user inputted keyboard commands to save and open files and to undo or redo changes..
        /// </summary>
        /// <param name="sender">References the PixelForgeryGUI object.</param>
        /// <param name="e">An EventListener checking for when a key is pressed.</param>
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
        /// Date: 4/11/23
        /// Programmer(s): Justin Reyes, Taylor Nastally
        /// Temporarily updates the canvas.
        /// Actively shows what the shape being drawn looks like.
        /// </summary>
        /// <param name="sender">References the pictureBox object.</param>
        /// <param name="e">An EventListener checking for the Paint event.</param>
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if(tool.isDrawing && tool == shapeTool)
            {
                tool.drawOutline(e);
            }
        }

        /// <summary>
        /// Date: 4/16/23
        /// Programmer(s): Justin Reyes
        /// Changes the background color of buttons to indicate which tool is being currently used
        /// </summary>
        /// <param name="i">References which tool object is in use.</param>
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
