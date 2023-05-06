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
            Bitmap bmpTest = new Bitmap(1, 1);

            f.p.Color = Color.Blue;

            Bitmap bmp = new Bitmap(100, 100);
            bmp = f.DfsFill(50, 50, bmp);

            var imageFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            Image image = Image.FromFile(Path.Combine(imageFile, "Testing2.png"));
            Bitmap bmpActual = new Bitmap(image);

            bmp.Save(Path.Combine(imageFile, "Testing2.png"));
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

            bool mismatch = false;
            for (int x = 0; x < bmpActual.Width; x++)
            {
                for (int y = 0; y < bmpActual.Height; y++)
                {
                    if (bmpActual.GetPixel(x, y).ToArgb() != bmpTest.GetPixel(x, y).ToArgb())
                    {
                        mismatch = true;
                        break;
                    }
                }
                if (mismatch) break;
            }
            Assert.IsFalse(mismatch);
        }
    }
}
