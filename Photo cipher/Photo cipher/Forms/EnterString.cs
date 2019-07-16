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
    public partial class EnterString : Form
    {
        public string GetName => textBox1.Text;

        public EnterString(string name)
        {
            InitializeComponent();

            textBox1.Text = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(GetName))
                this.DialogResult = DialogResult.OK;
            else
                button1.ForeColor = Color.Red;
        }

        private void EnterString_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1_Click(null, null);
        }
    }
}
