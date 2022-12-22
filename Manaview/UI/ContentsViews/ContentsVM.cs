using ManaView.MVVM;
using ManaView.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Manaview.UI
{
    public partial class ContentsVM : ViewModelBase
    {
        public MainWindowVM MainVM
        {
            get
            {
                return _mainVM;
            }
            set
            {
                _mainVM = value;
                OnPropertyChanged("MainVM");
            }
        }
        private MainWindowVM _mainVM = null;

        public ImageViewer ImageViewer
        {
            get
            {
                if (_imageViewer == null)
                {
                    _imageViewer = new ImageViewer();
                }
                return _imageViewer;
            }
            set
            {
                _imageViewer = value;
                OnPropertyChanged("ImageViewer");
            }
        }
        private ImageViewer _imageViewer = null;

        public ContentsVM(MainWindowVM ownerVM)
        {
            MainVM = ownerVM;
        }

        public bool OpenImage(string path)
        {
            if(!File.Exists(path))
            {
                MessageBox.Show("파일을 찾을 수 없습니다.");
                return false;
            }



            return true;
        }
    }
}
