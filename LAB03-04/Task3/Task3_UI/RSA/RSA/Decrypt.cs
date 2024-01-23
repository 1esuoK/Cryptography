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
    public partial class Decrypt : Form
    {
        [DllImport("genkeyrsa.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "decryptRSA")]
        private static extern IntPtr DecryptRSA(string privateKeyPath, string cipherPath, string plainPath);

        [DllImport("genkeyrsa.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "freeCipherData")]
        private static extern void FreeCipherData(IntPtr p);
        public Decrypt()
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
                    txtPrivateKey.Text = ofdKey.FileName;
                }
            }
        }

        private void btnBrowseCipher_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdPlain = new OpenFileDialog())
            {
                if (ofdPlain.ShowDialog() == DialogResult.OK)
                {
                    // Example: Set the text of a text box to the selected file's path
                    txtCipherPath.Text = ofdPlain.FileName;
                }
            }
        }

        private void btnBrowsePlain_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog ofdPlain = new SaveFileDialog())
            {
                // Configure the SaveFileDialog
                ofdPlain.Filter = "Signature files (*.txt)|*.txt|All files (*.*)|*.*";
                ofdPlain.Title = "Save PlainText File";

                // Show the SaveFileDialog
                if (ofdPlain.ShowDialog() == DialogResult.OK)
                {
                    // Set the TextBox text to the selected file path
                    txtPlainPath.Text = ofdPlain.FileName;
                }
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            String privateKeyPath = txtPrivateKey.Text;
            String cipherPath = txtCipherPath.Text;
            String plainPath = txtPlainPath.Text;
            IntPtr decrypted = DecryptRSA(privateKeyPath, cipherPath, plainPath);
            string plaintext = Marshal.PtrToStringAnsi(decrypted);
            FreeCipherData(decrypted);

            txtPlain.Text = plaintext;
        }
    }
}
