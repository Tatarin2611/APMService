using APMService.DataFolder;
using APMService.ServiceFolder;
using APMService.WindowFolder.AdministratorRole.Add;
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
using APMService.WindowFolder.AdministratorRole;
using static APMService.WindowFolder.Rest.WindowCustomMB;
using APMService.WindowFolder.Rest;
using APMService.WindowFolder.AdministratorRole.Edit;

namespace APMService.PageFolder.AdministratorRole
{
    /// <summary>
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    public partial class PageUser : Page
    {

        public PageUser()
        {
            InitializeComponent();
            ComboBoxRole.ItemsSource = DataService.GetContext().Roles.ToList().OrderByDescending(d => d.NameRoles);

            DataGridUsers.ItemsSource = DataService.GetContext().Users.ToList();
            ActionWindowClass.datagrid = DataGridUsers;
        }

        private void ButtonDeletet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataService.GetContext().Users.Remove(DataGridUsers.SelectedItem as Users);
                DataService.GetContext().SaveChanges();
                DataGridUsers.ItemsSource = DataService.GetContext().Users.OrderBy(u => u.IdUsers).ToArray();
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Пользователь удалён", MessageType.Success, ImageType.Success).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
            }
            catch 
            {
                new WindowCustomMB("Ошибка подключения базы данных", MessageType.Error, ImageType.Error).ShowDialog();
            }
        }

        private void ButtonFiltering_Click(object sender, RoutedEventArgs e)
        {
            var roles = ComboBoxRole.SelectedItem as Roles;
            if (roles.NameRoles == "Все")
                DataGridUsers.ItemsSource = DataService.GetContext().Users.ToList();
            else
                DataGridUsers.ItemsSource = DataService.GetContext().Users.Where(emp => emp.Roles.NameRoles == roles.NameRoles).ToList();
        }


        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridUsers.ItemsSource = DataService.GetContext().Users.Where(emp => emp.LoginUsers.StartsWith(TextBoxSearchUsers.Text)).ToList();

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

            ActionWindowClass.borderThis.Visibility = Visibility.Visible;
            new AddUsers().ShowDialog();
            ActionWindowClass.borderThis.Visibility = Visibility.Collapsed;
        }

        private void ButtonEditUsers_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedItem is null)
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Выберите пользователя", MessageType.Warning, ImageType.Warning).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                return;
            }
            ActionWindowClass.borderThis.Visibility = Visibility.Visible;
            new EditUsers(DataGridUsers.SelectedItem as Users).Show();
           
        }
    }
}

