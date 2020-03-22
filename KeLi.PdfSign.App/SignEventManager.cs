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
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KeLi.PdfSign.App
{
    public class SignEventManager : Control
    {
        private Point _ctrlDownPt;

        private bool _isDown;

        private Point _mouseDownPt;

        private Form _ownerForm;

        private static Control _pdfImgCtrl;

        public void RegistMouseEvent(Control moveCtrl, Control pdfImgCtrl, Form ownerForm)
        {
            _pdfImgCtrl = pdfImgCtrl;

            _ownerForm = ownerForm;

            moveCtrl.MouseDown += MoveCtrl_MouseDown;

            moveCtrl.MouseMove += MoveCtrl_MouseMove;

            moveCtrl.MouseUp += MoveCtrl_MouseUp;

            moveCtrl.Click += MoveCtrl_Click;

            moveCtrl.KeyDown += MoveCtrl_KeyDown;
        }

        private void MoveCtrl_Click(object sender, EventArgs e)
        {
            if (!(sender is PictureBox pb))
                return;

            pb.BackColor = Color.Blue;

            pb.Focus();

            var pbCtrls = new List<PictureBox>();

            foreach (var ctrl in _ownerForm.Controls)
            {
                if (ctrl is PictureBox item)
                    pbCtrls.Add(item);
            }

            var pbSigns = pbCtrls.Where(s => s != _pdfImgCtrl && s != pb).ToList();

            pbSigns.ForEach(f => f.BackColor = Color.DarkGray);
        }

        private void MoveCtrl_MouseUp(object sender, MouseEventArgs e)
        {
            _isDown = false;
        }

        private void MoveCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            var x = PointToClient(MousePosition).X - _mouseDownPt.X;

            var y = PointToClient(MousePosition).Y - _mouseDownPt.Y;

            if (!_isDown)
                return;

            var pbWidth = _pdfImgCtrl.Width;

            var pbHeight = _pdfImgCtrl.Height;

            if (!(sender is PictureBox pb))
                return;

            if (_ctrlDownPt.X + x <= 0)
                return;

            if (_ctrlDownPt.Y + y <= 0)
                return;

            if (_ctrlDownPt.X + x >= pbWidth - pb.Width)
                return;

            if (_ctrlDownPt.Y + y >= pbHeight - pb.Height)
                return;

            pb.Location = new Point(_ctrlDownPt.X + x, _ctrlDownPt.Y + y);
        }

        private void MoveCtrl_MouseDown(object sender, MouseEventArgs e)
        {
            _isDown = true;

            _mouseDownPt = PointToClient(MousePosition);

            if (!(sender is PictureBox pb))
                return;

            _ctrlDownPt = pb.Location;
        }

        private void MoveCtrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(sender is PictureBox pb))
                return;

            var position = pb.Location;

            if (position.X <= 0 && e.KeyCode == Keys.Left)
                return;

            if (position.Y <= 0 && e.KeyCode == Keys.Up)
                return;

            if (position.X >= _pdfImgCtrl.Width - pb.Width && e.KeyCode == Keys.Right)
                return;

            if (position.Y >= _pdfImgCtrl.Height - pb.Height && e.KeyCode == Keys.Down)
                return;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    pb.Location = new Point(position.X, position.Y - 1);

                    break;

                case Keys.Down:
                    pb.Location = new Point(position.X, position.Y + 1);

                    break;

                case Keys.Left:
                    pb.Location = new Point(position.X - 1, position.Y);

                    break;

                case Keys.Right:
                    pb.Location = new Point(position.X + 1, position.Y);

                    break;
            }
        }
    }
}