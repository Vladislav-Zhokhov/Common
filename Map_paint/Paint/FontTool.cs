using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class FontTool : Form
    {
        public FontTool()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FontBox_DrawItem(object sender, DrawItemEventArgs e)
        {
           
            var fontFamily = (sender as ComboBox).Items[e.Index] as FontFamily;
            Font font ;
            SolidBrush brush = new SolidBrush(Color.Black);
            if (fontFamily != null)
            {
                if (fontFamily.IsStyleAvailable(FontStyle.Regular))
                {
                    font = new Font(fontFamily, 8.25f);

                }
                else {
                    font = new Font("Arial", 8.25f);
                }
                e.Graphics.DrawString(fontFamily.Name, font, brush, e.Bounds);
            }
            //fontFamily.Dispose();
            brush.Dispose();
           
        }

        private void FontTool_Load(object sender, EventArgs e)
        {
            using (var fontFamilies = new InstalledFontCollection())
            {

                foreach (var families in fontFamilies.Families)
                {
                    FontBox.Items.Add(families);
                }
            }
            FontBox.SelectedIndex = 6;
           
            
        }

        private void FontBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (sender as ComboBox).SelectedItem as FontFamily;
            ToolsClass.SelectedFont = item.Name;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


    }
}
