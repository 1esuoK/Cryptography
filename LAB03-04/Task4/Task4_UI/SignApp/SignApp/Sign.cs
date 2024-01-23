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
    public partial class Sign : Form
    {
        // P/Invoke declaration for the SignPdf function from the sig.dll
        [DllImport("ECC.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "signPdf")]
        private static extern bool SignPdf(string privateKeyPath, string pdfPath, string signaturePath);
        public Sign()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            string privateKeyPath = txtPrivateKey.Text;
            string pdfPath = txtPDF.Text;
            string signaturePath = txtSignature.Text;

            if (SignPdf(privateKeyPath, pdfPath, signaturePath))
            {
                MessageBox.Show("PDF signed successfully.");
            }
            else
            {
                MessageBox.Show("Failed to sign PDF.");
            }
        }

        private void btnKeyPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdKey = new OpenFileDialog())
            {
                if (ofdKey.ShowDialog() == DialogResult.OK)
                {
                    // Example: Set the text of a text box to the selected file's path
                    txtPrivateKey.Text = ofdKey.FileName;
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
            // Configure the SaveFileDialog
            sfdSignature.Filter = "Signature files (*.sig)|*.sig|All files (*.*)|*.*";
            sfdSignature.Title = "Save Signature File";

            // Show the SaveFileDialog
            if (sfdSignature.ShowDialog() == DialogResult.OK)
            {
                // Set the TextBox text to the selected file path
                txtSignature.Text = sfdSignature.FileName;
            }
        }
    }
}
