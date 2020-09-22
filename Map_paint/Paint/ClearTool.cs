using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Paint
{
    public class ClearTool: ToolsClass
    {
        public ClearTool(PictureBox forma): base(forma) { 
        
        }

     

        public override void Draw(List<TwoPoints> m_list, Point point1, Point point2, Graphics e)
        {
            using(var graphics = Graphics.FromImage(forma.Image)){

                graphics.Clear(Color.White);
            }
        }
    }
}
