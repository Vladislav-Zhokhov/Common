using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class ChangeSizeForma : Form
    {
        public ChangeSizeForma(int width, int height)
        {
            InitializeComponent();
            numericUpDown1.Value = width;
            numericUpDown2.Value = height;
        }
        public int SizeHeight {get; set;}
        public int SizeWidth { get; set;}

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            SizeHeight = (int)numericUpDown2.Value;
            SizeWidth = (int)numericUpDown1.Value;
        }
    }
}
