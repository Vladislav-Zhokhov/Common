using OpenPaint.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenPaint.Shapes;

namespace OpenPaint
{
    /// <summary>
    /// MainWindow.xaml The interaction logic
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private DrawingBoard CurrentDrawingBoard
        {
            get 
            {
                return (DrawingBoard)((TabItem)this.tabBoard.SelectedItem).Content;
            }
        }
        private DraggableBoard CurrentDraggableBoard
        {
            get
            {
                return (DraggableBoard)((TabItem)this.tabBoard.SelectedItem).Content;
            }
        }

        private void AddLayer_Click(object sender, RoutedEventArgs e)
        {
            //CurrentDrawingBoard.AddLayer();
            CurrentDraggableBoard.AddLayer();
        }

        private void DeleteLayer_Click(object sender, RoutedEventArgs e)
        {
            var index = this.layerList.SelectedIndex;
            //CurrentDrawingBoard.DeleteLayer((Layer)this.layerList.SelectedItem);
            CurrentDraggableBoard.DeleteLayer((Layer)this.layerList.SelectedItem);
            this.layerList.SelectedIndex = index == this.layerList.Items.Count ? index - 1 : index;
        }

        private void Debug_Click(object sender, RoutedEventArgs e)
        {
            //this.drawingBoard.Debug();
        }
        /// <summary>
        /// To TabControl add one TabItem and a drawinf board
        /// </summary>
        private void NewDrawingBoard(BitmapDescription bitmapDescription)
        {
            DrawingBoard drawingBoard = new DrawingBoard(bitmapDescription);
            // Creating data bindings for artboards
            Binding binding = new Binding();        // Current layer
            binding.Source = this.layerList;
            binding.Path = new PropertyPath("SelectedItem");
            drawingBoard.SetBinding(DrawingBoard.CurrentLayerProperty, binding);

            binding = new Binding();        // Painting mode
            binding.Source = this.toolList;
            binding.Path = new PropertyPath("SelectedItem");
            drawingBoard.SetBinding(DrawingBoard.DrawingModeProperty, binding);

            binding = new Binding();        // Painting colors
            binding.Source = this.colorPicker;
            binding.Path = new PropertyPath("SelectedColor");
            drawingBoard.SetBinding(DrawingBoard.ColorProperty, binding);

            binding = new Binding();        // Brush size
            binding.Source = this.penSize;
            binding.Path = new PropertyPath("Value");
            drawingBoard.SetBinding(DrawingBoard.PenThicknessProperty, binding);

            TabItem tabItem = new TabItem();
            tabItem.Header = bitmapDescription.Name;
            tabItem.Content = drawingBoard;

            this.tabBoard.Items.Add(tabItem);
            this.tabBoard.SelectedItem = tabItem;

            this.layerList.SelectedIndex = 0;
        }
        private void NewDraggableBoard(BitmapDescription bitmapDescription)
        {
            DraggableBoard draggableBoard = new DraggableBoard(bitmapDescription);
            // Creating data bindings for artboards
            Binding binding = new Binding();        // Current layer
            binding.Source = this.layerList;
            binding.Path = new PropertyPath("SelectedItem");
            draggableBoard.SetBinding(DraggableBoard.CurrentLayerProperty, binding);

            binding = new Binding();        // Painting mode
            binding.Source = this.toolList;
            binding.Path = new PropertyPath("SelectedItem");
            draggableBoard.SetBinding(DraggableBoard.DrawingModeProperty, binding);

            binding = new Binding();        // Painting colors
            binding.Source = this.colorPicker;
            binding.Path = new PropertyPath("SelectedColor");
            draggableBoard.SetBinding(DraggableBoard.ColorProperty, binding);

            binding = new Binding();        // Brush size
            binding.Source = this.penSize;
            binding.Path = new PropertyPath("Value");
            draggableBoard.SetBinding(DraggableBoard.PenThicknessProperty, binding);

            TabItem tabItem = new TabItem();
            tabItem.Header = bitmapDescription.Name;
            tabItem.Content = draggableBoard;

            this.tabBoard.Items.Add(tabItem);
            this.tabBoard.SelectedItem = tabItem;

            this.layerList.SelectedIndex = 0;
        }
        /// <summary>
        /// New file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            NewFileDialog dialog = new NewFileDialog();
            dialog.Owner = this;
            if (dialog.ShowDialog() == true)
            {
                //NewDrawingBoard(dialog.BitmapDescription);
                NewDraggableBoard(dialog.BitmapDescription);
            }
        }
        /// <summary>
        /// Opening the image file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string filename = BitmapHelper.Open();
            if (filename != null)
            {
                BitmapImage imgSource = BitmapHelper.GetBitmapImage(filename);
                // Create bitmap description information
                BitmapDescription bitmapDescription = new BitmapDescription();
                bitmapDescription.Name = filename;
                bitmapDescription.Width = imgSource.PixelWidth;
                bitmapDescription.Height = imgSource.PixelHeight;
                bitmapDescription.DPI_X = imgSource.DpiX;
                bitmapDescription.DPI_Y = imgSource.DpiY;
                // Creating a canvas
                NewDrawingBoard(bitmapDescription);
                // Draw an image to a layer on the canvas
                //CurrentDrawingBoard.AddBitmap(imgSource);
                CurrentDraggableBoard.AddBitmap(imgSource);
            }
        }
        /// <summary>
        ///  Save bitmap files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //var filename = CurrentDrawingBoard.Save();
            var filename = CurrentDraggableBoard.Save();
            if (filename != null)
                ((TabItem)tabBoard.SelectedItem).Header = filename;
        }
        /// <summary>
        /// Can I save a bitmap file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanSaveCommandExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            //e.CanExecute = (tabBoard.SelectedItem != null && CurrentDrawingBoard != null);
            e.CanExecute = (tabBoard.SelectedItem != null && CurrentDraggableBoard != null);
        }
        /// <summary>
        /// Save file as
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //CurrentDrawingBoard.SaveAs();
            CurrentDraggableBoard.SaveAs();
        }
        /// <summary>
        /// Can I save as
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanSaveAsCommandExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            //e.CanExecute = (tabBoard.SelectedItem != null && CurrentDrawingBoard != null);
            e.CanExecute = (tabBoard.SelectedItem != null && CurrentDraggableBoard != null);
        }
    }
}
