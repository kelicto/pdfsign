using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace KeLi.PdfSign.App.Utils
{
    public static class CaptureUtll
    {
        public static void CaptureImage(this Control ctrl, Form form, string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            var rect = Screen.PrimaryScreen.Bounds;
            var size = new Size(ctrl.Width, ctrl.Height);

            using (var bitmap = new Bitmap(rect.Width, rect.Height))
            {
                var grp = Graphics.FromImage(bitmap);
                var location = new Point(form.Left + 8, form.Top + 32);

                grp.CopyFromScreen(location, new Point(0, 0), size);
                grp.ReleaseHdc(grp.GetHdc());
                bitmap.Save(filePath);
            }

            using (var srcImg = Image.FromFile(filePath))
            {
                using (var bitmap = new Bitmap(ctrl.Width, ctrl.Height))
                {
                    using (var grp = Graphics.FromImage(bitmap))
                    {
                        grp.DrawImage(srcImg, 0, 0, new Rectangle(new Point(), size), GraphicsUnit.Pixel);
                        srcImg.Dispose();

                        using (Image newImg = Image.FromHbitmap(bitmap.GetHbitmap()))
                            newImg.Save(filePath, ImageFormat.Jpeg);
                    }
                }
            }
        }
    }
}