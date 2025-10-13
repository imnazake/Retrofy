using Retrofy.Core;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retrofy
{
    public partial class MainForm : Form
    {
        private Bitmap OriginImage;
        private Bitmap ResultImage;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllowDrop = true;
            OriginTexture.AllowDrop = true;

            CenterLabelInPictureBox(label1, OriginTexture);
        }

        private Bitmap ScaleImageToPictureBox(Bitmap original, PictureBox box)
        {
            int targetWidth = box.Width;
            int targetHeight = box.Height;

            float ratioX = (float)targetWidth / original.Width;
            float ratioY = (float)targetHeight / original.Height;
            float ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(original.Width * ratio);
            int newHeight = (int)(original.Height * ratio);

            Bitmap scaled = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(scaled))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, 0, 0, newWidth, newHeight);
            }
            return scaled;
        }

        private void CenterLabelInPictureBox(Label label, PictureBox box)
        {
            label.Left = box.Left + (box.Width - label.Width) / 2;
            label.Top = box.Top + (box.Height - label.Height) / 2;
        }

        private void CenterLabelInPanel(Label label, Panel panel)
        {
            label.Left = panel.Left + (panel.Width - label.Width) / 2;
            label.Top = panel.Top + (panel.Height - label.Height) / 2;
        }

        private DitherAlgorithm GetSelectedAlgorithm(string selectedText)
        {
            switch (selectedText)
            {
                case "Floyd–Steinberg (Error Diffusion)":
                    return Retrofy.Core.DitherAlgorithm.FloydSteinberg;

                case "Serpentine Dither":
                    return Retrofy.Core.DitherAlgorithm.Serpentine;

                case "Bayer (Ordered)":
                    return Retrofy.Core.DitherAlgorithm.BayerOrdered;

                default:
                    return Retrofy.Core.DitherAlgorithm.FloydSteinberg; // default fallback
            }
        }
        private void OriginTexture_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0)
            {
                try
                {
                    label1.Visible = false;

                    // keep original for processing
                    Bitmap original = new Bitmap(files[0]);
                    OriginImage = original; 
                    ResultImage = (Bitmap)original.Clone();

                    // Scale for preview
                    Bitmap preview = ScaleImageToPictureBox(original, OriginTexture);

                    OriginTexture.Image?.Dispose();
                    OriginTexture.Image = preview;

                    Bitmap result = ScaleImageToPictureBox(ResultImage, ResultTexture);

                    ResultTexture.Image?.Dispose();
                    ResultTexture.Image = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load image: " + ex.Message);
                }
            }
        }

        private void OriginTexture_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the dragged data is a file
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Show copy cursor
            else
                e.Effect = DragDropEffects.None;
        }

        private async Task ApplyDitheringAsync()
        {
            if (OriginImage == null) return;

            // Disable UI
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            ApplyDither.Enabled = false;
            ExportTexture.Enabled = false;

            int colorLevels = (int)DitherValue.Value; // 1–10 → 2–16
            DitherAlgorithm algo = GetSelectedAlgorithm(DitherAlgorithm.SelectedItem.ToString());

            Bitmap dithered = await Task.Run(() =>
            {
                // Clone original
                Bitmap img = (Bitmap)OriginImage.Clone();

                // Apply dithering at full resolution
                Bitmap result = ImageDither.Apply(img, colorLevels, algo);

                return result;
            });

            // Store scaled & dithered image for export
            ResultImage?.Dispose();
            ResultImage = dithered;

            // Show in ResultTexture
            ResultTexture.Image?.Dispose();
            ResultTexture.Image = ScaleImageToPictureBox(dithered, ResultTexture);

            // Re-enable UI
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            ApplyDither.Enabled = true;
            ExportTexture.Enabled = true;
        }

        private async void ApplyDither_Click(object sender, EventArgs e)
        {
           await ApplyDitheringAsync();
        }

        private void ExportTexture_Click(object sender, EventArgs e)
        {
            if (ResultImage == null)
            {
                MessageBox.Show("No image to export!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                sfd.Title = "Export Texture";
                sfd.FileName = "result_texture";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Determine format based on file extension
                        System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;

                        switch (System.IO.Path.GetExtension(sfd.FileName).ToLower())
                        {
                            case ".jpg":
                            case ".jpeg":
                                format = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case ".bmp":
                                format = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                        }

                        // Save the image
                        ResultImage.Save(sfd.FileName, format);
                        MessageBox.Show("Texture exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to export texture: " + ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
