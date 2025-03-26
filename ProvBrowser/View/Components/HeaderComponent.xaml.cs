using ProvBrowser.View.Windows;
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

namespace ProvBrowser.View.Components
{
    /// <summary>
    /// Логика взаимодействия для Header.xaml
    /// </summary>
    public partial class HeaderComponent : UserControl
    {
        public Window ParentWindow { get; set; }
        public HeaderComponent()
        {
            InitializeComponent();
        }
        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                ParentWindow.DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (ParentWindow is MainWindow)
                Application.Current.Shutdown();
            ParentWindow.Close();


        }
        private void btnResize_Click(object sender, RoutedEventArgs e)
        {
            if(ParentWindow.WindowState == WindowState.Normal)
                ParentWindow.WindowState = WindowState.Maximized;
            else
                ParentWindow.WindowState = WindowState.Normal;
        }
        private void btnHide_Click(object sender, RoutedEventArgs e)
        {
            ParentWindow.WindowState = WindowState.Minimized;
        }
    }
}
