using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_cipher.Forms
{
    partial class GetKey : Form
    {
        public GetKey()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length == 4)
                this.DialogResult = DialogResult.OK;
            else
                label1.ForeColor = Color.Red;
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                buttonOK_Click(buttonOK, null);
        }
    }
}
