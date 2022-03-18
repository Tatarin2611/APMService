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
    /// Логика взаимодействия для PageEquipment.xaml
    /// </summary>
    public partial class PageEquipment : Page
    {
        public PageEquipment()
        {
            InitializeComponent();
            ComboBoxE.ItemsSource = DataService.GetContext().TypeEquipment.ToList().OrderByDescending(d => d.NameEquipment);
            ActionWindowClass.datagrid = DataGridEquipment;
            DataGridEquipment.ItemsSource = DataService.GetContext().Equipment.ToList();

        }

        private void ButtonDeletet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataService.GetContext().Equipment.Remove(DataGridEquipment.SelectedItem as Equipment);
                DataService.GetContext().SaveChanges();
                DataGridEquipment.ItemsSource = DataService.GetContext().Equipment.OrderBy(u => u.IdEquipment).ToArray();
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Оборудование удалено", MessageType.Success, ImageType.Success).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
            }
            catch 
            {
                new WindowCustomMB("Ошибка подключения базы данных", MessageType.Error, ImageType.Error).ShowDialog();
            }
        }

        private void ButtonFiltering_Click(object sender, RoutedEventArgs e)
        {
            var roles = ComboBoxE.SelectedItem as TypeEquipment;
            if (roles.NameEquipment == "Все")
                DataGridEquipment.ItemsSource = DataService.GetContext().Equipment.ToList();
            else
                DataGridEquipment.ItemsSource = DataService.GetContext().Equipment.Where(emp => emp.TypeEquipment.NameEquipment == roles.NameEquipment).ToList();
        }


        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridEquipment.ItemsSource = DataService.GetContext().Equipment.Where(emp => emp.NameModel.StartsWith(TextBoxSearchUsers.Text)).ToList();

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

            ActionWindowClass.borderThis.Visibility = Visibility.Visible;
            new AddEquipment().ShowDialog();
            ActionWindowClass.borderThis.Visibility = Visibility.Collapsed;
        }

        private void ButtonEditUsers_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridEquipment.SelectedItem is null)
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Выберите оборудование", MessageType.Warning, ImageType.Warning).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                return;
            }
            ActionWindowClass.borderThis.Visibility = Visibility.Visible;
            new EditEquipment(DataGridEquipment.SelectedItem as Equipment).Show();

        }
    }
}


