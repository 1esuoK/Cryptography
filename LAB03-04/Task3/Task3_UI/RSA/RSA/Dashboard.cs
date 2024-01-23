using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnKeyGenTab_Click(object sender, EventArgs e)
        {
            KeyGen keygen = new KeyGen();
            keygen.Show();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            Encrypt encrypt = new Encrypt();
            encrypt.Show();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            Decrypt decrypt = new Decrypt();
            decrypt.Show();
        }
    }
}
