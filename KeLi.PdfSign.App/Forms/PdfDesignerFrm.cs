using System.Windows.Forms;

using KeLi.PdfSign.App.Components;

namespace KeLi.PdfSign.App.Forms
{
    public partial class PdfDesignerForm : Form
    {
        public PdfDesignerForm()
        {
            InitializeComponent();

            var meManager = new SignEventManager();

            meManager.RegistMouseEvent(pbSign1, pbPdfImg, this);
            meManager.RegistMouseEvent(pbSign2, pbPdfImg, this);
        }

        private void LblLoad_Click(object sender, System.EventArgs e)
        {

        }

        private void LblLast_Click(object sender, System.EventArgs e)
        {

        }

        private void LblNext_Click(object sender, System.EventArgs e)
        {

        }

        private void LblCapture_Click(object sender, System.EventArgs e)
        {

        }

        private void LblSave_Click(object sender, System.EventArgs e)
        {

        }
    }
}