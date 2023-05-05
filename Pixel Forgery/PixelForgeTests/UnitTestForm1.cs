using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixel_Forgery;

namespace PixelForgeTests
{
    [TestClass]
    public class UnitTestForm1
    {

        [TestMethod]
        public void TestMethod1()
        {
            //File load better than testing form changes, form changes and unit testing are not aligned
            //File load function should be written such that we can have a public method to test the ability of the class to access a test image file
        }
    }
}
