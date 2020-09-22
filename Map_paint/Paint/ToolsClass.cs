using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public abstract class ToolsClass
    {
        protected PictureBox forma;
        protected ToolStrip toolBar;
        public static object SelectedItem { get; set; }
        public static int SelectedValue { get; set; }
        public static string strText { get; set; }
        public static string strTextPrev { get; set; }
        public static bool ShiftKey { get; set; }
        public static MouseButtons mouseDown = MouseButtons.None;
        public static Color mainColor { get; set; }
        public static Color backColor { get; set; }
        public static Color MainPict { get; set; }
        public static Color AnotherPict { get; set; }
        public static string SelectedFont = "Arial";
        

        public ToolsClass(PictureBox forma) {

            this.forma = forma;
        }

        //public abstract void Cursor();
        public abstract void Draw(List<TwoPoints> m_list, Point point1, Point point2, Graphics e = null);
 
    }
}
