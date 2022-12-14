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
    }
}
