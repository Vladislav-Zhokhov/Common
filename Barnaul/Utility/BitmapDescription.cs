using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPaint.Utility
{
    public class BitmapDescription
    {
        /// <summary>
        /// Image filename
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Image width (pixels）
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Image height (pixels）
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Image level DPI
        /// </summary>
        public double DPI_X { get; set; }
        /// <summary>
        /// Image level
        /// </summary>
        public double DPI_Y { get; set; }

        public BitmapDescription()
        {
            this.Name = "New image";
            this.Width = 800;
            this.Height = 600;
            this.DPI_X = 96;
            this.DPI_Y = 96;
        }
    }
}
