using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using iTextSharp.text.pdf;

using KeLi.PdfSign.App.Models;

using Image = iTextSharp.text.Image;

namespace KeLi.PdfSign.App.Utils
{
    public class SignUtil
    {
        public void AddSign(SignFile file, string link, Point position)
        {
            if (file is null)
                throw new ArgumentNullException(nameof(file));

            if (link is null)
                throw new ArgumentNullException(nameof(link));

            if (position == null)
                throw new ArgumentNullException(nameof(position));

            if (File.Exists(file.SignedPath))
            {
                File.SetAttributes(file.SignedPath, File.GetAttributes(file.SignedPath) & FileAttributes.Archive);

                File.Delete(file.SignedPath);
            }

            using (var input = new FileStream(file.OriginalPath, FileMode.Open, FileAccess.Read))
            {
                using (var output = new FileStream(file.SignedPath, FileMode.Create, FileAccess.Write))
                {
                    var reader = new PdfReader(input);

                    var stamper = new PdfStamper(reader, output);

                    var content = stamper.GetOverContent(1);

                    using (var memory = new MemoryStream())
                    {
                        GetImage(link).Save(memory, ImageFormat.Bmp);

                        var image = Image.GetInstance(memory.ToArray());

                        image.SetAbsolutePosition(position.X, position.Y);

                        image.ScaleAbsolute(80, 80);

                        content.AddImage(image);
                    }
                }
            }
        }

        public static Bitmap GetImage(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
                throw new ArgumentNullException(nameof(link));

            // TODO: QR code.
            return null;
        }
    }
}
