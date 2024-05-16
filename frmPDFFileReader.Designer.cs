
namespace ManagingClients
{
    partial class frmPDFFileReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPDFFileReader));
            this.axAcroPDFDocument = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDFDocument)).BeginInit();
            this.SuspendLayout();
            // 
            // axAcroPDFDocument
            // 
            this.axAcroPDFDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDFDocument.Enabled = true;
            this.axAcroPDFDocument.Location = new System.Drawing.Point(0, 0);
            this.axAcroPDFDocument.Name = "axAcroPDFDocument";
            this.axAcroPDFDocument.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDFDocument.OcxState")));
            this.axAcroPDFDocument.Size = new System.Drawing.Size(652, 824);
            this.axAcroPDFDocument.TabIndex = 0;
            // 
            // frmPDFFileReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 824);
            this.Controls.Add(this.axAcroPDFDocument);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPDFFileReader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết Tài Liệu ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPDFFileReader_FormClosing);
            this.Load += new System.EventHandler(this.frmPDFFileReader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDFDocument)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDFDocument;
    }
}