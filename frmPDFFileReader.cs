using AxAcroPDFLib;
using ManagingClients.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients
{
    public partial class frmPDFFileReader : Form
    {
        public frmPDFFileReader()
        {
            InitializeComponent();
        }

        //private static frmPDFFileReader _instance;
        //public static frmPDFFileReader Instance
        //{
        //    get
        //    {
        //        if (_instance == null) _instance = new frmPDFFileReader();
        //        return frmPDFFileReader._instance;
        //    }

        //    private set { frmPDFFileReader._instance = value; }
        //}

        protected byte[] FileNameByte;
        public virtual void SetFileNameByte(byte[] fileNameByte) => this.FileNameByte = fileNameByte;
        private void frmPDFFileReader_Load(object sender, EventArgs e)
        {
            this.ReadFileDocument();
        }


        protected virtual void ReadFileDocument()
        {
            // Lưu mảng byte thành một file tạm thời
            string tempFilePath = Path.GetTempFileName() + ".pdf";
            File.WriteAllBytes(tempFilePath, this.FileNameByte);

            // Tải file PDF từ file tạm thời vào axAcroPDF
            this.axAcroPDFDocument.LoadFile(tempFilePath);
            this.axAcroPDFDocument.setView("Fit");
            this.axAcroPDFDocument.setShowToolbar(false);
            this.axAcroPDFDocument.setShowScrollbars(true);

        }

        private void frmPDFFileReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.axAcroPDFDocument != null)
                {
                    this.Controls.Remove(this.axAcroPDFDocument);               
                }
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc xử lý tùy ý
                Console.WriteLine("Error disposing axAcroPDF1: " + ex.Message);
            }
        }
    }
}
