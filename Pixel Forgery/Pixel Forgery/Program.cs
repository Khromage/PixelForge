using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pixel_Forgery
{
    internal static class Program
    {
        /// <summary>
        /// Date: 2/26/23
        /// Programmer(s): None (Built-in to WinForm)
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PixelForgeryGUI());
            return;
        }
    }
}
