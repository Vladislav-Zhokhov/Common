using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Paint
{
    public class EraserTool: ToolsClass
    {
        public EraserTool(PictureBox forma) : base(forma) { 
        
        }

        public override void Draw(List<TwoPoints> m_list, Point point1, Point point2, Graphics e)
        {
                 Pen pen = new Pen(AnotherPict, (float)SelectedValue);
                 using (var graphics = Graphics.FromImage(forma.Image))
                 {

                     graphics.DrawLine(pen, point1, point2);
                     
                 }
                 pen.Dispose();
        }
    }
}
