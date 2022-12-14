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
using System.Windows.Shapes;

namespace Manaview
{
    /// <summary>
    /// TitleBarView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TitleBarView : UserControl
    {
        public TitleBarView()
        {
            InitializeComponent();
            btnMax.Click += BtnMax_Click;
            btnRestore.Click += BtnRestore_Click;
            btnMin.Click += BtnMin_Click;
            //btnClose.Click += BtnClose_Click;
            Application.Current.MainWindow.StateChanged += MainWindow_StateChanged;

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            //Environment.Exit(0);
            Application.Current.Shutdown();
        }

        private void BtnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if(Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                btnMax.Visibility = Visibility.Visible;
                btnRestore.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnMax.Visibility = Visibility.Collapsed;
                btnRestore.Visibility = Visibility.Visible;
            }
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Minimized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            }
        }

        private void BtnMax_Click(object sender, RoutedEventArgs e)
        {
            if(Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.FromHandle(new System.Windows.Interop.WindowInteropHelper(Application.Current.MainWindow).Handle);
                Application.Current.MainWindow.MaxHeight = screen.WorkingArea.Height;
                Application.Current.MainWindow.MaxWidth = screen.WorkingArea.Width;
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.DragMove();
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.FromHandle(new System.Windows.Interop.WindowInteropHelper(Application.Current.MainWindow).Handle);
                Application.Current.MainWindow.MaxHeight = screen.WorkingArea.Height;
                Application.Current.MainWindow.MaxWidth = screen.WorkingArea.Width;
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }
    }
}
