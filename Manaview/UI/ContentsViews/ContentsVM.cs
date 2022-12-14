using ManaView.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ContentsVM(MainWindowVM ownerVM)
        {
            MainVM = ownerVM;
        }
    }
}
