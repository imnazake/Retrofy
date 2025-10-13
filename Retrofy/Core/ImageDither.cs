using System;
using System.Drawing;

namespace Retrofy.Core
{
    public enum DitherAlgorithm
    {
        None,
        FloydSteinberg,
        Serpentine,
        BayerOrdered
    }

    public class ImageDither
    {
        public static Bitmap Apply(Bitmap source, int colorLevels, DitherAlgorithm algorithm, Action<Bitmap> previewCallback = null)
        {
            switch (algorithm)
            {
                case DitherAlgorithm.FloydSteinberg:
                    return FloydSteinberg(source, colorLevels, previewCallback);
                case DitherAlgorithm.Serpentine:
                    return Serpentine(source, colorLevels, previewCallback);
                case DitherAlgorithm.BayerOrdered:
                    return Bayer(source, colorLevels);
                case DitherAlgorithm.None:
                default:
                    return new Bitmap(source); // just return a copy
            }
        }

        #region Floyd–Steinberg
        private static Bitmap FloydSteinberg(Bitmap source, int levels, Action<Bitmap> previewCallback = null)
        {
            Bitmap bmp = new Bitmap(source);
            int w = bmp.Width;
            int h = bmp.Height;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Color oldColor = bmp.GetPixel(x, y);
                    int newR = Quantize(oldColor.R, levels);
                    int newG = Quantize(oldColor.G, levels);
                    int newB = Quantize(oldColor.B, levels);

                    Color newColor = Color.FromArgb(newR, newG, newB);
                    bmp.SetPixel(x, y, newColor);

                    int errR = oldColor.R - newR;
                    int errG = oldColor.G - newG;
                    int errB = oldColor.B - newB;

                    SpreadError(bmp, x + 1, y, errR, errG, errB, 7.0 / 16);
                    SpreadError(bmp, x - 1, y + 1, errR, errG, errB, 3.0 / 16);
                    SpreadError(bmp, x, y + 1, errR, errG, errB, 5.0 / 16);
                    SpreadError(bmp, x + 1, y + 1, errR, errG, errB, 1.0 / 16);
                }
                previewCallback?.Invoke((Bitmap)bmp.Clone());
            }
            return bmp;
        }
        #endregion

        #region Serpentine (Floyd–Steinberg variant)
        private static Bitmap Serpentine(Bitmap source, int levels, Action<Bitmap> previewCallback = null)
        {
            Bitmap bmp = new Bitmap(source);
            int w = bmp.Width;
            int h = bmp.Height;

            for (int y = 0; y < h; y++)
            {
                bool leftToRight = y % 2 == 0;
                if (!leftToRight)
                {
                    for (int x = w - 1; x >= 0; x--)
                        ApplySerpentinePixel(bmp, x, y, levels);
                }
                else
                {
                    for (int x = 0; x < w; x++)
                        ApplySerpentinePixel(bmp, x, y, levels);
                }

                previewCallback?.Invoke((Bitmap)bmp.Clone());
            }

            return bmp;
        }

        private static void ApplySerpentinePixel(Bitmap bmp, int x, int y, int levels)
        {
            Color oldColor = bmp.GetPixel(x, y);
            int newR = Quantize(oldColor.R, levels);
            int newG = Quantize(oldColor.G, levels);
            int newB = Quantize(oldColor.B, levels);

            Color newColor = Color.FromArgb(newR, newG, newB);
            bmp.SetPixel(x, y, newColor);

            int errR = oldColor.R - newR;
            int errG = oldColor.G - newG;
            int errB = oldColor.B - newB;

            int w = bmp.Width;
            int h = bmp.Height;

            bool leftToRight = y % 2 == 0;

            if (leftToRight)
            {
                SpreadError(bmp, x + 1, y, errR, errG, errB, 7.0 / 16);
                SpreadError(bmp, x - 1, y + 1, errR, errG, errB, 3.0 / 16);
                SpreadError(bmp, x, y + 1, errR, errG, errB, 5.0 / 16);
                SpreadError(bmp, x + 1, y + 1, errR, errG, errB, 1.0 / 16);
            }
            else
            {
                SpreadError(bmp, x - 1, y, errR, errG, errB, 7.0 / 16);
                SpreadError(bmp, x + 1, y + 1, errR, errG, errB, 3.0 / 16);
                SpreadError(bmp, x, y + 1, errR, errG, errB, 5.0 / 16);
                SpreadError(bmp, x - 1, y + 1, errR, errG, errB, 1.0 / 16);
            }
        }
        #endregion

        #region Bayer (Ordered)
        private static int[,] bayerMatrix = new int[,]
        {
            {0, 8, 2, 10},
            {12, 4, 14, 6},
            {3, 11, 1, 9},
            {15, 7, 13, 5}
        };

        private static Bitmap Bayer(Bitmap source, int levels)
        {
            Bitmap bmp = new Bitmap(source);
            int n = 4; // 4x4 Bayer matrix

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int threshold = bayerMatrix[y % n, x % n];

                    int r = ApplyThreshold(c.R, threshold, levels);
                    int g = ApplyThreshold(c.G, threshold, levels);
                    int b = ApplyThreshold(c.B, threshold, levels);

                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return bmp;
        }

        private static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private static int Clamp(double value)
        {
            if (value < 0) return 0;
            if (value > 255) return 255;
            return (int)value;
        }

        private static int ApplyThreshold(int color, int threshold, int levels)
        {
            float scale = 255f / (levels - 1);
            float t = threshold / 16.0f; // normalize 0–1
            int q = (int)Math.Round(Clamp(color / scale + t, 0, levels - 1));
            return (int)(q * scale);
        }
        #endregion

        #region Helpers
        private static int Quantize(int color, int levels)
        {
            if (levels <= 1) return color; // avoid division by zero
            float scale = 255f / (levels - 1);
            int q = (int)Math.Round(color / scale);
            return Math.Min(255, Math.Max(0, (int)(q * scale))); // clamp to 0–255
        }

        private static void SpreadError(Bitmap bmp, int x, int y, int errR, int errG, int errB, double factor)
        {
            if (x < 0 || y < 0 || x >= bmp.Width || y >= bmp.Height) return;

            Color c = bmp.GetPixel(x, y);
            int r = Clamp(c.R + errR * factor);
            int g = Clamp(c.G + errG * factor);
            int b = Clamp(c.B + errB * factor);

            bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
        }
        #endregion
    }
}
