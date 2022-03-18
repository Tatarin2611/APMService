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
using APMService.WindowFolder.Rest;
using static APMService.WindowFolder.Rest.WindowCustomMB;
using APMService.WindowFolder.AdministratorRole.Edit;
using APMService.WindowFolder.ClientRole;

namespace APMService.PageFolder.AdministratorRole
{
    /// <summary>
    /// Логика взаимодействия для PageOrder.xaml
    /// </summary>
    public partial class PageOrder : Page
    {
        Order order;
        public PageOrder()
        {
            InitializeComponent();
            ComboBoxStatus.ItemsSource = DataService.GetContext().OrderStatus.ToList().OrderByDescending(d => d.NameStatus);

            DataGridOrder.ItemsSource = DataService.GetContext().Order.ToList();
            ActionWindowClass.datagrid = DataGridOrder;

        }

        private void ButtonDeletet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataService.GetContext().Order.Remove(DataGridOrder.SelectedItem as Order);
                DataService.GetContext().SaveChanges();
                DataGridOrder.ItemsSource = DataService.GetContext().Order.OrderBy(u => u.IdOrder).ToArray();
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Заявка удалена", MessageType.Success, ImageType.Success).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
            }
            catch
            {
                new WindowCustomMB("Ошибка подключения базы данных", MessageType.Error, ImageType.Error).ShowDialog();
            }
        }

        private void ButtonFiltering_Click(object sender, RoutedEventArgs e)
        {
            var roles = ComboBoxStatus.SelectedItem as OrderStatus;
            if (roles.NameStatus == "Все")
                DataGridOrder.ItemsSource = DataService.GetContext().Order.ToList();
            else
                DataGridOrder.ItemsSource = DataService.GetContext().Order.Where(emp => emp.OrderStatus.NameStatus == roles.NameStatus).ToList();
        }


     
        private void ButtonEditUsers_Click(object sender, RoutedEventArgs e)
        {
            //if (DataGridOrder.SelectedItem is null)
            //{
            //    ActionWindowClass.borderThis.Visibility = Visibility.Visible;
            //    new WindowCustomMB("Выберите заявку", MessageType.Warning, ImageType.Warning).ShowDialog();
            //    ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
            //    return;
            //}
            //ActionWindowClass.borderThis.Visibility = Visibility.Visible;
            //new EditOrder(DataGridOrder.SelectedItem as Order).Show();

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

            ActionWindowClass.borderThis.Visibility = Visibility.Visible;
            new AddOrder().ShowDialog();
            ActionWindowClass.borderThis.Visibility = Visibility.Collapsed;
        }

        private void ButtonAcceptOrder_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridOrder.SelectedItem is null)
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Выберите заявку", MessageType.Warning, ImageType.Warning).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                return;
            }
            ActionWindowClass.borderThis.Visibility = Visibility.Visible;
            new EditOrder(DataGridOrder.SelectedItem as Order).Show();
        }

        private void ButtonCancelOrder_Click(object sender, RoutedEventArgs e)
        {
            


        }

        private void ButtonEndOrder_Click(object sender, RoutedEventArgs e)
        {
           
            
        }
    }
}
