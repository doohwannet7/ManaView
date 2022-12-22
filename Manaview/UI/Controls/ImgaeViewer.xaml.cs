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

namespace ManaView.UI.Controls
{
    /// <summary>
    /// ImgaeViewer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ImageViewer : UserControl
    {
        public ImageViewer()
        {
            InitializeComponent();

            Uri uri = new Uri(@"D:\TestImage\0001.tif");

            BitmapImage bitmapImage = new BitmapImage();

            bitmapImage.BeginInit();

            bitmapImage.UriSource = uri;

            bitmapImage.EndInit();

            img.Source = bitmapImage;
        }

        public void SetFieldView(UserControl control)
        {
        }
    }
}
