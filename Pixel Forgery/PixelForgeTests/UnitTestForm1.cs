using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixel_Forgery;
using System.Drawing;
using System.IO;

namespace PixelForgeTests
{
    public class UnitTestForm1
    {
        public void TestMethod1()
        {
            // File load better than testing form changes, form changes and unit testing are not aligned
            // File load function should be written such that we can have a public method to test the ability of the class to access a test image file
            FileExplorerDialog fd = new FileExplorerDialog();
            // Bitmap b = new Bitmap(1, 1);
            // b = fd.OpenFile(b);

            // string path = @"c:\temp\MyTest.txt";
        }
    }
}
