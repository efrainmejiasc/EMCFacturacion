using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace NegocioEMC.Commons
{
    public class EngineImg
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validar la compatibilidad de la plataforma", Justification = "<pendiente>")]
        public static Bitmap MarcaDeAgua(Bitmap bmp)
        {
            //Image image = Image.FromFile(path);
            //Bitmap bmp = new Bitmap(image);
            Graphics graphicsobj = Graphics.FromImage(bmp);
            Brush brush = new SolidBrush(Color.FromArgb(80, 255, 255, 255));
            //Brush brush = new SolidBrush(Color.Red);
            var pointX = 5;
            var pointY = bmp.Height / 2 ;
            Point postionWaterMark = new Point(pointX, pointY);
           // graphicsobj.RotateTransform(-45.0f);
            graphicsobj.DrawString("Efrain LongHard", new System.Drawing.Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel), brush, postionWaterMark);
            //Image img = bmp as Image;
            //Image img = bmp as Image
            //img.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            graphicsobj.Dispose();

            return bmp;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validar la compatibilidad de la plataforma", Justification = "<pendiente>")]
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
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
 
        public static string ConvertImageToBase64Str(string path)
        {
            var contents = System.IO.File.ReadAllBytes(path);
            return $"data:image/png;base64,{Convert.ToBase64String(contents)}";
        }


    }
}
