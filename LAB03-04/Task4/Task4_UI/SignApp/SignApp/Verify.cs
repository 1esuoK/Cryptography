using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SignApp
{
    public partial class Verify : Form
    {
        // P/Invoke declaration for the SignPdf function from the sig.dll
        [DllImport("ECC.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "verifySignature")]
        private static extern bool VerifyPdf(string privateKeyPath, string pdfPath, string signaturePath);
        public Verify()
        {
            InitializeComponent();
        }

        private void btnKeyPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdKey = new OpenFileDialog())
            {
                if (ofdKey.ShowDialog() == DialogResult.OK)
                {
                    // Example: Set the text of a text box to the selected file's path
                    txtPublicKey.Text = ofdKey.FileName;
                }
            }
        }

        private void btnPDFPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdPDF = new OpenFileDialog())
            {
                if (ofdPDF.ShowDialog() == DialogResult.OK)
                {
                    // Example: Set the text of a text box to the selected file's path
                    txtPDF.Text = ofdPDF.FileName;
                }
            }
        }

        private void btnSignaturePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdSig = new OpenFileDialog())
            {
                if (ofdSig.ShowDialog() == DialogResult.OK)
                {
                    // Example: Set the text of a text box to the selected file's path
                    txtSignature.Text = ofdSig.FileName;
                }
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            string publicKeyPath = txtPublicKey.Text;
            string pdfPath = txtPDF.Text;
            string signaturePath = txtSignature.Text;

            if (VerifyPdf(publicKeyPath, pdfPath, signaturePath))
            {
                MessageBox.Show("PDF verified successfully.");
            }
            else
            {
                MessageBox.Show("Failed to verify PDF.");
            }
        }
    }
}
