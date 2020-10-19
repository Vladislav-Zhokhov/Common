using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenPaint.Shapes;

namespace Barnaul.Windows
{
    public partial class MapUserControl : UserControl
    {
        bool isDragging = false;
        const double gridSpace = 100.0;

        DrawingMode drawingMode = DrawingMode.DragAndZoom;
        Point startPoint;

        OpenPaint.Canvas inkCanvas;
        OpenPaint.Layer gridLayer;
        OpenPaint.Layer drawingLayer;
        OpenPaint.Layer objectsLayer;

        Dictionary<string, Color> colors;
        Color color = Color.FromRgb(255, 255, 255);
        DrawingVisual shape = null;

        public MapUserControl()
        {
            colors = new Dictionary<string, Color>();
            colors.Add("Белый", Color.FromRgb(255, 255, 255));
            colors.Add("Красный", Color.FromRgb(255, 0, 0));
            colors.Add("Зелёный", Color.FromRgb(0, 255, 0));
            colors.Add("Синий", Color.FromRgb(0, 0, 255));
            colors.Add("Жёлтый", Color.FromRgb(255, 255, 0));

            inkCanvas = new OpenPaint.Canvas();

            InitializeComponent();

            var canvas = zap.Content as Canvas;
            inkCanvas.Width = canvas.Width;
            inkCanvas.Height = canvas.Height;
            inkCanvas.Background = Brushes.Black;
            zap.Content = inkCanvas;
            AddLayers();
        }

        void OnLoad(object sender, RoutedEventArgs e)
        {
            SetContentOffset();

            double zoom = Convert.ToInt32(combo.Text) / 120.0;

            Point center = new Point(inkCanvas.Width / 2.0, inkCanvas.Height / 2.0);
            zap.ZoomAboutPoint(zoom, center);
        }

        private void AddLayers()
        {
            double cw = inkCanvas.Width;
            double ch = inkCanvas.Height;

            gridLayer = new OpenPaint.Layer((int)cw, (int)ch);
            drawingLayer = new OpenPaint.Layer((int)cw, (int)ch);
            objectsLayer = new OpenPaint.Layer((int)cw, (int)ch);

            gridLayer.Width = cw;
            gridLayer.Height = ch;
            gridLayer.Background = Brushes.Transparent;
            drawingLayer.Width = cw;
            drawingLayer.Height = ch;
            drawingLayer.Background = Brushes.Transparent;
            objectsLayer.Width = cw;
            objectsLayer.Height = ch;
            objectsLayer.Background = Brushes.Transparent;

            inkCanvas.Children.Add(gridLayer);
            inkCanvas.Children.Add(drawingLayer);
            inkCanvas.Children.Add(objectsLayer);

            DrawGridLines(gridLayer);
        }

        private void SetContentOffset()
        {
            double cw = inkCanvas.Width;
            double ch = inkCanvas.Height;
            double w = 800;     // Размеры самого окна
            double h = 450;

            zap.ContentOffsetX = (cw - w) / 2.0;
            zap.ContentOffsetY = (ch - h) / 2.0;
        }

        private void DrawGridLines(OpenPaint.Layer layer)
        {
            double w = layer.Width;
            double h = layer.Height;

            DrawingVisual shape = new DrawingVisual();
            layer.AddVisual(shape);

            using (var dc = shape.RenderOpen())
            {
                Pen pen = new Pen(new SolidColorBrush(Color.FromRgb(255, 255, 255)), 1);
                for (double x = 0.0; x <= w; x += gridSpace)
                {
                    Point startPoint = new Point(x, 0);
                    Point endPoint = new Point(x, h);
                    dc.DrawLine(pen, startPoint, endPoint);
                }
                for (double y = 0.0; y <= h; y += gridSpace)
                {
                    Point startPoint = new Point(0, y);
                    Point endPoint = new Point(w, y);
                    dc.DrawLine(pen, startPoint, endPoint);
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ToggleButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void DragButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void zoomAndPanControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (drawingMode == DrawingMode.DragAndZoom)
                isDragging = true;
            else
            {
                shape = new DrawingVisual();
                drawingLayer.AddVisual(shape);
            }
            startPoint = e.GetPosition(inkCanvas);
        }

        private void zoomAndPanControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (drawingMode == DrawingMode.Pen)
            {
                InkPresenter inkPresenter = new InkPresenter();
                inkPresenter.Strokes = inkCanvas.Strokes;
                drawingLayer.AddUIElement(inkPresenter);
                // Re-create Stroke objects
                inkCanvas.Strokes = new StrokeCollection();
            }
            else
                shape = null;
            isDragging = false;
        }

        private void zoomAndPanControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point endPoint = e.GetPosition(inkCanvas);
                Vector dragOffset = endPoint - startPoint;
                zap.ContentOffsetX -= dragOffset.X;
                zap.ContentOffsetY -= dragOffset.Y;
            }
            else if (shape != null)
            {
                using (var dc = shape.RenderOpen())
                {
                    Pen pen = new Pen(new SolidColorBrush(color), 2.0);
                    Point endPoint = e.GetPosition(inkCanvas);
                    switch (drawingMode)
                    {
                        case DrawingMode.Line:
                            dc.DrawLine(pen, startPoint, endPoint);
                            break;
                        case DrawingMode.Rectangle:
                            dc.DrawRectangle(Brushes.Transparent, pen, new Rect(startPoint, endPoint));
                            break;
                        case DrawingMode.Ellipse:
                            Point centerPoint = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
                            dc.DrawEllipse(Brushes.Transparent, pen, centerPoint,
                                Math.Abs(startPoint.X - endPoint.X) / 2, Math.Abs(startPoint.Y - endPoint.Y) / 2);
                            break;
                    }
                }
            }
        }

        #region Select Modes

        private void DragClick(object sender, RoutedEventArgs e)
        {
            DragButton.IsChecked = true;
            PenButton.IsChecked = false;
            LineButton.IsChecked = false;
            RectButton.IsChecked = false;
            CircleButton.IsChecked = false;
            drawingMode = DrawingMode.DragAndZoom;
            inkCanvas.EditingMode = InkCanvasEditingMode.None;
        }
        private void PenClick(object sender, RoutedEventArgs e)
        {
            DragButton.IsChecked = false;
            PenButton.IsChecked = true;
            LineButton.IsChecked = false;
            RectButton.IsChecked = false;
            CircleButton.IsChecked = false;
            drawingMode = DrawingMode.Pen;
            inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void LineClick(object sender, RoutedEventArgs e)
        {
            DragButton.IsChecked = false;
            PenButton.IsChecked = false;
            LineButton.IsChecked = true;
            RectButton.IsChecked = false;
            CircleButton.IsChecked = false;
            drawingMode = DrawingMode.Line;
            inkCanvas.EditingMode = InkCanvasEditingMode.None;
        }
        private void RectClick(object sender, RoutedEventArgs e)
        {
            DragButton.IsChecked = false;
            PenButton.IsChecked = false;
            LineButton.IsChecked = false;
            RectButton.IsChecked = true;
            CircleButton.IsChecked = false;
            drawingMode = DrawingMode.Rectangle;
            inkCanvas.EditingMode = InkCanvasEditingMode.None;
        }
        private void CircleClick(object sender, RoutedEventArgs e)
        {
            DragButton.IsChecked = false;
            PenButton.IsChecked = false;
            LineButton.IsChecked = false;
            RectButton.IsChecked = false;
            CircleButton.IsChecked = true;
            drawingMode = DrawingMode.Ellipse;
            inkCanvas.EditingMode = InkCanvasEditingMode.None;
        }
        #endregion

        //void AddNumberToBackground(double x1, double i)
        //{
        //    var text = new TextBlock
        //    {
        //        Margin = new Thickness(x1-5, 0, 0, 0),
        //        Text = i.ToString(),
        //        Foreground = Brushes.White
        //    };
        //    Background.Children.Add(text);
        //}
        //void AddNumber2ToBackground(double y1, double i)
        //{
        //    var text = new TextBlock
        //    {
        //        Margin = new Thickness(0, y1-10, 0, 0),
        //        Text = i.ToString(),
        //        Foreground = Brushes.White
        //    };
        //    Background.Children.Add(text);

        //}

        private void Combo_DropDownClosed(object sender, EventArgs e)
        {
            double zoom = Convert.ToInt32(combo.Text) / 120.0;
            Point center = new Point(inkCanvas.ActualWidth / 2, inkCanvas.ActualHeight / 2);
            zap.ZoomAboutPoint(zoom, center);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int flag = -900;
            int flag1 = 0;
            int flag2 = 200;
            int flag3 = 0;
            int flag4 = 0;
            pov.Angle = 65.339;
            for (int i = 0; i < 8 & BR.IsChecked == true ; i++)
            {
                string pathImage = "../../Profile_picture_of_TehPlaneFreak.png";
                BitmapImage imageFile = new BitmapImage(new Uri(pathImage, UriKind.Relative));
                Image imageControl = new Image();
                imageControl.Source = imageFile;
                imageControl.Width = 70;
                imageControl.Height = 70;
                imageControl.Margin = new Thickness(100 + 40*i, 40*i, 0, 0);
                TransformGroup tr = new TransformGroup();
                SkewTransform sktr = new SkewTransform();
                RotateTransform rot = new RotateTransform();
                rot.Angle = 65.339;
                tr.Children.Add(sktr);
                tr.Children.Add(rot);
                imageControl.RenderTransform = tr;
                //Background.Children.Add(imageControl);
            }
            for (int i = 1; i < 8 & BR.IsChecked == true; i++)
            {
                string pathImage = "../../Profile_picture_of_TehPlaneFreak.png";
                BitmapImage imageFile = new BitmapImage(new Uri(pathImage, UriKind.Relative));
                Image imageControl = new Image();
                imageControl.Source = imageFile;
                imageControl.Width = 70;
                imageControl.Height = 70;
                imageControl.Margin = new Thickness(380 - 40 * i, 280 + 40 * i, 0, 0);
                TransformGroup tr = new TransformGroup();
                SkewTransform sktr = new SkewTransform();
                RotateTransform rot = new RotateTransform();
                rot.Angle = 65.339;
                tr.Children.Add(sktr);
                tr.Children.Add(rot);
                imageControl.RenderTransform = tr;
                //Background.Children.Add(imageControl);
            }
            for (int i = 0;i<100;i++)
            {
                await Task.Delay(1);
                pictureBox1.Margin = new Thickness(flag++, 0, 0, 0);
            }
            pictureBox2.Opacity = 100;
            for (int i = 0; i < 200; i++)
            {
                await Task.Delay(1);
                pictureBox1.Margin = new Thickness(flag++, 0, 0, 0);
                pictureBox2.Margin = new Thickness(flag3 -= 3, flag2--, 0, 0);
            }
            pictureBox2.Opacity = 0;
            for (int i = 0; i < 45; i++) {
                pov.Angle++;
                    }
            for (int i = 0; i < 500; pov.Angle++,i++)
            {
                await Task.Delay(1);
                pictureBox1.Margin = new Thickness(flag++, flag1--, 0, 0);
            }
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(1);
                pictureBox1.Margin = new Thickness(flag, flag1, 0, flag4--);
            }
        }

        private void ColorPicked(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cmi = ColorPicker.SelectedItem as ComboBoxItem;
            color = colors[cmi.Content as string];
            var drawingAttributes = inkCanvas.DefaultDrawingAttributes;
            drawingAttributes.Color = color;
        }
    }
}
