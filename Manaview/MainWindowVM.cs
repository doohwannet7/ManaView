using Manaview.UI;
using ManaView.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Manaview
{
    public partial class MainWindowVM : ViewModelBase
    {
        public MainWindowVM()
        {
            ContentsView = new Manaview.UI.ContentsView();
            ContentsView.DataContext = ContentsVM;
        }

        /// <summary>
        /// Main Contents View
        /// </summary>
        public UserControl ContentsView
        {
            get
            {
                return _contentsView;
            }
            set
            {
                _contentsView = value;
                OnPropertyChanged("ContentsView");
            }
        }

        private UserControl _contentsView = null;

        /// <summary>
        /// Contents View VM
        /// </summary>
        public ContentsVM ContentsVM
        {
            get
            {
                if(_contentsVM == null)
                {
                    _contentsVM = new ContentsVM(this);
                }

                return _contentsVM;
            }
            set
            {
                _contentsVM = value;
                OnPropertyChanged("ContentsVM");

            }
        }
        private ContentsVM _contentsVM = null;
    }
}
