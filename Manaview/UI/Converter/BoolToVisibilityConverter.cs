using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Manaview.UI.Converter
{
    class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// WPF 에서 binding 되는 값을 변경하고자 할때
        /// boolean 값으로 visible 값을 변경
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value!=null && value is bool)
            {
                if((bool)value != true)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 들어간 값에 대해서 control할때
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value is Visibility)
            {
                Visibility _visibility = (Visibility)value;
                if(_visibility != Visibility.Visible)
                {
                    return false;
                }
            }

            return true;
        }


        
    }
}
