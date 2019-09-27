using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetworkTopology
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ellipse_DragLeave(object sender, DragEventArgs e)
        {
            MessageBox.Show("DragLeave event!");
        }

        private void Ellipse_DragEnter(object sender, DragEventArgs e)
        {
            MessageBox.Show("DragEnter event!");
        }

        private void Ellipse_DragOver(object sender, DragEventArgs e)
        {
            MessageBox.Show("DragOver event!");
        }

        private void Rectangle_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            Mouse.SetCursor(Cursors.No);
            e.Handled = true; //重要！ - 隐藏正常的拖放光标
        }

        private void DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Canvas.SetLeft(thumb1, Canvas.GetLeft(thumb1) + e.HorizontalChange);
            Canvas.SetTop(thumb1, Canvas.GetTop(thumb1) + e.VerticalChange);
        }

        private void DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            //thumb1.Background = Brushes.White;
        }

        private void DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            //thumb1.Background = Brushes.Red;
        }
    }
}
