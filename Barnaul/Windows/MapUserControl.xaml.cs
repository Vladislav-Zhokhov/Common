using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Barnaul.Windows
{
    public partial class MapUserControl : UserControl
    {
        bool isDown = false;
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


        private new void MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDown = true;
        }

        private new void MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDown = false;
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

        private void move(object sender, MouseEventArgs e)
            {
            if (isDown)
            {
                var w = Background.ActualWidth;
                var h = Background.ActualHeight;

                Background.Children.Clear();
                for (int x = ((int)Mouse.GetPosition(this).X / 5 % (Convert.ToInt32(combo.Text) / 2)); x < w; x += Convert.ToInt32(combo.Text) / 2)
                {
                    AddLineToBackground(x, 0, x, h);
                    AddNumberToBackground(x, x + Mouse.GetPosition(this).X / 5);
                }
                for (int y = ((int)Mouse.GetPosition(this).Y / 5 % (Convert.ToInt32(combo.Text) / 2)); y < h; y += Convert.ToInt32(combo.Text) / 2)
                {
                    AddLineToBackground(0, y, w, y);
                    AddNumber2ToBackground(y, y + Mouse.GetPosition(this).Y / 5);
                }
            }
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
                Background.Children.Add(imageControl);
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
                Background.Children.Add(imageControl);
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
