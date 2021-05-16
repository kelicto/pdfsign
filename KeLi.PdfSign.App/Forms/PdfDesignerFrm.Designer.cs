namespace KeLi.PdfSign.App.Forms
{
    partial class PdfDesignerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbSign1 = new System.Windows.Forms.PictureBox();
            this.pbPdfImg = new System.Windows.Forms.PictureBox();
            this.pbSign2 = new System.Windows.Forms.PictureBox();
            this.lblCapture = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.lblPageIndex = new System.Windows.Forms.Label();
            this.lblNext = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.lblLoad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSign1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPdfImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSign2)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSign1
            // 
            this.pbSign1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSign1.BackColor = System.Drawing.Color.Maroon;
            this.pbSign1.Location = new System.Drawing.Point(809, 119);
            this.pbSign1.Name = "pbSign1";
            this.pbSign1.Size = new System.Drawing.Size(80, 38);
            this.pbSign1.TabIndex = 0;
            this.pbSign1.TabStop = false;
            // 
            // pbPdfImg
            // 
            this.pbPdfImg.BackColor = System.Drawing.Color.Transparent;
            this.pbPdfImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPdfImg.Location = new System.Drawing.Point(0, 0);
            this.pbPdfImg.Name = "pbPdfImg";
            this.pbPdfImg.Size = new System.Drawing.Size(901, 594);
            this.pbPdfImg.TabIndex = 1;
            this.pbPdfImg.TabStop = false;
            // 
            // pbSign2
            // 
            this.pbSign2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSign2.BackColor = System.Drawing.Color.SlateBlue;
            this.pbSign2.Location = new System.Drawing.Point(809, 257);
            this.pbSign2.Name = "pbSign2";
            this.pbSign2.Size = new System.Drawing.Size(80, 38);
            this.pbSign2.TabIndex = 2;
            this.pbSign2.TabStop = false;
            // 
            // lblCapture
            // 
            this.lblCapture.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCapture.BackColor = System.Drawing.Color.Transparent;
            this.lblCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCapture.ForeColor = System.Drawing.Color.Black;
            this.lblCapture.Location = new System.Drawing.Point(536, 562);
            this.lblCapture.Name = "lblCapture";
            this.lblCapture.Size = new System.Drawing.Size(70, 23);
            this.lblCapture.TabIndex = 3;
            this.lblCapture.Text = "Capture";
            this.lblCapture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCapture.Click += new System.EventHandler(this.LblCapture_Click);
            // 
            // lblLast
            // 
            this.lblLast.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLast.BackColor = System.Drawing.Color.Transparent;
            this.lblLast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLast.ForeColor = System.Drawing.Color.Black;
            this.lblLast.Location = new System.Drawing.Point(340, 562);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(30, 23);
            this.lblLast.TabIndex = 3;
            this.lblLast.Text = "<";
            this.lblLast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLast.Click += new System.EventHandler(this.LblLast_Click);
            // 
            // lblPageIndex
            // 
            this.lblPageIndex.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPageIndex.BackColor = System.Drawing.Color.Transparent;
            this.lblPageIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPageIndex.ForeColor = System.Drawing.Color.Black;
            this.lblPageIndex.Location = new System.Drawing.Point(376, 562);
            this.lblPageIndex.Name = "lblPageIndex";
            this.lblPageIndex.Size = new System.Drawing.Size(70, 23);
            this.lblPageIndex.TabIndex = 3;
            this.lblPageIndex.Text = "1/100";
            this.lblPageIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNext
            // 
            this.lblNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblNext.BackColor = System.Drawing.Color.Transparent;
            this.lblNext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNext.ForeColor = System.Drawing.Color.Black;
            this.lblNext.Location = new System.Drawing.Point(452, 562);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(30, 23);
            this.lblNext.TabIndex = 3;
            this.lblNext.Text = ">";
            this.lblNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNext.Click += new System.EventHandler(this.LblNext_Click);
            // 
            // lblSave
            // 
            this.lblSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSave.BackColor = System.Drawing.Color.Transparent;
            this.lblSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSave.ForeColor = System.Drawing.Color.Black;
            this.lblSave.Location = new System.Drawing.Point(612, 562);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(70, 23);
            this.lblSave.TabIndex = 3;
            this.lblSave.Text = "Save";
            this.lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSave.Click += new System.EventHandler(this.LblSave_Click);
            // 
            // lblLoad
            // 
            this.lblLoad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLoad.BackColor = System.Drawing.Color.Transparent;
            this.lblLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoad.ForeColor = System.Drawing.Color.Black;
            this.lblLoad.Location = new System.Drawing.Point(12, 562);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(70, 23);
            this.lblLoad.TabIndex = 4;
            this.lblLoad.Text = "Load";
            this.lblLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLoad.Click += new System.EventHandler(this.LblLoad_Click);
            // 
            // PdfDesignerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 594);
            this.Controls.Add(this.lblLoad);
            this.Controls.Add(this.lblSave);
            this.Controls.Add(this.lblNext);
            this.Controls.Add(this.lblPageIndex);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.lblCapture);
            this.Controls.Add(this.pbSign2);
            this.Controls.Add(this.pbSign1);
            this.Controls.Add(this.pbPdfImg);
            this.Name = "PdfDesignerForm";
            this.Text = "Pdf Designer";
            ((System.ComponentModel.ISupportInitialize)(this.pbSign1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPdfImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSign2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSign1;
        private System.Windows.Forms.PictureBox pbPdfImg;
        private System.Windows.Forms.PictureBox pbSign2;
        private System.Windows.Forms.Label lblCapture;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblPageIndex;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Label lblLoad;
    }
}

