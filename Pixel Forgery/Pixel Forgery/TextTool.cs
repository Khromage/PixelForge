using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    /// <summary>
    /// This class provides the ability to draw text to the canvas. Derives from <see cref="PixelForgeryTool"/>.<br/>
    /// The current functionality includes changing the text to print, and setting the size of the text.
    /// <list type="bullet">
    /// <item>Date: 5/1/23</item>
    /// <item>Programmer(s): Lilianna Rosales</item>
    /// </list>
    /// </summary>
    public class TextTool : PixelForgeryTool
    {
        private float _startX;
        private float _startY;
        private StringFormat _format;
        private string _font = "Arial";

        /// <summary>
        /// Setter/Getter for the font size
        /// <list type="bullet">
        /// <item>Date: 5/1/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        public float FontSize { set; get; } = 10;

        /// <summary>
        /// Setter/Getter for the text to paint
        /// <list type="bullet">
        /// <item>Date: 5/1/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        public string StringToPrint { set; get; } = "";

        /// <summary>
        /// Constructor that creates a <see cref="TextTool"/> object.
        /// <list type="bullet">
        /// <item>Date: 5/1/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        public TextTool () : base()
        {
            _format = new StringFormat()
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            };
        }

        /// <summary>
        /// Draws the text in <see cref="StringToPrint"/> to the selected canvas area.
        /// <list type="bullet">
        /// <item>Date: 5/1/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        /// <param name="e">is the mouse event parameter and contains data like location and mouse button click type</param>
        /// <param name="pictureBox1">Reference to the pictureBox.</param>
        public override void UseTool(MouseEventArgs e, PictureBox pictureBox1)
        {
            float x1 = startX;
            float y1 = startY;
            float x2 = endX;
            float y2 = endY;
            float width = Math.Abs(x2 - x1);
            float height = Math.Abs(y2 - y1);

            if ((y2 > y1) && (x1 > x2))
            {
                _startX = x2;
                _startY = y1;
            }
            else if ((y1 > y2) && (x2 > x1))
            {
                _startX = x1;
                _startY = y2;
            }
            else if ((y1 > y2) && (x1 > x2))
            {
                _startX = x2;
                _startY = y2;
            }
            else
            {
                _startX = x1;
                _startY = y1;
            }

            RectangleF rec = new RectangleF(_startX, _startY, width, height);

            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.DrawString(StringToPrint, new Font(_font, FontSize), Brushes.Black, rec, _format);
            g.Flush();

            pictureBox1.Refresh();
        }

        /// <summary>
        /// Draws a temporary string to the canvas area. The temp string is defined by <see cref="StringToPrint"/>. <br/>
        /// This helps define where the text will be drawn, and dynamically changes based on the starting cursor position <br/>
        /// and the current cursor position
        /// <list type="bullet">
        /// <item>Date: 5/1/23</item>
        /// <item>Programmer(s): Lilianna Rosales</item>
        /// </list>
        /// </summary>
        /// <param name="e">The paint event handler that contains the graphics of the control</param>
        public override void DrawOutline(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            float x1 = startX;
            float y1 = startY;
            float x2 = endX;
            float y2 = endY;
            float width = Math.Abs(x2 - x1);
            float height = Math.Abs(y2 - y1);

            if ((y2 > y1) && (x1 > x2))
            {
                _startX = x2;
                _startY = y1;
            }
            else if ((y1 > y2) && (x2 > x1))
            {
                _startX = x1;
                _startY = y2;
            }
            else if ((y1 > y2) && (x1 > x2))
            {
                _startX = x2;
                _startY = y2;
            }
            else
            {
                _startX = x1;
                _startY = y1;
            }

            RectangleF rec = new RectangleF(_startX, _startY, width, height);

            g.DrawString(StringToPrint, new Font(_font, FontSize), Brushes.Black, rec, _format);
            g.Flush();
        }
    }
}
