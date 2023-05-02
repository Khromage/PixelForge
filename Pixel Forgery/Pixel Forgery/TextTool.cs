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
    /// 
    /// </summary>
    public class TextTool : PixelForgeryTool
    {
        private float _startX;
        private float _startY;

        private StringFormat _format;
        private string _font = "Arial";
        private float _fontSize = 10;

        public string StringToPrint { set; get; } = "Work In Progress... Stay Tuned d^_^b";

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="pictureBox1"></param>
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
            g.DrawString(StringToPrint, new Font(_font, _fontSize), Brushes.Black, rec, _format);
            g.Flush();

            pictureBox1.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
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

            string str = StringToPrint + $"\n({x1},{y1}), ({x2}, {y2})";

            g.DrawString(str, new Font(_font, _fontSize), Brushes.Black, rec, _format);
            g.Flush();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fontSize"></param>
        public void SetFontSize(float fontSize)
        {
            _fontSize = fontSize;
            if (fontSize < 0)
                _fontSize = 10;
        }
    }
}
