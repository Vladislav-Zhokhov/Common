using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Paint
{
    public class RectangleTool: ToolsClass
    {
        public RectangleTool(PictureBox forma) : base(forma) { 
        
        }

        public override void Draw(List<TwoPoints> m_list, Point point1, Point point2, Graphics grph)
        {
            Pen m_pen = null;
            try
            {
                m_pen = new Pen(ToolsClass.MainPict, (float)SelectedValue);
                m_pen.DashStyle = (DashStyle)SelectedItem;
                if (!BitmapForma.can_write)
                    using (var graphics = Graphics.FromImage(forma.Image))
                    {
                        foreach (TwoPoints tp in m_list)
                        {

                            graphics.DrawRectangle(m_pen, tp.point1.X, tp.point1.Y, tp.point2.X, tp.point2.Y);

                        }

                        graphics.DrawRectangle(m_pen, point1.X, point1.Y, point2.X, point2.Y);
                    }
                else
                {

                    foreach (TwoPoints tp in m_list)
                    {

                        grph.DrawRectangle(m_pen, tp.point1.X, tp.point1.Y, tp.point2.X, tp.point2.Y);

                    }

                    grph.DrawRectangle(m_pen, point1.X, point1.Y, point2.X, point2.Y);

                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                m_pen.Dispose();
            }
        }
    }
}
