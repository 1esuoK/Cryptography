using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.InteropServices;

namespace RSA
{
    public partial class Encrypt : Form
    {
        [DllImport("genkeyrsa.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "encryptRSA")]
        private static extern IntPtr EncryptRSA(string publicKeyPath, string plainPath, string cipherPath);

        [DllImport("genkeyrsa.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "freeCipherData")]
        private static extern void FreeCipherData(IntPtr p);
        public Encrypt()
        {
            InitializeComponent();
        }

        private void btnBrowseKey_Click(object sender, EventArgs e)
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

        private void btnBrowsePlain_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdPlain = new OpenFileDialog())
            {
                if (ofdPlain.ShowDialog() == DialogResult.OK)
                {
                    // Example: Set the text of a text box to the selected file's path
                    txtPlainPath.Text = ofdPlain.FileName;
                }
            }
        }

        private void btnBrowseCipher_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog ofdCipher = new SaveFileDialog())
            {
                // Configure the SaveFileDialog
                ofdCipher.Filter = "Signature files (*.txt)|*.txt|All files (*.*)|*.*";
                ofdCipher.Title = "Save CipherText File";

                // Show the SaveFileDialog
                if (ofdCipher.ShowDialog() == DialogResult.OK)
                {
                    // Set the TextBox text to the selected file path
                    txtCipherPath.Text = ofdCipher.FileName;
                }
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string publicKeyPath = txtPublicKey.Text;
            string plainPath = txtPlainPath.Text;
            string cipherPath = txtCipherPath.Text;
            IntPtr intptr = EncryptRSA(publicKeyPath, plainPath, cipherPath);
            string ciphertext = Marshal.PtrToStringAnsi(intptr);
            FreeCipherData(intptr);

            txtCipher.Text = ciphertext;
        }

        private void btnGoToDe_Click(object sender, EventArgs e)
        {
            Decrypt de = new Decrypt();
            de.Show();
        }
    }
}
