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
    public struct TwoPoints
    {
        public Point point1;
        public Point point2;
        public TwoPoints(Point point1, Point point2)
        {

            this.point1 = point1;
            this.point2 = point2;
        }
    } 
    public partial class BitmapForma : Form
    {
        private Bitmap image;
        private Point startpoint;
        private Point endpoint;
        public static bool can_write = false;
        private List<TwoPoints> m_list;
        private string str = string.Empty;
        private Caret m_caret = new Caret();
        private int m_locationX = 0;
        private int m_locationY = 0;
        
        public BitmapForma()
        {
            InitializeComponent();
        }

        public Image m_Image
        {

            get
            {

                return pictureBox.Image;
            }
            set
            {

                pictureBox.Image = value;
            }
        }
        public ToolsClass tool { get; set; }

        private void BitmapForma_Load(object sender, EventArgs e)
        {
            m_list = new List<TwoPoints>();
            image = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (var graphics = Graphics.FromImage(image))
            {

                graphics.Clear(Color.White);
            }

            pictureBox.Image = image;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (tool is TexTTool)
            {

                pictureBox.Focus();
                m_caret = new Caret(pictureBox, new Point(e.X, e.Y), ToolsClass.SelectedValue);
                m_locationX = e.X;
                m_locationY = e.Y;
                ToolsClass.strText = "";
                ToolsClass.strTextPrev = "";
                
            }
            else
            {
               if(m_caret.Visible)
                   m_caret.Hide();
               if (e.Button == MouseButtons.Left)
               {
                    m_list.Clear();
                    can_write = true;
                    startpoint = e.Location;
                    pictureBox.Paint += OnPaint;
                   
                }

               if (tool is PipetteTool) {

                   ToolsClass.mouseDown = e.Button;
                   startpoint = e.Location;
                   tool.Draw(m_list, startpoint, endpoint);
               }
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
   
            if (tool is LineTool || tool is RectangleTool || tool is EllipseTool)
            {
             
                if (can_write)
                {
                    
                    endpoint = e.Location;
                    //tool.Draw(m_list, startpoint, endpoint);
                    pictureBox.Invalidate();
                }
           
            }
           else if (!(tool is TexTTool)&& !(tool is PipetteTool))
             {
                if (can_write)
                {
                    endpoint = e.Location;
                    try
                    {
                        tool.Draw(m_list, startpoint, endpoint);
                        startpoint = e.Location;
                    }
                    catch
                    {

                    }
                    pictureBox.Invalidate();
                }
            }
           

        }
     
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!(tool is TexTTool) && !(tool is PipetteTool))
            {
                try
                {
                    pictureBox.Paint -= OnPaint;
                    can_write = false;
                    m_list.Add(new TwoPoints(startpoint, endpoint));
                    tool.Draw(m_list, startpoint, endpoint);
                    pictureBox.Invalidate();
                }
                catch { 
                
                }
            }
        }

        private void BitmapForma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tool is TexTTool)
            {
               
                switch (e.KeyChar) 
                { 
                    case '\b':
                        if (ToolsClass.strText.Length > 0) {

                            ToolsClass.strText = ToolsClass.strText.Substring(0, ToolsClass.strText.Length - 1);
                            tool.Draw(m_list, new Point(m_locationX, m_locationY), new Point(0, 0));
                            pictureBox.Invalidate();
                            ToolsClass.strTextPrev = ToolsClass.strText;
                        }
                           
                        break;
                   default:
                 
                m_caret.Hide();

                   var item = e.KeyChar;
                   str = Convert.ToString(item);
                if (ToolsClass.ShiftKey == true)
                      str = str.ToUpper();
                 ToolsClass.strText += str;
                 ToolsClass.strTextPrev += str;
                 tool.Draw(m_list, new Point(m_locationX, m_locationY), new Point(0, 0));
                 pictureBox.Invalidate();
                 
                        break;
                }
                CaretPosition();
                m_caret.Show();
               
                
            }
     
          }

        private void BitmapForma_KeyDown(object sender, KeyEventArgs e)
        {
            ToolsClass.ShiftKey = e.Shift;
        }
        protected void CaretPosition() { 
           
            Font font = new System.Drawing.Font("Arial", (pictureBox as Control).Font.Height);
            Graphics grfx = CreateGraphics();
            string str = (ToolsClass.strTextPrev + "а").Substring(0,  (ToolsClass.strTextPrev + "а").Length);
            StringFormat strfmt = StringFormat.GenericTypographic;
            strfmt.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            SizeF sizef = grfx.MeasureString(str, font, Point.Empty, strfmt);
            m_caret.Position = new Point(m_locationX + (int)sizef.Width, m_locationY);
            grfx.Dispose ();
            font.Dispose();
        }



        private void OnPaint(object sender, PaintEventArgs e)
        {
            try
            {
           
                tool.Draw(m_list, startpoint, endpoint, e.Graphics);
            }
            catch
            {
                
            }
        }
  
 }
}
