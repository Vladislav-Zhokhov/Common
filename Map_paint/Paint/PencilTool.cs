using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Paint
{
    public class PencilTool: ToolsClass
    {

        public PencilTool(PictureBox forma): base(forma) { 
           
        }

        public override void Draw(List<TwoPoints> m_list, Point point1, Point point2, Graphics e)
        {
            Pen m_pen = null;
            try
            {
                m_pen = new Pen(ToolsClass.MainPict, (float)SelectedValue);
                using (var graphics = Graphics.FromImage(forma.Image))
                {
                    m_pen.DashStyle = (DashStyle)SelectedItem;
                    graphics.DrawLine(m_pen, point1, point2);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                m_pen.Dispose();
            }
        
       }

     
    
    }
}
