using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Pixel_Forgery
{
    /// <summary>
    /// GUI class containing all the graphical objects rendered in the form. Loads the essential tools for the software.
    /// Contains EventListeners for MouseEvents and KeyboardEvents.
    /// <list type="bullet">
    /// <item>Date: 2/26/23</item>
    /// <item>Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally, Lilianna Rosales</item>
    /// </list>
    /// </summary>
    partial class PixelForgeryGUI
    {
        /// <summary>
        /// Required designer variable.
        /// <list type="bullet">
        /// <item>Date: 2/26/23</item>
        /// <item>Programmer(s): None (Built-in to WinForm)</item>
        /// </list>
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// <list type="bullet">
        /// <item>Date: 2/26/23</item>
        /// <item>Programmer(s): None (Built-in to WinForm)</item>
        /// </list>
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Date: 2/26/23
        /// Programmer(s): Justin Reyes, Gregory Khrom-Abramyan, Taylor Nastally, Lilianna Rosales
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PixelForgeryGUI));
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.newButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openButton = new System.Windows.Forms.ToolStripMenuItem();
            this.fileButtonSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.imagePropertiesButton = new System.Windows.Forms.ToolStripMenuItem();
            this.editButton = new System.Windows.Forms.ToolStripMenuItem();
            this.undoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.redoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.brushButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brushSizeTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.eraserButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.changeSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eraserSizeTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.shapeButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillButton = new System.Windows.Forms.ToolStripButton();
            this.TextBoxButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.colorChangeButton = new System.Windows.Forms.ToolStripButton();
            this.colorPickerButton = new System.Windows.Forms.ToolStripButton();
            this.pickedcolordisplay = new System.Windows.Forms.ToolStripLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.zoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.zoomInButton = new System.Windows.Forms.ToolStripButton();
            this.menuBar.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileButton,
            this.editButton});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuBar.Size = new System.Drawing.Size(1334, 25);
            this.menuBar.TabIndex = 3;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileButton
            // 
            this.fileButton.AutoSize = false;
            this.fileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.saveButton,
            this.openButton,
            this.fileButtonSeparator,
            this.imagePropertiesButton});
            this.fileButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(42, 21);
            this.fileButton.Text = "File";
            // 
            // newButton
            // 
            this.newButton.Name = "newButton";
            this.newButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newButton.Size = new System.Drawing.Size(220, 22);
            this.newButton.Text = "New";
            this.newButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Name = "saveButton";
            this.saveButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveButton.Size = new System.Drawing.Size(220, 22);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // openButton
            // 
            this.openButton.Name = "openButton";
            this.openButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openButton.Size = new System.Drawing.Size(220, 22);
            this.openButton.Text = "Open";
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // fileButtonSeparator
            // 
            this.fileButtonSeparator.Name = "fileButtonSeparator";
            this.fileButtonSeparator.Size = new System.Drawing.Size(217, 6);
            // 
            // imagePropertiesButton
            // 
            this.imagePropertiesButton.Name = "imagePropertiesButton";
            this.imagePropertiesButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.imagePropertiesButton.Size = new System.Drawing.Size(220, 22);
            this.imagePropertiesButton.Text = "Image Properties";
            this.imagePropertiesButton.Click += new System.EventHandler(this.ImagePropertiesButton_Click);
            // 
            // editButton
            // 
            this.editButton.AutoSize = false;
            this.editButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoButton,
            this.redoButton});
            this.editButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(42, 21);
            this.editButton.Text = "Edit";
            // 
            // undoButton
            // 
            this.undoButton.Name = "undoButton";
            this.undoButton.ShortcutKeyDisplayString = "";
            this.undoButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoButton.Size = new System.Drawing.Size(152, 22);
            this.undoButton.Text = "Undo";
            this.undoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.Name = "redoButton";
            this.redoButton.ShortcutKeyDisplayString = "";
            this.redoButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoButton.Size = new System.Drawing.Size(152, 22);
            this.redoButton.Text = "Redo";
            this.redoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // toolBar
            // 
            this.toolBar.AllowItemReorder = true;
            this.toolBar.AutoSize = false;
            this.toolBar.BackColor = System.Drawing.Color.DimGray;
            this.toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brushButton,
            this.eraserButton,
            this.shapeButton,
            this.fillButton,
            this.TextBoxButton,
            this.colorChangeButton,
            this.colorPickerButton,
            this.pickedcolordisplay,
            this.zoomInButton,
            this.zoomOutButton});
            this.toolBar.Location = new System.Drawing.Point(0, 25);
            this.toolBar.Name = "toolBar";
            this.toolBar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolBar.Size = new System.Drawing.Size(1334, 50);
            this.toolBar.TabIndex = 4;
            this.toolBar.Text = "toolStrip1";
            // 
            // brushButton
            // 
            this.brushButton.AutoSize = false;
            this.brushButton.BackColor = System.Drawing.Color.DimGray;
            this.brushButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.brushButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.brushButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeToolStripMenuItem});
            this.brushButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.brushButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.brushButton.Image = ((System.Drawing.Image)(resources.GetObject("brushButton.Image")));
            this.brushButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.brushButton.Margin = new System.Windows.Forms.Padding(0);
            this.brushButton.Name = "brushButton";
            this.brushButton.Size = new System.Drawing.Size(60, 50);
            this.brushButton.Text = "Brush Tool";
            this.brushButton.ToolTipText = "Brush";
            this.brushButton.Click += new System.EventHandler(this.BrushButton_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brushSizeTextBox});
            this.sizeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.sizeToolStripMenuItem.Text = "Change Size";
            this.sizeToolStripMenuItem.MouseHover += new System.EventHandler(this.BrushSizeToolStripMenuItem_MouseHover);
            // 
            // brushSizeTextBox
            // 
            this.brushSizeTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.brushSizeTextBox.Name = "brushSizeTextBox";
            this.brushSizeTextBox.Size = new System.Drawing.Size(100, 23);
            this.brushSizeTextBox.Click += new System.EventHandler(this.BrushSizeTextBox_Click);
            this.brushSizeTextBox.TextChanged += new System.EventHandler(this.BrushSizeTextBox_TextChanged);
            // 
            // eraserButton
            // 
            this.eraserButton.AutoSize = false;
            this.eraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eraserButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeSizeToolStripMenuItem});
            this.eraserButton.Image = ((System.Drawing.Image)(resources.GetObject("eraserButton.Image")));
            this.eraserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eraserButton.Name = "eraserButton";
            this.eraserButton.Size = new System.Drawing.Size(60, 50);
            this.eraserButton.Text = "Eraser Tool";
            this.eraserButton.ToolTipText = "Eraser";
            this.eraserButton.Click += new System.EventHandler(this.EraserButton_Click);
            // 
            // changeSizeToolStripMenuItem
            // 
            this.changeSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eraserSizeTextBox});
            this.changeSizeToolStripMenuItem.Name = "changeSizeToolStripMenuItem";
            this.changeSizeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.changeSizeToolStripMenuItem.Text = "Change Size";
            this.changeSizeToolStripMenuItem.MouseHover += new System.EventHandler(this.EraserSizeToolStripMenuItem_MouseHover);
            // 
            // eraserSizeTextBox
            // 
            this.eraserSizeTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.eraserSizeTextBox.Name = "eraserSizeTextBox";
            this.eraserSizeTextBox.Size = new System.Drawing.Size(100, 23);
            this.eraserSizeTextBox.Click += new System.EventHandler(this.EraserSizeTextBox_Click);
            this.eraserSizeTextBox.TextChanged += new System.EventHandler(this.EraserSizeTextBox_TextChanged);
            // 
            // shapeButton
            // 
            this.shapeButton.AutoSize = false;
            this.shapeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.shapeButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.polygonToolStripMenuItem});
            this.shapeButton.Image = ((System.Drawing.Image)(resources.GetObject("shapeButton.Image")));
            this.shapeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.shapeButton.Name = "shapeButton";
            this.shapeButton.Size = new System.Drawing.Size(60, 50);
            this.shapeButton.Text = "Shape Tool";
            this.shapeButton.ToolTipText = "Shape";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Image = global::Pixel_Forgery.Properties.Resources.rectangle;
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.RectangleToolStripMenuItem_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.Image = global::Pixel_Forgery.Properties.Resources.ellipse;
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ellipseToolStripMenuItem.Text = "Ellipse";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.EllipseToolStripMenuItem_Click);
            // 
            // polygonToolStripMenuItem
            // 
            this.polygonToolStripMenuItem.Image = global::Pixel_Forgery.Properties.Resources.hexagon;
            this.polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            this.polygonToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.polygonToolStripMenuItem.Text = "Polygon";
            this.polygonToolStripMenuItem.Click += new System.EventHandler(this.PolygonToolStripMenuItem_Click);
            // 
            // fillButton
            // 
            this.fillButton.AutoSize = false;
            this.fillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fillButton.Image = ((System.Drawing.Image)(resources.GetObject("fillButton.Image")));
            this.fillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(60, 50);
            this.fillButton.Text = "toolStripButton2";
            this.fillButton.ToolTipText = "Fill";
            this.fillButton.Click += new System.EventHandler(this.FillButton_Click);
            // 
            // TextBoxButton
            // 
            this.TextBoxButton.AutoSize = false;
            this.TextBoxButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TextBoxButton.Image = ((System.Drawing.Image)(resources.GetObject("TextBoxButton.Image")));
            this.TextBoxButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TextBoxButton.Name = "TextBoxButton";
            this.TextBoxButton.Size = new System.Drawing.Size(60, 50);
            this.TextBoxButton.Text = "TextBoxButton";
            this.TextBoxButton.Click += new System.EventHandler(this.TextBoxButton_Click);
            // 
            // colorChangeButton
            // 
            this.colorChangeButton.AutoSize = false;
            this.colorChangeButton.BackColor = System.Drawing.Color.Black;
            this.colorChangeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.colorChangeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.colorChangeButton.Image = ((System.Drawing.Image)(resources.GetObject("colorChangeButton.Image")));
            this.colorChangeButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.colorChangeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorChangeButton.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.colorChangeButton.Name = "colorChangeButton";
            this.colorChangeButton.Size = new System.Drawing.Size(25, 25);
            this.colorChangeButton.Click += new System.EventHandler(this.ColorTool_Click);
            // 
            // colorPickerButton
            // 
            this.colorPickerButton.AutoSize = false;
            this.colorPickerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.colorPickerButton.Image = ((System.Drawing.Image)(resources.GetObject("colorPickerButton.Image")));
            this.colorPickerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.Size = new System.Drawing.Size(60, 50);
            this.colorPickerButton.Text = "Color Picker";
            this.colorPickerButton.ToolTipText = "Color Picker";
            this.colorPickerButton.Click += new System.EventHandler(this.ColorPickerButton_Click);
            // 
            // pickedcolordisplay
            // 
            this.pickedcolordisplay.ActiveLinkColor = System.Drawing.Color.White;
            this.pickedcolordisplay.AutoSize = false;
            this.pickedcolordisplay.BackColor = System.Drawing.Color.White;
            this.pickedcolordisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pickedcolordisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickedcolordisplay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickedcolordisplay.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.pickedcolordisplay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pickedcolordisplay.ImageTransparentColor = System.Drawing.Color.White;
            this.pickedcolordisplay.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.pickedcolordisplay.Name = "pickedcolordisplay";
            this.pickedcolordisplay.Size = new System.Drawing.Size(25, 25);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 75);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1334, 776);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.pictureBox);
            this.flowLayoutPanel1.SetFlowBreak(this.panel1, true);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(1323, 763);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Location = new System.Drawing.Point(20, 20);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1280, 720);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseUp);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.AutoSize = false;
            this.zoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutButton.Image")));
            this.zoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(47, 47);
            this.zoomOutButton.Text = "zoomOutButton";
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // zoomInButton
            // 
            this.zoomInButton.AutoSize = false;
            this.zoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomInButton.Image")));
            this.zoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(47, 47);
            this.zoomInButton.Text = "zoomInButton";
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // PixelForgeryGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1334, 851);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.menuBar);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuBar;
            this.MinimumSize = new System.Drawing.Size(1078, 713);
            this.Name = "PixelForgeryGUI";
            this.Text = "Pixel Forge";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PixelForgeryGUI_KeyDown);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileButton;
        private System.Windows.Forms.ToolStripMenuItem saveButton;
        private System.Windows.Forms.ToolStripMenuItem openButton;
        private System.Windows.Forms.ToolStripMenuItem editButton;
        private System.Windows.Forms.ToolStripMenuItem undoButton;
        private System.Windows.Forms.ToolStripMenuItem redoButton;
        private System.Windows.Forms.ToolStripMenuItem newButton;
        private System.Windows.Forms.ToolStripSeparator fileButtonSeparator;
        private System.Windows.Forms.ToolStripMenuItem imagePropertiesButton;

        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripDropDownButton brushButton;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox brushSizeTextBox;
        private System.Windows.Forms.ToolStripDropDownButton eraserButton;
        private System.Windows.Forms.ToolStripMenuItem changeSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox eraserSizeTextBox;
        private System.Windows.Forms.ToolStripDropDownButton shapeButton;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton fillButton;
        private System.Windows.Forms.ToolStripButton colorChangeButton;
        private System.Windows.Forms.ToolStripButton colorPickerButton;

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripLabel pickedcolordisplay;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripDropDownButton TextBoxButton;
        private System.Windows.Forms.ToolStripButton zoomInButton;
        private System.Windows.Forms.ToolStripButton zoomOutButton;
    }
}

