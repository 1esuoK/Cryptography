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
    public partial class KeyGen : Form
    {
        // P/Invoke declaration for the SignPdf function from the sig.dll
        [DllImport("ECC.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "genKey")]
        private static extern bool GenKey(string privateKeyPath, string publicKeyPath);
        public KeyGen()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            string publicKeyPath = txtPublicKey.Text;
            string privateKeyPath = txtPrivateKey.Text;

            if (GenKey(privateKeyPath, publicKeyPath))
            {
                MessageBox.Show("Key pair Generated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to generate key pair.");
            }
        }

        private void btnPrKeyPath_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog ofdPrKey = new SaveFileDialog())
            {
                // Configure the SaveFileDialog
                ofdPrKey.Filter = "Private Key (*.pem)|*.pem|All files (*.*)|*.*";
                ofdPrKey.Title = "Save Private Key File";

                // Show the SaveFileDialog
                if (ofdPrKey.ShowDialog() == DialogResult.OK)
                {
                    // Set the TextBox text to the selected file path
                    txtPrivateKey.Text = ofdPrKey.FileName;
                }
            }
        }

        private void btnPuKeyPath_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog ofdPuKey = new SaveFileDialog())
            {
                // Configure the SaveFileDialog
                ofdPuKey.Filter = "Public Key (*.pem)|*.pem|All files (*.*)|*.*";
                ofdPuKey.Title = "Save Public Key File";

                // Show the SaveFileDialog
                if (ofdPuKey.ShowDialog() == DialogResult.OK)
                {
                    // Set the TextBox text to the selected file path
                    txtPublicKey.Text = ofdPuKey.FileName;
                }
            }
        }
    }
}
