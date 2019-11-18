﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Barnaul.Windows
{
    public partial class MapUserControl : UserControl
    {
        public MapUserControl()
        {
            InitializeComponent();
            UpdateBackPattern(null, null);
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

        

        void UpdateBackPattern(object sender, SizeChangedEventArgs e)
        {
            var w = Background.ActualWidth;
            var h = Background.ActualHeight;

            Background.Children.Clear();
            for (int x = 20; x < w; x += Convert.ToInt32(combo.Text) / 2)
            {
                AddLineToBackground(x, 0, x, h);
                AddNumberToBackground(x, x);
            }
            for (int y = 20; y < h; y += Convert.ToInt32(combo.Text) / 2)
            {
                AddLineToBackground(0, y, w, y);
                AddNumber2ToBackground(y, y);
            }
        }

        void AddLineToBackground(double x1, double y1, double x2, double y2)
        {
            var line = new Line()
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = Brushes.White,
                StrokeThickness = 1,
                SnapsToDevicePixels = true
            };
            line.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            Background.Children.Add(line);
        }
        void AddNumberToBackground(double x1, double i)
        {
            var text = new TextBlock
            {
                Margin = new Thickness(x1-5, 0, 0, 0),
                Text = i.ToString(),
                Foreground = Brushes.White
            };
            Background.Children.Add(text);
        }
        void AddNumber2ToBackground(double y1, double i)
        {
            var text = new TextBlock
            {
                Margin = new Thickness(0, y1-10, 0, 0),
                Text = i.ToString(),
                Foreground = Brushes.White
            };
            Background.Children.Add(text);

        }

        private void Combo_DropDownClosed(object sender, EventArgs e)
        {
            var w = Background.ActualWidth;
            var h = Background.ActualHeight;

            Background.Children.Clear();
            for (int x = 20; x < w; x += Convert.ToInt32(combo.Text) / 2)
            {
                AddLineToBackground(x, 0, x, h);
                AddNumberToBackground(x, x);
            }
            for (int y = 20; y < h; y += Convert.ToInt32(combo.Text) / 2)
            {
                AddLineToBackground(0, y, w, y);
                AddNumber2ToBackground(y, y);
            }
        }
    }
}
