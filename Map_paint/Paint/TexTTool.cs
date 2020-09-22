using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Paint
{
    public class TexTTool: ToolsClass
    {
        public TexTTool(PictureBox forma) : base(forma) { 
        
        }
  
        public override void Draw(List<TwoPoints> m_list, Point point1, Point point2, Graphics e)
        {
            SolidBrush brushwhite = new SolidBrush(Color.White);
            SolidBrush brushblack = new SolidBrush(ToolsClass.MainPict);
            Font font = new Font(ToolsClass.SelectedFont, (float)SelectedValue); 
            using(var graphics = Graphics.FromImage(forma.Image)){

                graphics.FillRectangle(brushwhite, new RectangleF(point1, graphics.MeasureString(strTextPrev + "a", font, Point.Empty, StringFormat.GenericTypographic)));
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                graphics.DrawString(strText, font, brushblack, point1);
              
            }
        

            brushwhite.Dispose();
            brushblack.Dispose();
            font.Dispose();
        }
    }
}
