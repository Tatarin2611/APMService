using APMService.DataFolder;
using APMService.ServiceFolder;
using APMService.WindowFolder.Rest;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static APMService.WindowFolder.Rest.WindowCustomMB;

namespace APMService.WindowFolder.AdministratorRole.Edit
{
    /// <summary>
    /// Логика взаимодействия для EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        public EditOrder(Order order)
        {
            InitializeComponent();
            DataContext = order;
            ComboBoxEquipment.ItemsSource = DataService.GetContext().OrderStatus.ToList();
       
            //ComboBoxRole.ItemsSource = DataService.GetContext().Roles.ToList().OrderByDescending(d => d.NameRoles);
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1.0));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(StackPanel.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, StackPanelTwo.Name);
            storyboard.Begin(this);

        }

       
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
        }



       

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ComboBoxEquipment.Text))
            {

                new WindowCustomMB("Выберите тип оборудования", MessageType.Error, ImageType.Error).ShowDialog();

                ComboBoxEquipment.Focus();
            }
           
            else
            {
                try
                {

                    DataService.GetContext().SaveChanges();

                    new WindowCustomMB("Статус заявки был изменён", MessageType.Success, ImageType.Success).ShowDialog();


                    this.Close();
                    ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                    ActionWindowClass.datagrid.ItemsSource = DataService.GetContext().Order.ToList();


                }
                catch (DbEntityValidationException ex)
                {
                    string result = "";
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {

                        result += ("Object: " + validationError.Entry.Entity.ToString());
                        result += $"\n";
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            result += (err.ErrorMessage + $"\n");
                        }
                    }
                    MessageBox.Show(result);
                }
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
