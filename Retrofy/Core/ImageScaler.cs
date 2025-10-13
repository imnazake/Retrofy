using System.Drawing;
using System.Drawing.Drawing2D;

namespace Retrofy.Core
{
    public class ImageScaler
    {
        /// <summary>
        /// Resizes an image by a scale factor.
        /// </summary>
        public static Bitmap Scale(Bitmap source, float scale)
        {
            int newWidth = (int)(source.Width * scale);
            int newHeight = (int)(source.Height * scale);

            Bitmap result = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(source, 0, 0, newWidth, newHeight);
            }
            return result;
        }

        /// <summary>
        /// Resizes an image to specific dimensions.
        /// </summary>
        public static Bitmap Resize(Bitmap source, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(source, 0, 0, width, height);
            }
            return result;
        }
    }
}
