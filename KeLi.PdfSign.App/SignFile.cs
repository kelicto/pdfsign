using System.Collections.Generic;

namespace KeLi.PdfSign.App
{
    public class SignFile
    {
        public SignFile(string originalPath, string signedPath)
        {
            OriginalPath = originalPath;

            SignedPath = signedPath;
        }

        public string FileId { get; set; }

        public string PrjId { get; set; }

        public string BatchId { get; set; }

        public string UserId { get; set; }

        public string OriginalPath { get; set; }

        public string SignedPath { get; set; }

        public List<SignInfo> SignList { get; set; }

        public string UploadTime { get; set; }
    }
}