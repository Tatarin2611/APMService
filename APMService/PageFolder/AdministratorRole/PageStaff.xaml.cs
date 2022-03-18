using APMService.DataFolder;
using APMService.ServiceFolder;
using APMService.WindowFolder.AdministratorRole.Add;
using APMService.WindowFolder.AdministratorRole.Edit;
using APMService.WindowFolder.Rest;
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
using static APMService.WindowFolder.Rest.WindowCustomMB;

namespace APMService.PageFolder.AdministratorRole
{
    /// <summary>
    /// Логика взаимодействия для PageStaff.xaml
    /// </summary>
    public partial class PageStaff : Page
    {
        public PageStaff()
        {
            InitializeComponent();
         

            DataGridStaff.ItemsSource = DataService.GetContext().Staff.ToList();
            DataGridKabinet.ItemsSource = DataService.GetContext().NumberOffice.ToList();
            ActionWindowClass.datagrid = DataGridStaff;
            ActionWindowClass.datagrid2 = DataGridKabinet;
        }

        private void ButtonDeletet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataService.GetContext().Staff.Remove(DataGridStaff.SelectedItem as Staff);
                DataService.GetContext().SaveChanges();
                DataGridStaff.ItemsSource = DataService.GetContext().Staff.OrderBy(u => u.IdStaff).ToArray();
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Сотрудник удалён", MessageType.Success, ImageType.Success).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
            }
            catch 
            {
                new WindowCustomMB("Ошибка подключения базы данных", MessageType.Error, ImageType.Error).ShowDialog();
            }
        }

        


        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridStaff.ItemsSource = DataService.GetContext().Staff.Where(emp => emp.LastNameStaff.StartsWith(TextBoxSearchUsers.Text)).ToList();

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

            ActionWindowClass.borderThis.Visibility = Visibility.Visible;
            new AddStaff().ShowDialog();
            ActionWindowClass.borderThis.Visibility = Visibility.Collapsed;
        }

        private void ButtonEditUsers_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridStaff.SelectedItem is null)
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Выберите сотрудника", MessageType.Warning, ImageType.Warning).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                return;
            }
            ActionWindowClass.borderThis.Visibility = Visibility.Visible;
            new EditStaff(DataGridStaff.SelectedItem as Staff).Show();

        }

        private void ButtonAddKabinet_Click(object sender, RoutedEventArgs e)
        {
            ActionWindowClass.borderThis.Visibility = Visibility.Visible;
            new AddOffice().ShowDialog();
            ActionWindowClass.borderThis.Visibility = Visibility.Collapsed;
        }

        private void ButtonDeletetKabiney_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataService.GetContext().NumberOffice.Remove(DataGridKabinet.SelectedItem as NumberOffice);
                DataService.GetContext().SaveChanges();
                DataGridStaff.ItemsSource = DataService.GetContext().NumberOffice.OrderBy(u => u.IdNumberOffice).ToArray();
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Кабинет удалён", MessageType.Success, ImageType.Success).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
            }
            catch
            {
                new WindowCustomMB("Ошибка подключения базы данных", MessageType.Error, ImageType.Error).ShowDialog();

            }
        }
    }
}

