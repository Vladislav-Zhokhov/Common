using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OpenPaint.Utility
{
    class BitmapHelper
    {
        /// <summary>
        /// Saves the specified bitmap to the specified path
        /// </summary>
        /// <param name="bitmap">Bitmap to save</param>
        /// <param name="path">The path to save to (including the file name and extension card name）</param>
        public static void Save(BitmapSource bitmap, string path)
        {
            BitmapEncoder encoder = null;
            string fileExtension = System.IO.Path.GetExtension(path).ToUpper();
            //Select encoder
            switch (fileExtension)
            {
                case ".BMP":
                    encoder = new BmpBitmapEncoder();
                    break;
                case ".GIF":
                    encoder = new GifBitmapEncoder();
                    break;
                case ".JPEG":
                    encoder = new JpegBitmapEncoder();
                    break;
                case ".PNG":
                    encoder = new PngBitmapEncoder();
                    break;
                case ".TIFF":
                    encoder = new TiffBitmapEncoder();
                    break;
                default:
                    throw new Exception("无法识别的图像格式！");
            }
            encoder.Frames.Add(BitmapFrame.Create(bitmap));
            using (var file = File.Create(path))
                encoder.Save(file);
        }
        /// <summary>
        /// Get an image from the control surface
        /// </summary>
        /// <param name="element"></param>
        /// <param name="type"></param>
        /// <param name="outputPath"></param>
        public static void GetPicFromControl(FrameworkElement element, String type, String outputPath)
        {
            //96 For the monitor DPI
            var bitmapRender = new RenderTargetBitmap((int)element.ActualWidth, (int)element.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            //Control content rendering RenderTargetBitmap
            bitmapRender.Render(element);
            BitmapEncoder encoder = null;
            //Select encoder
            switch (type.ToUpper())
            {
                case ".BMP":
                    encoder = new BmpBitmapEncoder();
                    break;
                case ".GIF":
                    encoder = new GifBitmapEncoder();
                    break;
                case ".JPEG":
                    encoder = new JpegBitmapEncoder();
                    break;
                case ".PNG":
                    encoder = new PngBitmapEncoder();
                    break;
                case ".TIFF":
                    encoder = new TiffBitmapEncoder();
                    break;
                default:
                    break;
            }
            //For general pictures, there is only one frame, dynamic pictures are multiple frames.
            encoder.Frames.Add(BitmapFrame.Create(bitmapRender));
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(outputPath)))
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(outputPath));
            using (var file = File.Create(outputPath))
                encoder.Save(file);
        }
        /// <summary>
        /// Save as, returns the saved file name
        /// </summary>
        /// <param name="element"></param>
        public static string SaveAs(BitmapSource bitmap, string path)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "PNG文件(*.png)|*.png|JPG文件(*.jpg)|*.jpg|BMP文件(*.bmp)|*.bmp|GIF文件(*.gif)|*.gif|TIF文件(*.tif)|*.tif";
            saveFileDialog.FileName = path;
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Save(bitmap, path);
                return saveFileDialog.FileName;
            }
            return null;
        }
        /// <summary>
        /// Open the image and return to the image path
        /// </summary>
        /// <returns></returns>
        public static string Open()
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "PNG(*.png)|*.png|JPG(*.jpg)|*.jpg|BMP(*.bmp)|*.bmp|GIF(*.gif)|*.gif|TIF(*.tif)|*.tif";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return ofd.FileName;
            }
            return null;
        }
        /// <summary>
        /// Create a copy of the image file to solve the problem that the file is occupied
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static BitmapImage GetBitmapImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.UriSource = new Uri(imagePath);
            bitmap.EndInit();
            return bitmap.Clone();
        }
    }
}
