using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using Pixel_Forgery;
using System.IO;
using System.Windows.Forms;

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

            var imageFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            Image image = Image.FromFile(Path.Combine(imageFile, "PixelForgeLogo_Final.png"));
            Bitmap bmpActual = new Bitmap(image);

            bmpTest = dialog.OpenFile(bmpActual);
            //if press cancel, bmpTest == actual
            //else is different, !=
            //if same image == 
            

            //Testing image cancel
            Assert.AreEqual(bmpActual, bmpTest, "Test Passed!");
        }

        [TestMethod]
        public void DfsFillTest()
        {
            FillTool f = new FillTool();
            FileExplorerDialog dialog = new FileExplorerDialog();

            f.pen.Color = Color.Blue;

            Bitmap bmpTest = new Bitmap(100, 100);
            bmpTest = f.DfsFill(50, 50, bmpTest);

            var imageFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            Image image = Image.FromFile(Path.Combine(imageFile, "Testing2.png"));
            Bitmap bmpActual = new Bitmap(image);

            Assert.IsTrue(CompareBitmap(bmpTest, bmpActual));
        }

        [TestMethod]
        public void TestBitmapCompare()
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

            Assert.IsTrue(CompareBitmap(bmpTest, bmpActual));
        }

        public Boolean CompareBitmap(Bitmap a, Bitmap b)
        {
            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    if (b.GetPixel(x, y).ToArgb() != a.GetPixel(x, y).ToArgb())
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
