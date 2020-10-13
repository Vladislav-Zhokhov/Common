using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenPaint.Shapes;

namespace Barnaul.Windows
{
    public partial class MapUserControl : UserControl
    {
        bool isDragging = false;
        bool isDrawing = false;
        bool initDrawing = false;
        const double gridSpace = 100.0;

        List<System.Windows.Shapes.Line> drewLines = new List<System.Windows.Shapes.Line>();
        List<System.Windows.Shapes.Rectangle> drewRectangles = new List<System.Windows.Shapes.Rectangle>();
        List<System.Windows.Shapes.Ellipse> drewEllipses = new List<System.Windows.Shapes.Ellipse>();

        DrawingMode drawingMode = DrawingMode.DragAndZoom;
        Point startPoint;
        Point currentPoint;

        Canvas gridLayer;
        Canvas drawingLayer;
        Canvas objectsLayer;

        public MapUserControl()
        {
            InitializeComponent();
            AddLayers();
        }

        void OnLoad(object sender, RoutedEventArgs e)
        {
            SetContentOffset();

            double zoom = Convert.ToInt32(combo.Text) / 120.0;
            Canvas canvas = zap.Content as Canvas;
            Point center = new Point(canvas.Width / 2.0, canvas.Height / 2.0);
            zap.ZoomAboutPoint(zoom, center);
        }

        private void AddLayers()
        {
            Canvas canvas = zap.Content as Canvas;
            double cw = canvas.Width;
            double ch = canvas.Height;

            gridLayer = new Canvas();
            drawingLayer = new Canvas();
            objectsLayer = new Canvas();

            gridLayer.Width = cw;
            gridLayer.Height = ch;
            gridLayer.Background = Brushes.Transparent;
            drawingLayer.Width = cw;
            drawingLayer.Height = ch;
            drawingLayer.Background = Brushes.Transparent;
            objectsLayer.Width = cw;
            objectsLayer.Height = ch;
            objectsLayer.Background = Brushes.Transparent;

            canvas.Children.Add(gridLayer);
            canvas.Children.Add(drawingLayer);
            canvas.Children.Add(objectsLayer);

            DrawGridLines(gridLayer);
        }

        private void SetContentOffset()
        {
            Canvas canvas = zap.Content as Canvas;
            double cw = canvas.Width;
            double ch = canvas.Height;
            double w = 800;     // Размеры самого окна
            double h = 450;

            zap.ContentOffsetX = (cw - w) / 2.0;
            zap.ContentOffsetY = (ch - h) / 2.0;
            //zap.ContentOffsetX = (cw - w) / (2.0 * zap.ContentScale);
            //zap.ContentOffsetY = (ch - h) / (2.0 * zap.ContentScale);
        }

        private void DrawGridLines(Canvas canvas)
        {
            double w = canvas.Width;
            double h = canvas.Height;

            for (double x = 0.0; x <= w; x += gridSpace)
            {
                var line = new System.Windows.Shapes.Line()
                {
                    X1 = x,
                    X2 = x,
                    Y1 = 0.0,
                    Y2 = h,
                    Stroke = Brushes.White,
                    StrokeThickness = 1
                };
                canvas.Children.Add(line);
            }
            for (double y = 0.0; y <= h; y += gridSpace)
            {
                var line = new System.Windows.Shapes.Line()
                {
                    X1 = 0.0,
                    X2 = w,
                    Y1 = y,
                    Y2 = y,
                    Stroke = Brushes.White,
                    StrokeThickness = 1
                };
                canvas.Children.Add(line);
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
                if (drawingMode != DrawingMode.None)
                {
                    isDrawing = true;
                    initDrawing = true;
                }
                
            }
            startPoint = e.GetPosition(zap.Content as Canvas);
        }

        private void zoomAndPanControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            isDrawing = false;
        }

        private void zoomAndPanControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point endPoint = e.GetPosition(zap.Content as Canvas);
                Vector dragOffset = endPoint - startPoint;
                zap.ContentOffsetX -= dragOffset.X;
                zap.ContentOffsetY -= dragOffset.Y;
            }
            else
            {
                if (isDrawing)
                {
                    switch (drawingMode)
                    {
                        case DrawingMode.Pen:
                            break;

                        case DrawingMode.Line:
                            if (initDrawing)
                            {
                                drewLines.Add(new System.Windows.Shapes.Line()
                                {
                                    X1 = startPoint.X,
                                    X2 = startPoint.X,
                                    Y1 = startPoint.Y,
                                    Y2 = startPoint.Y,
                                    Stroke = Brushes.MediumSpringGreen,
                                    StrokeThickness = 2
                                });
                                drawingLayer.Children.Add(drewLines[drewLines.Count - 1]);
                                initDrawing = false;
                            }
                            else
                            {
                                currentPoint = e.GetPosition(zap.Content as Canvas);
                                drewLines[drewLines.Count - 1].X2 = currentPoint.X;
                                drewLines[drewLines.Count - 1].Y2 = currentPoint.Y;
                            }
                            break;

                        case DrawingMode.Rectangle:
                            if (initDrawing)
                            {
                                drewRectangles.Add(new System.Windows.Shapes.Rectangle()
                                {
                                    Width = 0,
                                    Height = 0,
                                    Stroke = Brushes.MediumSpringGreen,
                                    StrokeThickness = 2
                                });
                                drawingLayer.Children.Add(drewRectangles[drewRectangles.Count - 1]);
                                Canvas.SetLeft(drewRectangles[drewRectangles.Count - 1], startPoint.X);
                                Canvas.SetTop(drewRectangles[drewRectangles.Count - 1], startPoint.Y);
                                initDrawing = false;
                            }
                            else
                            {
                                currentPoint = e.GetPosition(zap.Content as Canvas);
                                if (currentPoint.X < startPoint.X)
                                {
                                    Canvas.SetLeft(drewRectangles[drewRectangles.Count - 1], currentPoint.X);
                                }
                                if (currentPoint.Y < startPoint.Y)
                                {
                                    Canvas.SetTop(drewRectangles[drewRectangles.Count - 1], currentPoint.Y);
                                }
                                drewRectangles[drewRectangles.Count - 1].Width = Math.Abs(startPoint.X - currentPoint.X);
                                drewRectangles[drewRectangles.Count - 1].Height = Math.Abs(startPoint.Y - currentPoint.Y);
                            }
                            break;
                        
                        case DrawingMode.Ellipse:
                            if (initDrawing)
                            {
                                drewEllipses.Add(new System.Windows.Shapes.Ellipse()
                                {
                                    Width = 0,
                                    Height = 0,
                                    Stroke = Brushes.MediumSpringGreen,
                                    StrokeThickness = 2
                                });
                                drawingLayer.Children.Add(drewEllipses[drewEllipses.Count - 1]);
                                Canvas.SetLeft(drewEllipses[drewEllipses.Count - 1], startPoint.X);
                                Canvas.SetTop(drewEllipses[drewEllipses.Count - 1], startPoint.Y);
                                initDrawing = false;
                            }
                            else
                            {
                                currentPoint = e.GetPosition(zap.Content as Canvas);
                                if (currentPoint.X < startPoint.X)
                                {
                                    Canvas.SetLeft(drewEllipses[drewEllipses.Count - 1], currentPoint.X);
                                }
                                if (currentPoint.Y < startPoint.Y)
                                {
                                    Canvas.SetTop(drewEllipses[drewEllipses.Count - 1], currentPoint.Y);
                                }
                                drewEllipses[drewEllipses.Count - 1].Width = Math.Abs(startPoint.X - currentPoint.X);
                                drewEllipses[drewEllipses.Count - 1].Height = Math.Abs(startPoint.Y - currentPoint.Y);
                            }
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
        }
        private void PenClick(object sender, RoutedEventArgs e)
        {
            DragButton.IsChecked = false;
            PenButton.IsChecked = true;
            LineButton.IsChecked = false;
            RectButton.IsChecked = false;
            CircleButton.IsChecked = false;
            drawingMode = DrawingMode.Pen;
        }
        private void LineClick(object sender, RoutedEventArgs e)
        {
            DragButton.IsChecked = false;
            PenButton.IsChecked = false;
            LineButton.IsChecked = true;
            RectButton.IsChecked = false;
            CircleButton.IsChecked = false;
            drawingMode = DrawingMode.Line;
        }
        private void RectClick(object sender, RoutedEventArgs e)
        {
            DragButton.IsChecked = false;
            PenButton.IsChecked = false;
            LineButton.IsChecked = false;
            RectButton.IsChecked = true;
            CircleButton.IsChecked = false;
            drawingMode = DrawingMode.Rectangle;
        }
        private void CircleClick(object sender, RoutedEventArgs e)
        {
            DragButton.IsChecked = false;
            PenButton.IsChecked = false;
            LineButton.IsChecked = false;
            RectButton.IsChecked = false;
            CircleButton.IsChecked = true;
            drawingMode = DrawingMode.Ellipse;
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
            Point center = new Point((zap.Content as Canvas).ActualWidth / 2, (zap.Content as Canvas).ActualHeight / 2);
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
    }
}
