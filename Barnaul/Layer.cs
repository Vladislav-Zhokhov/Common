using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace OpenPaint
{
    /// <summary>
    /// Layers,each layer can hold several graphics（Drawing）
    /// </summary>
    class Layer : System.Windows.Controls.Canvas
    {
        /// <summary>
        /// Layer counter, used to name the layer
        /// </summary>
        static int LayerCount = 1;
        /// <summary>
        /// Visual element container
        /// </summary>
        private List<Visual> visuals;
        public Layer(int width, int height)
        {
            this.visuals = new List<Visual>();

            this.Background = Brushes.Transparent;
            this.Tag = "New layer " + LayerCount++;
            this.Width = width;
            this.Height = height;
        }

        protected override int VisualChildrenCount
        {
            get
            {
                return visuals.Count;
            }
        }
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= visuals.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return visuals[index];
        }
        public Visual Get()
        {
            return visuals[0];
        }
        public void AddVisual(Visual visual)
        {
            visuals.Add(visual);

            base.AddVisualChild(visual);
            base.AddLogicalChild(visual);
        }

        public void AddUIElement(UIElement uiElement)
        {
            visuals.Add(uiElement);

            base.Children.Add(uiElement);
        }
        public void DeleteVisual(Visual visual)
        {
            visuals.Remove(visual);

            base.RemoveVisualChild(visual);
            base.RemoveLogicalChild(visual);
        }
        /// <summary>
        /// Get the corresponding visual object based on the point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public DrawingVisual GetVisual(Point point)
        {
            HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
            return hitResult.VisualHit as DrawingVisual;
        }

        private List<DrawingVisual> hits = new List<DrawingVisual>();
        public List<DrawingVisual> GetVisuals(Geometry region)
        {
            // Remove mathches from the previous search.
            hits.Clear();

            // Prepare the parameters fro the hit test operation
            // (the geometry and callback).
            GeometryHitTestParameters parameters = new GeometryHitTestParameters(region);
            HitTestResultCallback callback = new HitTestResultCallback(this.HitTestCallback);

            // Search for hits.
            VisualTreeHelper.HitTest(this, null, callback, parameters);
            return hits;
        }

        private HitTestResultBehavior HitTestCallback(HitTestResult result)
        {
            GeometryHitTestResult geometryResult = (GeometryHitTestResult)result;
            DrawingVisual visual = result.VisualHit as DrawingVisual;
            // Only include matches that are DrawingVisual objects and
            // that are completely inside the geometry.
            if (visual != null && geometryResult.IntersectionDetail == IntersectionDetail.FullyInside)
            {
                hits.Add(visual);
            }
            return HitTestResultBehavior.Continue;
        }
    }
}
