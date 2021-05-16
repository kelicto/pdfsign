using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KeLi.PdfSign.App.Components
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