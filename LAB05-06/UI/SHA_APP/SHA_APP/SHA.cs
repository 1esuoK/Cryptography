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

namespace SHA_APP
{
    public partial class SHA : Form
    {
        [DllImport("SHA_DLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "hashFunc")]
        private static extern IntPtr HashFunc(string hashAlgo, string hashFile);

        [DllImport("SHA_DLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "clearArray")]
        private static extern void ClearArray(IntPtr p, int size);
        public SHA()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Example: Set the text of a text box to the selected file's path
                    txtFilePath.Text = ofd.FileName;
                }
            }
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            string hashAlgo = cbAlgo.Text.Trim();
            string hashFile = txtFilePath.Text;

            IntPtr result = HashFunc(hashAlgo, hashFile);
            string algoName = Marshal.PtrToStringAnsi(Marshal.ReadIntPtr(result));
            string digestSize = Marshal.PtrToStringAnsi(Marshal.ReadIntPtr(result + 1 * IntPtr.Size));
            string blockSize = Marshal.PtrToStringAnsi(Marshal.ReadIntPtr(result + 2 * IntPtr.Size));
            string digestValue = Marshal.PtrToStringAnsi(Marshal.ReadIntPtr(result + 3 * IntPtr.Size));

            ClearArray(result, 4);
            txtAlgoName.Text = algoName;
            txtBlockSize.Text = blockSize;
            txtDigestSize.Text = digestSize;
            txtDigestValue.Text = digestValue;
        }
    }
}
