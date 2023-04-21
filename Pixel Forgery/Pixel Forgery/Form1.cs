using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Pixel_Forgery
{
    /// <summary>
    /// GUI class which loads the essential tools for the software.
    /// Contains EventListeners for MouseEvents and KeyboardEvents.
    /// <list type="bullet">
    /// <item>Date: 2/26/23</item>
    /// <item>Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally, Lilianna Rosales</item>
    /// </list> 
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
        /// Constructor for the PixelForgeryGUI class.
        /// Initializes all the graphical objects in the GUI.
        /// Sets the canvas to a white background and the tool to the brush tool by default.
        /// <list type="bullet">
        /// <item>Date: 2/26/23</item>
        /// <item>Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally, Lilianna Rosales</item>
        /// </list> 
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
            ChangeToolBackground(1);

            using (Graphics g = Graphics.FromImage(BMP))
            {
                Rectangle bg = new Rectangle(0, 0, BMP.Width, BMP.Height);
                g.FillRectangle(Brushes.White, bg);
            }
            changes.AddChange(pictureBox);

        }

        /// <summary>
        /// Creates a new canvas for the user to draw in, defaults to 918x595 pixels in size.
        /// <list type="bullet">
        /// <item>Date: 4/16/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the newButton object</param>
        /// <param name="e">An EventListener checking for when the Button is clicked</param>
        private void NewButton_Click(object sender, EventArgs e)                // New Button
        {
            BMP = new Bitmap(918, 595);
            using (Graphics g = Graphics.FromImage(BMP))
            {
                Rectangle bg = new Rectangle(0, 0, BMP.Width, BMP.Height);
                g.FillRectangle(Brushes.White, bg);
            }
            pictureBox.Size = BMP.Size;
            pictureBox.Image = BMP;
            changes.ClearStacks();
            changes.AddChange(pictureBox);
        }

        /// <summary>
        /// Opens a save file dialog to let the user save the image.
        /// <list type="bullet">
        /// <item>Date: 3/29/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the saveButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void SaveButton_Click(object sender, EventArgs e)               // Save File Button
        {
            FileExplorerDialog fd = new FileExplorerDialog();
            fd.SaveFile(this.pictureBox);
            changes.ClearStacks();
            changes.AddChange(pictureBox);
        }

        /// <summary>
        /// Opens an open file dialog to let the user open an image.
        /// <list type="bullet">
        /// <item>Date: 3/29/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the openButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void OpenButton_Click(object sender, EventArgs e)               // Open File Button
        {   
            FileExplorerDialog fd = new FileExplorerDialog();
            fd.OpenFile(this.pictureBox);
            BMP = (Bitmap)pictureBox.Image;
            changes.ClearStacks();
            changes.AddChange(pictureBox);
        }

        /// <summary>
        /// Opens a form that allows the user to set canvas dimensions.
        /// <list type="bullet">
        /// <item>Date: 4/16/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the imagePropertiesButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void ImagePropertiesButton_Click(object sender, EventArgs e)    // Image Properties Button
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
                        changes.AddChange(pictureBox);
                    }

                    pictureBox.Refresh();
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        /// <summary>
        /// Reverts the image to its previous state.
        /// <list type="bullet">
        /// <item>Date: 4/01/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the undoButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void UndoButton_Click(object sender, EventArgs e)               // Undo Changes Button
        {
            changes.UndoChange(pictureBox);
        }

        /// <summary>
        /// Reverts an undone change
        /// <list type="bullet">
        /// <item>Date: 4/01/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the redoButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void RedoButton_Click(object sender, EventArgs e)               // Redo Changes Button
        {
            changes.RedoChange(pictureBox);
        }

        /// <summary>
        /// Changes the tool to the brush tool
        /// <list type="bullet">
        /// <item>Date: 3/13/23</item>
        /// <item>Programmer(s): Gregory Khrom-Abramyan, Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the brushButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void BrushButton_Click(object sender, EventArgs e)              // Brush Tool Button
        {
            tool = brushTool;
            ChangeToolBackground(1);
        }

        /// <summary>
        /// Changes the tool to the eraser tool
        /// <list type="bullet">
        /// <item>Date: 3/13/23</item>
        /// <item>Programmer(s): Gregory Khrom-Abramyan, Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the eraserButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void EraserButton_Click(object sender, EventArgs e)             // Eraser Tool Button
        {
            tool = eraserTool;
            ChangeToolBackground(2);
        }

        /// <summary>
        /// Populates the text box with the brush width
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the brushSizeToolStripMenuItem object.</param>
        /// <param name="e">An EventListener checking for when the MenuItem is hovered over.</param>
        private void BrushSizeToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            brushSizeTextBox.Text = brushTool.BrushWidth.ToString();
        }

        /// <summary>
        /// Populates the text box with the eraser width
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the eraserSizeToolStripMenuItem object.</param>
        /// <param name="e">An EventListener checking for when the MenuItem is hovered over.</param>
        private void EraserSizeToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            eraserSizeTextBox.Text = eraserTool.EraserWidth.ToString();
        }

        /// <summary>
        /// Populates the text box with the eraser width.
        /// Processes brush size changes. If an invalid value is input the brush size is
        /// set back to the default size of 5.
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the brushSizeTextBox object.</param>
        /// <param name="e">An EventListener checking for when the TextBox is changed.</param>
        private void BrushSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            string s = brushSizeTextBox.Text;

            if (float.TryParse(s, out float width) && width > 0)
                brushTool.BrushWidth = width;
            else
                brushTool.BrushWidth = 5;
        }

        /// <summary>
        /// Processes eraser size changes. If an invalid value is input the eraser size is
        /// set back to the default size of 20.
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the eraserSizeTextBox object.</param>
        /// <param name="e">An EventListener checking for when the TextBox is changed.</param>
        private void EraserSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            string s = eraserSizeTextBox.Text;

            if (float.TryParse(s, out float width) && width > 0)
                eraserTool.EraserWidth = width;
            else
                eraserTool.EraserWidth = 20;
        }

        /// <summary>
        /// Clears the brush-size text box when the user clicks inside the text box.
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the brushSizeTextBox object.</param>
        /// <param name="e">An EventListener checking for when the TextBox is clicked.</param>
        private void BrushSizeTextBox_Click(object sender, EventArgs e)
        {
            brushSizeTextBox.Clear();
        }

        /// <summary>
        /// Clears the eraser-size text box when the user clicks inside the text box.
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the eraserSizeTextBox object.</param>
        /// <param name="e">An EventListener checking for when the TextBox is clicked.</param>
        private void EraserSizeTextBox_Click(object sender, EventArgs e)
        {
            eraserSizeTextBox.Clear();
        }

        /// <summary>
        /// Changes the tool to the shape tool.
        /// Changes the type of shape tool to 1 (Rectangle).
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Taylor Nastally</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the rectangleToolMenuItem object.</param>
        /// <param name="e">An EventListener checking for when the MenuItem is clicked.</param>
        private void RectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = shapeTool;
            tool.typeOfTool = 1;
            ChangeToolBackground(3);
        }

        /// <summary>
        /// Changes the tool to the shape tool.
        /// Changes the type of shape tool to 2 (Ellipse).
        /// <list type="bullet">
        /// <item>Date: 4/14/23</item>
        /// <item>Programmer(s): Taylor Nastally</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the ellipseToolMenuItem object.</param>
        /// <param name="e">An EventListener checking for when the MenuItem is clicked.</param>
        private void EllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = shapeTool;
            tool.typeOfTool = 2;
            ChangeToolBackground(3);
        }

        /// <summary>
        /// Changes the tool to the shape tool.
        /// Changes the type of shape tool to 3 (Polygon).
        /// <list type="bullet">
        /// <item>Date: 4/14/23</item>
        /// <item>Programmer(s): Taylor Nastally</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the polygonToolMenuItem object.</param>
        /// <param name="e">An EventListener checking for when the MenuItem is clicked.</param>
        private void PolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = shapeTool;
            tool.typeOfTool = 3;
            ChangeToolBackground(3);
        }

        /// <summary>
        /// Changes the tool to the fill tool.
        /// <list type="bullet">
        /// <item>Date: 4/10/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the fillButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void FillButton_Click(object sender, EventArgs e)
        {
            tool = fillTool;
            ChangeToolBackground(4);
        }

        /// <summary>
        /// Opens the color selection dialog and when pressing "ok", applies the selected color to all tools.
        /// <list type="bullet">
        /// <item>Date: 4/05/23</item>
        /// <item>Programmer(s): Gregory Khrom-Abramyan</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the colorTool object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void ColorTool_Click(object sender, EventArgs e)
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
        /// Changes the tool to the color picker tool and updates the hovered color preview.
        /// <list type="bullet">
        /// <item>Date: 4/16/23</item>
        /// <item>Programmer(s): Gregory Khrom-Abramyan</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the colorPickerButton object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void ColorPickerButton_Click(object sender, EventArgs e)
        {

            tool = colorPickerTool;
            pickedcolordisplay.BackColor = tool.pickedColor;
            ChangeToolBackground(5);
        }

        /// <summary>
        /// Draws on the canvas using the currently selected tool.
        /// If the current tool is the color picker, the hovered color is applied to all tools.
        /// <list type="bullet">
        /// <item>Date: 3/08/23</item>
        /// <item>Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the pictureBox object.</param>
        /// <param name="e">An EventListener checking for when the pictureBox is clicked.</param>
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    tool.isDrawing = true;
                    tool.startX = e.X;
                    tool.startY = e.Y;
                    if (tool == fillTool) tool.UseTool(e, pictureBox);
                    if (tool == shapeTool && tool.typeOfTool == 3) tool.Points(points);
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
        /// If a drawing tool is in use, continues to draw and updates the mous position.
        /// If the color picker tool is in use, update the hovered color and apply the color to the color picker preview.
        /// <list type="bullet">
        /// <item>Date: 3/08/23</item>
        /// <item>Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the pictureBox object.</param>
        /// <param name="e">An EventListener checking for when the pictureBox is clicked.</param>
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
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
        /// If a drawing tool is in use, stops drawing.
        /// If a shape tool is in use, applies the draw shape to changes.
        /// If the color picker tool is in use, update the hovered color and apply the color to the color picker preview.
        /// <list type="bullet">
        /// <item>Date: 3/08/23</item>
        /// <item>Programmer(s): Justin Reyes, Taylor Nastally</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the pictureBox object.</param>
        /// <param name="e">An EventListener checking for when the pictureBox is clicked.</param>
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    tool.isDrawing = false;
                    tool.endX = e.X;
                    tool.endY = e.Y;
                    if (tool == shapeTool) tool.UseTool(e, pictureBox);
                    changes.AddChange(pictureBox);
                    break;
                case MouseButtons.Right:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Checks for user inputted keyboard commands to save and open files and to undo or redo changes.
        /// <list type="bullet">
        /// <item>Date: 4/01/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
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
                changes.ClearStacks();
                changes.AddChange(pictureBox);
            }
            else if (e.KeyCode == Keys.S && (e.Control)) // Ctrl+S for Save
            {
                FileExplorerDialog fd = new FileExplorerDialog();
                fd.SaveFile(this.pictureBox);
                changes.ClearStacks();
                changes.AddChange(pictureBox);
            }
            else if (e.KeyCode == Keys.O && (e.Control)) // Ctrl+O for Open
            {
                FileExplorerDialog fd = new FileExplorerDialog();
                fd.OpenFile(this.pictureBox);
                changes.ClearStacks();
                changes.AddChange(pictureBox);
            }
            else if (e.KeyCode == Keys.Z && (e.Control)) // Ctrl+Z for Undo
            {
                changes.UndoChange(pictureBox);
            }
            else if (e.KeyCode == Keys.Y && (e.Control)) // Ctrl+Y for Redo
            {
                changes.RedoChange(pictureBox);
            }
        }

        /// <summary>
        /// Temporarily updates the canvas.
        /// Actively shows what the shape being drawn looks like.
        /// <list type="bullet">
        /// <item>Date: 4/11/23</item>
        /// <item>Programmer(s): Justin Reyes, Taylor Nastally</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the pictureBox object.</param>
        /// <param name="e">An EventListener checking for the Paint event.</param>
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if(tool.isDrawing && tool == shapeTool)
            {
                tool.DrawOutline(e);
            }
        }

        /// <summary>
        /// Changes the background color of buttons to indicate which tool is being currently used.
        /// <list type="bullet">
        /// <item>Date: 4/16/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="i">References which tool object is in use.</param>
        private void ChangeToolBackground(int i)
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
