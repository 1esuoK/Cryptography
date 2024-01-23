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

namespace RSA
{
    public partial class KeyGen : Form
    {
        [DllImport("genkeyrsa.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "genKey")]
        private static extern bool GenKey(string privateKeyPath, string publicKeyPathm, out IntPtr n, out IntPtr p, out IntPtr q, out IntPtr d, out IntPtr e);
        [DllImport("genkeyrsa.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "freeCipherData")]
        private static extern void FreeCipherData(IntPtr p);

        public KeyGen()
        {
            InitializeComponent();


        }


        private void btnBrowsePrKey_Click(object sender, EventArgs e)
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

        private void btnBrowsePuKey_Click(object sender, EventArgs e)
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

        private void btnKeyGen_Click(object sender, EventArgs e)
        {
            string publicKeyPath = txtPublicKey.Text;
            string privateKeyPath = txtPrivateKey.Text;
            IntPtr nPtr, pPtr, qPtr, dPtr, ePtr;

            bool isSuccess = GenKey(privateKeyPath, publicKeyPath, out nPtr, out pPtr, out qPtr, out dPtr, out ePtr);


            if (isSuccess)
            {
                string nStr = Marshal.PtrToStringAnsi(nPtr);
                string pStr = Marshal.PtrToStringAnsi(pPtr);
                string qStr = Marshal.PtrToStringAnsi(qPtr);
                string dStr = Marshal.PtrToStringAnsi(dPtr);
                string eStr = Marshal.PtrToStringAnsi(ePtr);

                txtModulus.Text = nStr;
                FreeCipherData(nPtr);
                txtPrime1.Text = pStr;
                FreeCipherData(pPtr);
                txtPrime2.Text = qStr;
                FreeCipherData(qPtr);
                txtPrEx.Text = dStr;
                FreeCipherData(dPtr);
                txtPuEx.Text = eStr;
                FreeCipherData(ePtr);



                MessageBox.Show("Key pair Generated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to generate key pair.");
            }
           
        }

        private void btnGoToEn_Click(object sender, EventArgs e)
        {
            Encrypt en = new Encrypt();
            en.Show();
        }

        private void lb1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Here is some more detailed help information.");
        }
    }
}
