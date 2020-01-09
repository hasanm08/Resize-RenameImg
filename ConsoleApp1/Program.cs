using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rename();
            var dirnames = Directory.GetDirectories(@"C:\Users\hasanm08\Downloads\Telegram Desktop\kcarpet\New folder (2)");
            Console.WriteLine(dirnames[0] + " \n " + dirnames[1]);
            string[] fnames = Directory.GetFiles(@"C:\Users\hasanm08\Downloads\Telegram Desktop\kcarpet\New folder (5)\New folder", "*.jpg");
            string[] fnames2 = Directory.GetFiles(@"C:\Users\hasanm08\Downloads\Telegram Desktop\kcarpet\test\New folder", "*.jpg");
            for (int i = 0; i < fnames.Length; i++)
            {
                FileInfo fileInfo = new FileInfo(fnames[i]);
                FileInfo fileInfo2 = new FileInfo(fnames2[i]);
                Image img = Image.FromFile(fileInfo.FullName);
                Image img2 = Image.FromFile(fileInfo2.FullName);
                Save(bmp: ResizeImage(img2, img)
                     , index: fnames2[i].Substring(fnames2[i].LastIndexOf('\\'), fnames2[i].LastIndexOf('.') - fnames2[i].LastIndexOf('\\')));
            }


            //string[] fnames = Directory.GetFiles(@"E:\New folder\New folder", "*.jpg");
            //for (int i = 0; i < fnames.Length; i++)
            //{
            //    FileInfo fileInfo = new FileInfo(fnames[i]);
            //    Image img = Image.FromFile(fileInfo.FullName);
            //    Save(bmp: ResizeImage(img)
            //         , index: i.ToString());
            //}
            Console.ReadKey(true);
        }

        public static void Save(Bitmap bmp, string index)
        {
            Image img = bmp;
            img.Save(@"C:\Users\hasanm08\Downloads\New folder (6)\" + index.ToString()+ ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            FileInfo img__ = new FileInfo(@"C:\Users\hasanm08\Downloads\New folder (6)\" + index.ToString() + ".jpg");
            img__.MoveTo(@"C:\Users\hasanm08\Downloads\New folder (6)\" + index.ToString() + ".jpg");
        }
        public static Bitmap ResizeImage(Image image, Image sketch)
        {
            int width=sketch.Width;
            int height=sketch.Height;
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
        public static Bitmap ResizeImage(Image image)
        {
            int width = 61;
            int height = 87;
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
        public static void Rename()
        {
            var dirnames = Directory.GetDirectories(@"C:\Users\hasanm08\Downloads\Telegram Desktop\kcarpet\test");
            int i = 0;
            try
            {
                foreach (var dir in dirnames)
                {
                    var fnames = Directory.GetFiles(dir, "*.jpg").Select(Path.GetFileName);
                    DirectoryInfo d = new DirectoryInfo(dir);
                    FileInfo[] finfo = d.GetFiles("*.jpg");
                    foreach (var f in fnames)
                    {
                        i++;
                        Console.WriteLine("The number of the file being renamed is: {0}", i);
                        if (!File.Exists(Path.Combine(dir, f.ToString().Replace("1 (", "").Replace(")", ""))))
                        {
                            File.Move(Path.Combine(dir, f), Path.Combine(dir, f.ToString().Replace("1 (", "").Replace(")", "")));
                        }
                        else
                        {
                            Console.WriteLine("The file you are attempting to rename already exists! The file path is {0}.", dir);
                            foreach (FileInfo fi in finfo)
                            {
                                Console.WriteLine("The file modify date is: {0} ", File.GetLastWriteTime(dir));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
