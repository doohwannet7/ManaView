using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Manaview
{
    public static class Common
    {
        public static string OpenFileDialog(string filter)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Title = "파일열기";
            dialog.Filter = filter; 

            if(dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }

            return string.Empty;
        }



        //public static MessageBoxResult ShowMessageBox(string msg, MessageBoxButton buttons)
        //{
        //    return ShowMessageBox(msg, ManaviewHost.Inst.VersionInfo.Etc.ProgramTitle, buttons);
        //}

        //public static MessageBoxResult ShowMessageBox(string msg, string title = "", MessageBoxButton button = MessageBoxButton.OK)
        //{
        //    bool beforeLoadingWindowIsShow = false;
        //    if (string.IsNullOrEmpty(title))
        //    {
        //        title = "ManaView 1.0";
        //    }
        //}
    }
}
