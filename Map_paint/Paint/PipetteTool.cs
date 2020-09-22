using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Paint
{
    public class PipetteTool: ToolsClass
    {
        public PipetteTool(PictureBox forma) : base(forma) { 
        

        }

        public override void Draw(List<TwoPoints> m_list, Point point1, Point point2, Graphics e)
        {
        
                var color = (forma.Image as Bitmap).GetPixel(point1.X, point1.Y);
                if (mouseDown == MouseButtons.Left) {
                    mainColor = color;
                }
                else if(mouseDown == MouseButtons.Right){
                    backColor = color;
                }
         
        }
    }
}
