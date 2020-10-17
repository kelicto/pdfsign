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
     |  |              Email: kelicto@protonmail.com         |  |  |     |         |      |
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

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace KeLi.PdfSign.App
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