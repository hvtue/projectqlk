using qlkho.Viewmodels;
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

namespace qlkho
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext =new  vmmain();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (listmenu.Visibility == Visibility.Visible)
                listmenu.Visibility = Visibility.Collapsed;
            else
                listmenu.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            listmenu.IsEnabled = false;
            this.grmain.Content = null;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.listmenu.IsEnabled = true;
            this.grmain.Content= null;
            this.grmain.Visibility = Visibility.Visible;
            this.txt.Text = string.Empty;
        }
    }
}