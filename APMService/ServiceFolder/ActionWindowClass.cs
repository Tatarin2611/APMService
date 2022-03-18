using APMService.DataFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace APMService.ServiceFolder
{
    class ActionWindowClass
    {
        static public void WindowTransition(Window current, Window newWindow)
        {
            current.Close();
            newWindow.Show();
            
        }
        static public void OpenBorder(Border OpenB, Border CloseB)
        {
            OpenB.Visibility = Visibility.Visible;
            CloseB.Visibility = Visibility.Hidden;

        }
        static public void CloseBorder(Border CloceB)
        {
            CloceB.Visibility = Visibility.Hidden;


        }
        public static Border borderThis { get; set; }
        public static Frame MainFrame { get; set; }
        public static Users UserTransition { get; set; }

        public static Order OrderTransition { get; set; }

        public static Window CurrentWindow { get; set; }

        public static DataGrid datagrid { get; set; }
        public static DataGrid datagrid2 { get; set; }

    }
}
