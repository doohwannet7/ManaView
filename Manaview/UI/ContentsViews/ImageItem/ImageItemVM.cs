using ManaView.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manaview.UI
{
    /// <summary>
    /// FormDocItem
    /// </summary>
    public class ImageItemVM : ViewModelBase
    {
        public ContentsVM ContentsVM
        {
            get
            {
                return _ownerVM;
            }
            set
            {
                _ownerVM = value;
                OnPropertyChanged("ContentsVM");
            }
        }
        private ContentsVM _ownerVM = null;

        public ImageItemVM(ContentsVM ownerVM)
        {
            ContentsVM = ownerVM;
            InitControl();
        }

        private void InitControl()
        {

        }


    }
}
