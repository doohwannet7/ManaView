using Manaview.UI;
using ManaView.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manaview
{
    public class ImageItemPanelVM : ViewModelBase
    {
        public ContentsVM ContentsVM
        {
            get
            {
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
