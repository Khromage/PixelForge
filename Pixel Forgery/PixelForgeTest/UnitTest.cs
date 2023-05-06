using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using Pixel_Forgery;
using System.IO;

namespace PixelForgeTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestBitmapChangeOnUserSelect()
        {//open image, open new image
            FileExplorerDialog dialog = new FileExplorerDialog();
            Bitmap bmpTest = new Bitmap(1, 1);
            //bmpTest = dialog.OpenFile(bmpTest);

            var imageFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            Image image = Image.FromFile(Path.Combine(imageFile, "PixelForgeLogo_Final.png"));
            Bitmap bmpActual = new Bitmap(image);

            bmpTest = dialog.OpenFile(bmpActual); 
            //if press cancel, bmpTest == actual
            //else is different, !=
            //if same image == 

            //Testing image select
            Assert.AreNotEqual(bmpActual, bmpTest, "Test Passed!");
        }

        [TestMethod]
        public void TestBitmapNoChangeOnUserCancel()
        {//open image, open new image
            FileExplorerDialog dialog = new FileExplorerDialog();
            Bitmap bmpTest = new Bitmap(1, 1);
            //bmpTest = dialog.OpenFile(bmpTest);

            Image image = Image.FromFile("C:\\Users\\taylo\\source\\repos\\PixelForge\\Pixel Forgery\\PixelForgeTest\\PixelForgeLogo_Final.png");
            Bitmap bmpActual = new Bitmap(image);

            bmpTest = dialog.OpenFile(bmpActual);
            //if press cancel, bmpTest == actual
            //else is different, !=
            //if same image == 
            

            //Testing image cancel
            Assert.AreEqual(bmpActual, bmpTest, "Test Passed!");
        }
    }
}
