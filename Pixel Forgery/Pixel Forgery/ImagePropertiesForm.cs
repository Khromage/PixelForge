using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    public partial class ImagePropertiesForm : Form
    {
        public int canvasWidth, canvasHeight;
        public bool changeSize = false;

        public ImagePropertiesForm()
        {
            InitializeComponent();
            ActiveControl = acceptButton;
        }

        private void ImagePropertiesForm_Load(object sender, EventArgs e)
        {
            widthTextBox.Text = canvasWidth.ToString();
            heightTextBox.Text = canvasHeight.ToString();
        }

        private void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            string s = widthTextBox.Text;

            if (float.TryParse(s, out float width) && width > 0)
                canvasWidth = (int) width;
        }

        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            string s = heightTextBox.Text;

            if (float.TryParse(s, out float height) && height > 0)
                canvasHeight = (int) height;
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            canvasWidth = 918; 
            canvasHeight = 595;
            widthTextBox.Text = canvasWidth.ToString();
            heightTextBox.Text = canvasHeight.ToString();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            changeSize = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
