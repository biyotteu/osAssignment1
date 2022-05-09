using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osAssignment1
{
    public partial class SettingForm : Form
    {        
        public int bufferSize, equCount;
        public SettingForm()
        {
            InitializeComponent();
        }

        private void buffSizeEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bufferSize = Int32.Parse(buffSizeEdit.Text);
            equCount = Int32.Parse(equCountEdit.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
