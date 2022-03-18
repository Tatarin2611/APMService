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
using APMService.DataFolder;
using APMService.PageFolder.AdministratorRole;
using APMService.ServiceFolder;
using APMService.WindowFolder.Auntifications;
using APMService.WindowFolder.Rest;
using static APMService.WindowFolder.Rest.WindowCustomMB;

namespace APMService.WindowFolder.AdministratorRole
{
    /// <summary>
    /// Логика взаимодействия для WindowAdministrator.xaml
    /// </summary>
    public partial class WindowAdministrator : Window
    {
       
        public WindowAdministrator()
        {
            InitializeComponent();
           
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

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void ButtonMessage_Click(object sender, RoutedEventArgs e)
        {
            BorderBlur.Visibility = Visibility.Visible;
            new WindowCustomMB("Неправильный логин или пароль", MessageType.Error, ImageType.Error).ShowDialog();
            BorderBlur.Visibility = Visibility.Collapsed;

        }

        private void TreeViewLeftPanel_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            new WindowAuntifications().Show();
            this.Close();
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            FrameGrid.Navigate(new PageUser());
        }

        private void TreeViewLeftPanel_SelectedItemChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
        }
        public static void borderopen()
        {
           
        }

        private void TVIUsers_Selected(object sender, RoutedEventArgs e)
        {
            FrameGrid.NavigationService.RemoveBackEntry();
            FrameGrid.Navigate(new PageUser());
        }

        private void TVIOrder_Selected(object sender, RoutedEventArgs e)
        {
            FrameGrid.NavigationService.RemoveBackEntry();
            FrameGrid.Navigate(new PageOrder());
        }

        private void TVIStaff_Selected(object sender, RoutedEventArgs e)
        {
            FrameGrid.NavigationService.RemoveBackEntry();
            FrameGrid.Navigate(new PageStaff());
        }

        private void TVIEquipment_Selected(object sender, RoutedEventArgs e)
        {
            FrameGrid.NavigationService.RemoveBackEntry();
            FrameGrid.Navigate(new PageEquipment());
        }

       

      

   

        private void ButtonInformation_Click(object sender, RoutedEventArgs e)
        {
            FrameGrid.NavigationService.RemoveBackEntry();
            FrameGrid.Navigate(new PageInformation());
        }

      

        private void ExitAuth(object sender, RoutedEventArgs e)
        {
          
            new WindowAuntifications().Show();
            this.Close();
        }
    }
}