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
    /// <summary>
    /// Date: 4/16/23
    /// Programmer: Justin Reyes
    /// ImagePropertiesForm class which contains the functionality for this form.
    /// Contains EventListeners for MouseEvents.
    /// This form is shown to the user whenever they press the Image Properties button in the main application.
    /// It is necessary for setting the width and height of the canvas.
    /// </summary>
    public partial class ImagePropertiesForm : Form
    {
        /// <summary>
        /// Date: 4/16/23
        /// Programmer: Justin Reyes
        /// Integer variables containing the width and height that the user desires for the canvas.
        /// </summary>
        public int canvasWidth, canvasHeight;

        /// <summary>
        /// Date: 4/16/23
        /// Programmer: Justin Reyes
        /// Boolean variable that checks whether or not the user accepts or cancels the canvas resize.
        /// </summary>
        public bool changeSize = false;

        /// <summary>
        /// Date: 4/16/23
        /// Programmer: Justin Reyes
        /// Constructor for the ImageProperties form class.
        /// Initializes the GUI elements and sets default control of the user.
        /// </summary>
        public ImagePropertiesForm()
        {
            InitializeComponent();
            ActiveControl = acceptButton;
        }

        /// <summary>
        /// Date: 4/16/23
        /// Programmer: Justin Reyes
        /// Sets the text of the width and height Text Boxes to what the main GUI's canvas is currently set to.
        /// </summary>
        /// <param name="sender">Reference to the ImagePropertiesForm object.</param>
        /// <param name="e">Event listener for when the form is initialized and loaded to the screen.</param>
        private void ImagePropertiesForm_Load(object sender, EventArgs e)
        {
            widthTextBox.Text = canvasWidth.ToString();
            heightTextBox.Text = canvasHeight.ToString();
        }

        /// <summary>
        /// Date: 4/16/23
        /// Programmer: Justin Reyes
        /// Reads the text inputted by the user into the widthTextBox and converts it to an integer.
        /// Sets the canvasWidth variable to the parsed integer.
        /// </summary>
        /// <param name="sender">Reference to the widthTextBox object.</param>
        /// <param name="e">Event listener for when the Text Box's content is changed.</param>
        private void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            string s = widthTextBox.Text;

            if (float.TryParse(s, out float width) && width > 0)
                canvasWidth = (int) width;
        }

        /// <summary>
        /// Date: 4/16/23
        /// Programmer: Justin Reyes
        /// Reads the text inputted by the user into the heightTextBox and converts it to an integer.
        /// Sets the canvasHeight variable to the parsed integer.
        /// </summary>
        /// <param name="sender">Reference to the heightTextBox object.</param>
        /// <param name="e">Event listener for when the Text Box's content is changed.</param>
        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            string s = heightTextBox.Text;

            if (float.TryParse(s, out float height) && height > 0)
                canvasHeight = (int) height;
        }

        /// <summary>
        /// Date: 4/16/23
        /// Programmer: Justin Reyes
        /// Sets the width and height Text Boxes to their default values.
        /// </summary>
        /// <param name="sender">Reference to the defaultButton object.</param>
        /// <param name="e">Event listener for when the Button is clicked.</param>
        private void defaultButton_Click(object sender, EventArgs e)
        {
            canvasWidth = 918; 
            canvasHeight = 595;
            widthTextBox.Text = canvasWidth.ToString();
            heightTextBox.Text = canvasHeight.ToString();
        }

        /// <summary>
        /// Date: 4/16/23
        /// Programmer: Justin Reyes
        /// Accepts the changes made to the canvas width and height, closes this form, and sends control back to the main GUI.
        /// </summary>
        /// <param name="sender">Reference to the acceptButton object.</param>
        /// <param name="e">Event listener for when the Button is clicked.</param>
        private void acceptButton_Click(object sender, EventArgs e)
        {
            changeSize = true;
            this.Close();
        }

        /// <summary>
        /// Date: 4/16/23
        /// Programmer: Justin Reyes
        /// Closes this form and sends control back to the main GUI without changing anything.
        /// </summary>
        /// <param name="sender">Reference to the cancelButton object.</param>
        /// <param name="e">Event listener for when the Button is clicked.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
