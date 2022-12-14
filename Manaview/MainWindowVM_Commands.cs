using ManaView.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Manaview
{
    public partial class MainWindowVM : ViewModelBase
    {
        public ICommand CloseCommand
        {
            get
            {
                if(_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(execute => CloseCommand_Execute(), canExecute => true);
                }
                return _closeCommand;
            }
        }

        RelayCommand _closeCommand;

        void CloseCommand_Execute()
        {
            MessageBoxResult result = MessageBox.Show("프로그램을 종료하시겠습니까?", "종료", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }


        public ICommand OpenCommand
        {
            get
            {
                if (_openCommand == null)
                {
                    _openCommand = new RelayCommand(execute => OpenCommand_Execute(), canExecute => true);
                }
                return _openCommand;
            }
        }

        RelayCommand _openCommand;

        void OpenCommand_Execute()
        {
            string fileName = Common.OpenFileDialog("이미지|*.png|*.jpg|*.jpeg|*.tif");

        }
    }
}
