namespace System.Windows
{
    /// <summary>
    /// Расширение, добавляющее всем окнам обработчик нажатия на кнопку, закрывающий окно
    /// Сделан для удобства, чтобы не создавать его в каждом классе *.xaml.cs
    /// Использование: <Button Content="Закрыть" Click="Button_Close_Click" />
    /// </summary>
    public static class WindowCloseExtension
    {
        public static void Button_Close_Click(this Window window, object sender, RoutedEventArgs e)
        {
            window.Close();
        }
    }
}
