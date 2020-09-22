using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using OpenPaint.Collections;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Windows.Ink;
using OpenPaint.Shapes;

namespace OpenPaint
{
    using Sys = System.Windows.Controls;
    using System.Reflection;
    using OpenPaint.Utility;
    /// <summary>
    /// Drawing board,a drawing board can have many layers
    /// In fact, a drawing board corresponds to an image.
    /// </summary>
    class DrawingBoard : Label
    {
        // Canvas, layer container
        Canvas inkCanvas;

        /// <summary>
        /// Currently drawn graph
        /// </summary>
        DrawingVisual shape = null;

        /// <summary>
        /// Image description information corresponding to the artboard
        /// </summary>
        public Utility.BitmapDescription BitmapDescription { get; set; }

        /// <summary>
        /// The artboard has at least one layer
        /// </summary>
        public DrawingBoard(Utility.BitmapDescription bitmapDescription)
        {
            this.BitmapDescription = bitmapDescription;

            this.HorizontalContentAlignment = HorizontalAlignment.Center;
            this.VerticalContentAlignment = VerticalAlignment.Center;
            this.Background = new SolidColorBrush(Colors.Gray);

            inkCanvas = new Canvas();
            inkCanvas.Width = bitmapDescription.Width;
            inkCanvas.Height = bitmapDescription.Height;
            inkCanvas.Background = (Brush)FindResource("CheckerBrush");
            this.Content = inkCanvas;

            this.AddLayer();
        }

#region Layers
        /// <summary>
        /// Layer container, used to notify changes
        /// </summary>
        ObservableCollection<Layer> layers = new ObservableCollection<Layer>();
        public ObservableCollection<Layer> Layers { get { return layers; } }

        /// <summary>
        /// Add a layer
        /// </summary>
        public void AddLayer()
        {
            Layer layer = new Layer((int)inkCanvas.Width, (int)inkCanvas.Height);
            // The new layer is displayed on it,so it is inserted into the 0 position
            inkCanvas.Children.Add(layer);
            this.layers.Insert(0, layer);
        }

        internal void DeleteLayer(Layer layer)
        {
            // There must be at least 1 layer
            if (this.layers.Count > 1)
            {
                inkCanvas.Children.Remove(layer);
                this.layers.Remove(layer);
            }
        }
        #endregion

        #region Layer related events

        Point startPoint;
        /// <summary>
        /// Create graphics when the Left Mouse Button is pressed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Only rule graphics are created DrawingVisual Objects
            if ((int)DrawingMode >= (int)Shapes.DrawingMode.Line)
            {
                // Create specific instances with reflection
                shape = new DrawingVisual();
                // Add to layer
                CurrentLayer.AddVisual(shape);

                startPoint = e.GetPosition(inkCanvas);
            }
        }

        /// <summary>
        /// Re-render the graphics as the mouse moves
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (shape != null)
            {
                using (var dc = shape.RenderOpen())
                {
                    Pen pen = new Pen(new SolidColorBrush(Color), PenThickness);
                    Point endPoint = e.GetPosition(inkCanvas);
                    switch (DrawingMode)
                    {
                        case Shapes.DrawingMode.Line:
                            dc.DrawLine(pen, startPoint, endPoint);
                            break;
                        case Shapes.DrawingMode.Rectangle:
                            dc.DrawRectangle(Brushes.Transparent, pen, new Rect(startPoint, endPoint));
                            break;
                        case Shapes.DrawingMode.Ellipse:
                            Point centerPoint = new Point((startPoint.X + endPoint.X)/2, (startPoint.Y + endPoint.Y)/2);
                            dc.DrawEllipse(Brushes.Transparent, pen, centerPoint,
                                Math.Abs(startPoint.X - endPoint.X)/2, Math.Abs(startPoint.Y - endPoint.Y) / 2);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// When the mouse is released, the drawing is completed once, moving the drawing to the current layer
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);

            // If it is not a regular graph, you need to add it to the layer
            if (DrawingMode == Shapes.DrawingMode.Pen)
            {
                InkPresenter inkPresenter = new InkPresenter();
                inkPresenter.Strokes = inkCanvas.Strokes;
                CurrentLayer.AddUIElement(inkPresenter);
                // Re-create Stroke objects
                inkCanvas.Strokes = new StrokeCollection();
            }
            else
                shape = null;
        }

        public void Debug()
        {
            
        }

        #endregion

        /// <summary>
        /// Painting mode
        /// </summary>
        public DrawingMode DrawingMode
        {
            get { return (DrawingMode)GetValue(DrawingModeProperty); }
            set { SetValue(DrawingModeProperty, value); }
        }

        public static readonly DependencyProperty DrawingModeProperty =
            DependencyProperty.Register("DrawingMode", typeof(DrawingMode), typeof(DrawingBoard),
            new PropertyMetadata((DrawingMode)0, new PropertyChangedCallback(DrawingModePropertyChanged)));

        private static void DrawingModePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DrawingMode drawingMode = (DrawingMode)e.NewValue;
            var drawingBoard = d as DrawingBoard;
            // Draw rule graphics
            if (drawingMode != DrawingMode.Pen)
                drawingBoard.inkCanvas.EditingMode = InkCanvasEditingMode.None;
            else
            {
                // Set painting mode
                drawingBoard.inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            }
        }

        /// <summary>
        /// Current layer
        /// </summary>
        public Layer CurrentLayer
        {
            get { return (Layer)GetValue(CurrentLayerProperty); }
            set { SetValue(CurrentLayerProperty, value); }
        }

        public static readonly DependencyProperty CurrentLayerProperty =
            DependencyProperty.Register("CurrentLayer", typeof(Layer), typeof(DrawingBoard),
            new PropertyMetadata(null));


        /// <summary>
        /// Painting colors
        /// </summary>
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Color), typeof(DrawingBoard),
            new PropertyMetadata(Colors.Black, new PropertyChangedCallback(ColorPropertyChanged)));

        private static void ColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var drawingBoard = d as DrawingBoard;
            var drawingAttributes = drawingBoard.inkCanvas.DefaultDrawingAttributes;
            drawingAttributes.Color = drawingBoard.Color;
        }


        /// <summary>
        /// Brush size
        /// </summary>
        public double PenThickness
        {
            get { return (double)GetValue(PenThicknessProperty); }
            set { SetValue(PenThicknessProperty, value); }
        }

        public static readonly DependencyProperty PenThicknessProperty =
            DependencyProperty.Register("PenThickness", typeof(double), typeof(DrawingBoard),
            new PropertyMetadata(1.0, new PropertyChangedCallback(PenThicknessPropertyChanged)));

        private static void PenThicknessPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var drawingBoard = d as DrawingBoard;
            var drawingAttributes = drawingBoard.inkCanvas.DefaultDrawingAttributes;
            drawingAttributes.Width = drawingAttributes.Height = drawingBoard.PenThickness;
        }

        public void AddBitmap(BitmapSource image)
        {
            DrawingVisual visual = new DrawingVisual();
            using (var dc = visual.RenderOpen())
            {
                dc.DrawImage(image, new Rect(0, 0, image.PixelWidth, image.PixelHeight));
            }
            CurrentLayer.AddVisual(visual);
        }

        /// <summary>
        /// Get the image on the artboard
        /// </summary>
        /// <returns></returns>
        internal BitmapSource ToBitmap()
        {
            var bmpDesc = this.BitmapDescription;
            var bitmap = new RenderTargetBitmap(bmpDesc.Width, bmpDesc.Height, bmpDesc.DPI_X, bmpDesc.DPI_Y, PixelFormats.Default);
            bitmap.Render(this.inkCanvas);
            return bitmap;
        }

        internal void SetFileName(string filename)
        {
            this.BitmapDescription.Name = filename;
        }
        /// <summary>
        /// Save the image, return the image file name
        /// </summary>
        internal string Save()
        {
            // According to the document name to determine whether there is the file,
            //  if there is a direct overwrite,no pop-up Save dialog box
            var bmpDesc = BitmapDescription;
            if (System.IO.File.Exists(bmpDesc.Name))
                BitmapHelper.Save(ToBitmap(), bmpDesc.Name);
            else
                bmpDesc.Name = BitmapHelper.SaveAs(ToBitmap(), bmpDesc.Name);
            return bmpDesc.Name;
        }
        /// <summary>
        /// Save image as
        /// </summary>
        internal void SaveAs()
        {
            BitmapHelper.SaveAs(ToBitmap(), BitmapDescription.Name);
        }
    }
}
