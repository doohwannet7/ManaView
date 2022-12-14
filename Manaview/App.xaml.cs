using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Manaview
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        MainWindowVM _mainWindowVM = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            StartManaview();
            base.OnStartup(e);
        }

        private void StartManaview()
        {
            if(_mainWindowVM == null)
            {
                _mainWindowVM = new MainWindowVM();
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = _mainWindowVM;

            mainWindow.Show();
        }
    }
}
