using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


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
        private Bitmap cursorBMP;
        private Changes changes;
        private PixelForgeryTool tool;
        private BrushTool brushTool = new BrushTool();
        private EraserTool eraserTool = new EraserTool();
        private ShapeTool shapeTool = new ShapeTool();
        private ColorPickerTool colorPickerTool = new ColorPickerTool();
        private TextTool textTool = new TextTool();
        private FillTool fillTool = new FillTool();
        private List<Point> points = new List<Point>();
        private int scaleFactor = 15;
        private float constant = 1.7f;

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
            cursorBMP = new Bitmap(100, 100);
            pictureBox.Image = BMP;
            pictureBox.BackColor = Color.White;
            colorChangeButton.BackColor = Color.Black;
            tool = brushTool;
            ChangeToolBackground(1);
            ChangeCursorSize(5);

            zoomInButton.Visible = false;
            zoomOutButton.Visible = false;

            using (Graphics g = Graphics.FromImage(BMP))
            {
                Rectangle bg = new Rectangle(0, 0, BMP.Width, BMP.Height);
                g.FillRectangle(Brushes.White, bg);
            }
            changes.AddChange(pictureBox);
        }

        /// <summary>
        /// Creates a new canvas for the user to draw in, defaults to 1280x720 pixels in size.
        /// <list type="bullet">
        /// <item>Date: 4/16/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the newButton object</param>
        /// <param name="e">An EventListener checking for when the Button is clicked</param>
        private void NewButton_Click(object sender, EventArgs e)                // New Button
        {
            BMP = new Bitmap(1280, 720);
            using (Graphics g = Graphics.FromImage(BMP))
            {
                Rectangle bg = new Rectangle(0, 0, BMP.Width, BMP.Height);
                g.FillRectangle(Brushes.White, bg);
            }
            pictureBox.Size = BMP.Size;
            pictureBox.Image = BMP;
            changes.ClearStacks();
            changes.AddChange(pictureBox);
            BMP = (Bitmap)pictureBox.Image;
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
            BMP = (Bitmap)pictureBox.Image;
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
            BMP = fd.OpenFile(BMP);

            pictureBox.Width = BMP.Width;
            pictureBox.Height = BMP.Height;
            pictureBox.Image = BMP;
            pictureBox.Refresh();

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
                using (ImagePropertiesForm iForm = new ImagePropertiesForm())
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
            BMP = (Bitmap)pictureBox.Image;
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
            BMP = (Bitmap)pictureBox.Image;
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
            ChangeCursorSize((int)brushTool.BrushWidth);
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
            ChangeCursorSize((int)eraserTool.EraserWidth);
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
            ChangeCursorSize((int)brushTool.BrushWidth);
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
            ChangeCursorSize((int)eraserTool.EraserWidth);
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
            pictureBox.Cursor = Cursors.Cross;
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
            pictureBox.Cursor = Cursors.Cross;
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
            pictureBox.Cursor = Cursors.Cross;
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
            pictureBox.Cursor = Cursors.Cross;
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
            pictureBox.Cursor = Cursors.Cross;
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
                    if (tool == fillTool)
                        tool.UseTool(e, pictureBox);

                    if (tool == shapeTool && points.Count > 2)
                    {
                        tool.Points(points);
                        tool.UseTool(e, pictureBox);
                    }
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
                    if (points.Count > 1 && tool == shapeTool)
                    {
                        tool.Points(points);
                        tool.UseTool(e, pictureBox);
                    }
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
            if (tool == colorPickerTool)
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
                        if (tool == brushTool || tool == eraserTool)
                            tool.UseTool(e, pictureBox);
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

                    if (tool == shapeTool)
                    {
                        tool.UseTool(e, pictureBox);
                        points.Clear();
                    }

                    if (tool == textTool)
                    {
                        tool.UseTool(e, pictureBox);
                    }

                    changes.AddChange(pictureBox);
                    BMP = (Bitmap)pictureBox.Image;
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
                BMP = fd.OpenFile(BMP);

                pictureBox.Width = BMP.Width;
                pictureBox.Height = BMP.Height;
                pictureBox.Image = BMP;
                pictureBox.Refresh();

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

            BMP = (Bitmap)pictureBox.Image;
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
            if (tool.isDrawing && tool == shapeTool)
            {
                tool.DrawOutline(e);
            }

            if (tool.isDrawing && tool == textTool)
                tool.DrawOutline(e);
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
                    brushButton.BackColor = Color.White;
                    eraserButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    shapeButton.BackColor = Color.FromArgb(255, 255, 192, 128); ;
                    fillButton.BackColor = Color.FromArgb(255, 255, 192, 128); ;
                    colorPickerButton.BackColor = Color.FromArgb(255, 255, 192, 128); ;
                    TextBoxButton.BackColor = Color.FromArgb(255, 255, 192, 128); ;
                    break;
                case 2:                             // Eraser
                    brushButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    eraserButton.BackColor = Color.White;
                    shapeButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    fillButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    colorPickerButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    TextBoxButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    break;
                case 3:                             // Shape
                    brushButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    eraserButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    shapeButton.BackColor = Color.White;
                    fillButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    colorPickerButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    TextBoxButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    break;
                case 4:                             // Fill
                    brushButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    eraserButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    shapeButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    fillButton.BackColor = Color.White;
                    colorPickerButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    TextBoxButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    break;
                case 5:                             // Color Picker
                    brushButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    eraserButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    shapeButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    fillButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    colorPickerButton.BackColor = Color.White;
                    TextBoxButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                    break;
                case 6:                             // Text Box Button
                    brushButton.BackColor = Color.FromArgb(255, 255, 192, 128);;
                    eraserButton.BackColor = Color.FromArgb(255, 255, 192, 128);;
                    shapeButton.BackColor = Color.FromArgb(255, 255, 192, 128);;
                    fillButton.BackColor = Color.FromArgb(255, 255, 192, 128);;
                    colorPickerButton.BackColor = Color.FromArgb(255, 255, 192, 128);;
                    TextBoxButton.BackColor = Color.White;
                    break;
            }
        }

        /// <summary>
        /// Changes the current tool to the Text Tool
        /// <list type="bullet">
        /// <item>Date: 5/1/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the pictureBox object.</param>
        /// <param name="e">An EventListener checking for when the Button is clicked.</param>
        private void TextBoxButton_Click(object sender, EventArgs e)
        {
            tool = textTool;
            ChangeToolBackground(6);
            pictureBox.Cursor = Cursors.Cross;
            textBoxFontSizeTextBox.Text = textTool.FontSize.ToString();
        }

        /// <summary>
        /// Changes the size of the pictureBox cursor.
        /// <list type="bullet">
        /// <item>Date: 5/1/23</item>
        /// <item>Programmer(s): Justin Reyes</item>
        /// </list>
        /// </summary>
        /// <param name="size">Integer value containing the diameter of the cursor</param>
        /// <param name="c">Color of the cursor</param>
        private void ChangeCursorSize(int size)
        {
            // If size is an odd number, turn it to an even number
            if (size % 2 == 1) size++;

            cursorBMP = new Bitmap(size + 20, size + 20);
            using (Graphics g = Graphics.FromImage(cursorBMP))
            {
                int centerPoint = cursorBMP.Width / 2;

                // Draw Circle
                Rectangle r = new Rectangle(centerPoint - size / 2, centerPoint - size / 2, size, size);
                Color c = Color.FromArgb(255, 255, 255, 255);
                Pen p = new Pen(c, 1);
                g.DrawEllipse(p, r);

                c = Color.FromArgb(255, 0, 0, 0);
                size += 2;
                p.Color = c;
                r = new Rectangle(centerPoint - size / 2, centerPoint - size / 2, size, size);
                g.DrawEllipse(p, r);

                // Draw middle cross
                for (int i = 0; i < 20; i += 2)
                {
                    g.DrawLine(p, centerPoint, centerPoint - i, centerPoint, centerPoint - i - 2);
                    g.DrawLine(p, centerPoint, centerPoint + i, centerPoint, centerPoint + i + 2);
                    g.DrawLine(p, centerPoint - i, centerPoint, centerPoint - i - 2, centerPoint);
                    g.DrawLine(p, centerPoint + i, centerPoint, centerPoint + i + 2, centerPoint);
                    c = Color.FromArgb(255, 255 - c.R, 255 - c.G, 255 - c.B);
                    p.Color = c;
                }            

                cursorBMP.MakeTransparent();

                pictureBox.Cursor = new Cursor(cursorBMP.GetHicon());
                pictureBox.Cursor.Draw(g, r);
            }
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            pictureBox.Height += Convert.ToInt32(scaleFactor / constant);
            pictureBox.Width += scaleFactor;

            //pictureBox.Top = (int)(pictureBox.Top - (pictureBox.Height * 0.025));
            //pictureBox.Left = (int)(pictureBox.Left - (pictureBox.Width * 0.025));
            //pictureBox.Height = (int)(pictureBox.Height + (pictureBox.Height * 0.05));
            //pictureBox.Width = (int)(pictureBox.Width + (pictureBox.Width * 0.05));
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            pictureBox.Height -= Convert.ToInt32(scaleFactor / constant);
            pictureBox.Width -= scaleFactor;

            //pictureBox.Top = (int)(pictureBox.Top + (pictureBox.Height * 0.025));
            //pictureBox.Left = (int)(pictureBox.Left + (pictureBox.Width * 0.025));
            //pictureBox.Height = (int)(pictureBox.Height - (pictureBox.Height * 0.05));
            //pictureBox.Width = (int)(pictureBox.Width - (pictureBox.Width * 0.05));
        }

        /// <summary>
        /// Processes font size changes for the text tool. If an invalid value is entered,
        /// the default font size of 10 pt is used.
        /// <list type="bullet">
        /// <item>Date: 5/1/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the pictureBox object.</param>
        /// <param name="e">An EventListener checking for when the text box value is changed.</param>
        private void textBoxFontSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            string s = textBoxFontSizeTextBox.Text;

            if (float.TryParse(s, out float width) && width > 0)
                textTool.FontSize = width;
            else
                textTool.FontSize = 10;
        }

        /// <summary>
        /// Processes text changes for the text tool. This is the string that will be drawn 
        /// when using the text tool. If an invalid value is entered, the value is set to an empty string
        /// <list type="bullet">
        /// <item>Date: 5/1/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the pictureBox object.</param>
        /// <param name="e">An EventListener checking for when the text box value is changed.</param>
        private void textBoxStringTextBox_TextChanged(object sender, EventArgs e)
        {
            string s = textBoxStringTextBox.Text;
            if (s.Length > 0)
                textTool.StringToPrint = s;
            else
                textTool.StringToPrint = "";
        }

        /// <summary>
        /// Clears the font size text box when clicking inside the text box.
        /// <list type="bullet">
        /// <item>Date: 5/1/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the pictureBox object.</param>
        /// <param name="e">An EventListener checking for when the text box is clicked.</param>
        private void textBoxFontSizeTextBox_Click(object sender, EventArgs e)
        {
            textBoxFontSizeTextBox.Clear();
        }

        /// <summary>
        /// Clears the value for the text box when clicking inside the text box.
        /// <list type="bullet">
        /// <item>Date: 5/1/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        /// <param name="sender">References the pictureBox object.</param>
        /// <param name="e">An EventListener checking for when the text box is clicked.</param>
        private void textBoxStringTextBox_Click(object sender, EventArgs e)
        {
            textBoxStringTextBox.Clear();
        }
    }
}
