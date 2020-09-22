using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPaint.Shapes
{

    public enum DrawingMode
    {
        None = 0,
        Pen,        // Соответствующие чернила
        //GestureOnly,
        //InkAndGesture,
        //Select,
        //EraseByPoint,
        //EraseByStroke,


        /// <summary>
        /// Draw straight lines
        /// </summary>
        Line,
        /// <summary>
        /// Draw rectangles
        /// </summary>
        Rectangle,
        /// <summary>
        /// Draw ellipses
        /// </summary>
        Ellipse
    }
}
