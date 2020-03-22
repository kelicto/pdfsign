/*
 * MIT License
 *
 * Copyright(c) 2020 KeLi
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

/*
             ,---------------------------------------------------,              ,---------,
        ,----------------------------------------------------------,          ,"        ,"|
      ,"                                                         ,"|        ,"        ,"  |
     +----------------------------------------------------------+  |      ,"        ,"    |
     |  .----------------------------------------------------.  |  |     +---------+      |
     |  | C:\>FILE -INFO                                     |  |  |     | -==----'|      |
     |  |                                                    |  |  |     |         |      |
     |  |                                                    |  |  |/----|`---=    |      |
     |  |              Author: KeLi                          |  |  |     |         |      |
     |  |              Email: kelistudy@163.com              |  |  |     |         |      |
     |  |              Creation Time: 03/23/2020 01:00:00 PM |  |  |     |         |      |
     |  | C:\>_                                              |  |  |     | -==----'|      |
     |  |                                                    |  |  |   ,/|==== ooo |      ;
     |  |                                                    |  |  |  // |(((( [66]|    ,"
     |  `----------------------------------------------------'  |," .;'| |((((     |  ,"
     +----------------------------------------------------------+  ;;  | |         |,"
        /_)_________________________________________________(_/  //'   | +---------+
           ___________________________/___  `,
          /  oooooooooooooooo  .o.  oooo /,   \,"-----------
         / ==ooooooooooooooo==.o.  ooo= //   ,`\--{)B     ,"
        /_==__==========__==_ooo__ooo=_/'   /___________,"
*/

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using iTextSharp.text.pdf;

using ThoughtWorks.QRCode.Codec;

using Image = iTextSharp.text.Image;

namespace KeLi.PdfSign.App
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

            var qrCodeEncoder = new QRCodeEncoder
            {
                QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE,

                QRCodeScale = 4,

                QRCodeVersion = 0,

                QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M
            };

            return qrCodeEncoder.Encode(link);
        }
    }
}
