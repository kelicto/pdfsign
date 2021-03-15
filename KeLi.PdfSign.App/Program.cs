using System;
using System.Windows.Forms;

namespace KeLi.PdfSign.App
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PdfDesignerForm());
        }
    }
}