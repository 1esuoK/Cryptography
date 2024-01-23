using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignApp
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

        private void btnSignTab_Click(object sender, EventArgs e)
        {
            Sign sign = new Sign();
            sign.Show();
        }

        private void btnVerifyTab_Click(object sender, EventArgs e)
        {
            Verify verify = new Verify();
            verify.Show();
        }
    }
}
