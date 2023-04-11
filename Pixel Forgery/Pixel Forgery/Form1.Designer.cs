﻿using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Pixel_Forgery
{
    partial class PixelForgeryGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PixelForgeryGUI));
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openButton = new System.Windows.Forms.ToolStripMenuItem();
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
            this.shapeToolDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.fillButton = new System.Windows.Forms.ToolStripButton();
            this.menuBar.SuspendLayout();
            this.toolBar.SuspendLayout();
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
            this.menuBar.Size = new System.Drawing.Size(1103, 24);
            this.menuBar.TabIndex = 3;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileButton
            // 
            this.fileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton,
            this.openButton});
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(37, 20);
            this.fileButton.Text = "File";
            // 
            // saveButton
            // 
            this.saveButton.Name = "saveButton";
            this.saveButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveButton.Size = new System.Drawing.Size(146, 22);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openButton
            // 
            this.openButton.Name = "openButton";
            this.openButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openButton.Size = new System.Drawing.Size(146, 22);
            this.openButton.Text = "Open";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // editButton
            // 
            this.editButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoButton,
            this.redoButton});
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(39, 20);
            this.editButton.Text = "Edit";
            // 
            // undoButton
            // 
            this.undoButton.Name = "undoButton";
            this.undoButton.ShortcutKeyDisplayString = "";
            this.undoButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoButton.Size = new System.Drawing.Size(144, 22);
            this.undoButton.Text = "Undo";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.Name = "redoButton";
            this.redoButton.ShortcutKeyDisplayString = "";
            this.redoButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoButton.Size = new System.Drawing.Size(144, 22);
            this.redoButton.Text = "Redo";
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // toolBar
            // 
            this.toolBar.AutoSize = false;
            this.toolBar.BackColor = System.Drawing.Color.DimGray;
            this.toolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brushButton,
            this.eraserButton,
            this.shapeToolDropDown,
            this.fillButton,
            this.toolStripButton1});
            this.toolBar.Location = new System.Drawing.Point(0, 24);
            this.toolBar.Name = "toolBar";
            this.toolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolBar.Size = new System.Drawing.Size(1103, 50);
            this.toolBar.TabIndex = 4;
            this.toolBar.Text = "toolStrip1";
            // 
            // brushButton
            // 
            this.brushButton.AutoSize = false;
            this.brushButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.brushButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeToolStripMenuItem});
            this.brushButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.brushButton.Image = ((System.Drawing.Image)(resources.GetObject("brushButton.Image")));
            this.brushButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.brushButton.Name = "brushButton";
            this.brushButton.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.brushButton.Size = new System.Drawing.Size(45, 45);
            this.brushButton.Text = "Brush Tool";
            this.brushButton.Click += new System.EventHandler(this.brushButton_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brushSizeTextBox});
            this.sizeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sizeToolStripMenuItem.Text = "Change Size";
            this.sizeToolStripMenuItem.MouseHover += new System.EventHandler(this.brushSizeToolStripMenuItem_MouseHover);
            // 
            // brushSizeTextBox
            // 
            this.brushSizeTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.brushSizeTextBox.Name = "brushSizeTextBox";
            this.brushSizeTextBox.Size = new System.Drawing.Size(100, 23);
            this.brushSizeTextBox.Click += new System.EventHandler(this.brushSizeTextBox_Click);
            this.brushSizeTextBox.TextChanged += new System.EventHandler(this.brushSizeTextBox_TextChanged);
            // 
            // eraserButton
            // 
            this.eraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eraserButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeSizeToolStripMenuItem});
            this.eraserButton.Image = ((System.Drawing.Image)(resources.GetObject("eraserButton.Image")));
            this.eraserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eraserButton.Name = "eraserButton";
            this.eraserButton.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.eraserButton.Size = new System.Drawing.Size(58, 47);
            this.eraserButton.Text = "Eraser Tool";
            this.eraserButton.Click += new System.EventHandler(this.eraserButton_Click);
            // 
            // changeSizeToolStripMenuItem
            // 
            this.changeSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eraserSizeTextBox});
            this.changeSizeToolStripMenuItem.Name = "changeSizeToolStripMenuItem";
            this.changeSizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changeSizeToolStripMenuItem.Text = "Change Size";
            this.changeSizeToolStripMenuItem.MouseHover += new System.EventHandler(this.eraserSizeToolStripMenuItem_MouseHover);
            // 
            // eraserSizeTextBox
            // 
            this.eraserSizeTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.eraserSizeTextBox.Name = "eraserSizeTextBox";
            this.eraserSizeTextBox.Size = new System.Drawing.Size(100, 23);
            this.eraserSizeTextBox.Click += new System.EventHandler(this.eraserSizeTextBox_Click);
            this.eraserSizeTextBox.TextChanged += new System.EventHandler(this.eraserSizeTextBox_TextChanged);
            // 
            // shapeToolDropDown
            // 
            this.shapeToolDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.shapeToolDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleToolStripMenuItem});
            this.shapeToolDropDown.Image = ((System.Drawing.Image)(resources.GetObject("shapeToolDropDown.Image")));
            this.shapeToolDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.shapeToolDropDown.Name = "shapeToolDropDown";
            this.shapeToolDropDown.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.shapeToolDropDown.Size = new System.Drawing.Size(58, 47);
            this.shapeToolDropDown.Text = "Shape Tool";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton1.Click += new System.EventHandler(this.colorTool_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox.Location = new System.Drawing.Point(12, 89);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1080, 720);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // fillButton
            // 
            this.fillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fillButton.Image = ((System.Drawing.Image)(resources.GetObject("fillButton.Image")));
            this.fillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillButton.Name = "fillButton";
            this.fillButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.fillButton.Size = new System.Drawing.Size(44, 47);
            this.fillButton.Text = "toolStripButton2";
            this.fillButton.ToolTipText = "Fill Tool";
            this.fillButton.Click += new System.EventHandler(this.fillButton_Click);
            // 
            // PixelForgeryGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1103, 820);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.menuBar);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuBar;
            this.MinimumSize = new System.Drawing.Size(1080, 717);
            this.Name = "PixelForgeryGUI";
            this.Text = "Pixel Forge";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PixelForgeryGUI_KeyDown);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
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

        private System.Windows.Forms.ToolStrip toolBar;

        private System.Windows.Forms.PictureBox pictureBox;

        // Variables for code implementation
        private Bitmap BMP;
        private Changes changes;
        private PixelForgeryTool tool = new BrushTool();
        private System.Windows.Forms.ToolStripDropDownButton brushButton;
        private System.Windows.Forms.ToolStripDropDownButton eraserButton;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox brushSizeTextBox;
        private System.Windows.Forms.ToolStripMenuItem changeSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox eraserSizeTextBox;
        private System.Windows.Forms.ToolStripDropDownButton shapeToolDropDown;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton fillButton;
    }
}

