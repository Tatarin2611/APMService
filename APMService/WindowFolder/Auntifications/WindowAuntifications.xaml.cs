using APMService.ServiceFolder;
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
using System.Windows.Shapes;

namespace APMService.WindowFolder.Auntifications
{
    /// <summary>
    /// Логика взаимодействия для WindowAuntifications.xaml
    /// </summary>
    public partial class WindowAuntifications : Window
    {
        public WindowAuntifications()
        {
            InitializeComponent();
            ActionWindowClass.CurrentWindow = this;
            FrameMain.Navigate(new PageFolder.Auntifications.PageAuthorization());
            ActionWindowClass.MainFrame = FrameMain;
            ActionWindowClass.borderThis = BorderBlur;

        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void ButtonWindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ButtonWindowMaximize_Click_1(object sender, RoutedEventArgs e)
        {

            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;


            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;


            }
        }

        private void GridTopPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonWindowMaximize_Click(object sender, RoutedEventArgs e)
        {

            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;


            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;


            }
        }
    }
}