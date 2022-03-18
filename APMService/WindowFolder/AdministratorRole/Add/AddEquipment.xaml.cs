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

namespace APMService.WindowFolder.AdministratorRole.Add
{
    /// <summary>
    /// Логика взаимодействия для AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : Window
    {
        Equipment equipment;
        public AddEquipment()
        {
            InitializeComponent();
            equipment = new Equipment();
            DataContext = equipment;
            ComboBoxEquipment.ItemsSource = DataService.GetContext().TypeEquipment.ToList();
            ComboBoxManufa.ItemsSource = DataService.GetContext().Manufacturer.ToList();
            //ComboBoxRole.ItemsSource = DataService.GetContext().Roles.ToList().OrderByDescending(d => d.NameRoles);
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1.0));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(StackPanel.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, StackPanelOne.Name);
            storyboard.Begin(this);

        }

        private void ButtonNextTwo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ComboBoxEquipment.Text))
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Выберите тип оборудования", MessageType.Error, ImageType.Error).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                ComboBoxEquipment.Focus();
            }
            else if (string.IsNullOrWhiteSpace(ComboBoxManufa.Text))
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Выберите производителя оборудования", MessageType.Error, ImageType.Error).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                ComboBoxManufa.Focus();
            }
            else
            {
                StackPanelTwo.Visibility = Visibility.Visible;
                StackPanelOne.Visibility = Visibility.Hidden;

                Storyboard storyboard = new Storyboard();
                DoubleAnimation doubleAnimation = new DoubleAnimation();
                doubleAnimation.From = 0;
                doubleAnimation.To = 1;
                doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                storyboard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(StackPanel.OpacityProperty));
                Storyboard.SetTargetName(doubleAnimation, StackPanelTwo.Name);
                storyboard.Begin(this);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void ButtonLeaveOne_Click(object sender, RoutedEventArgs e)
        {
            StackPanelTwo.Visibility = Visibility.Hidden;
            StackPanelOne.Visibility = Visibility.Visible;

            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(StackPanel.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, StackPanelOne.Name);
            storyboard.Begin(this);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ComboBoxEquipment.Text))
            {

                new WindowCustomMB("Выберите тип оборудования", MessageType.Error, ImageType.Error).ShowDialog();

                ComboBoxEquipment.Focus();
            }
            else if (string.IsNullOrWhiteSpace(ComboBoxManufa.Text))
            {

                new WindowCustomMB("Выберите производителя оборудования", MessageType.Error, ImageType.Error).ShowDialog();

                ComboBoxManufa.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TextBoxSeriaEquipment.Text))
            {

                new WindowCustomMB("Заполните серию оборудования", MessageType.Error, ImageType.Error).ShowDialog();

                TextBoxSeriaEquipment.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TextBoxSeriaNameEqu.Text))
            {

                new WindowCustomMB("Заполните модель оборудования", MessageType.Error, ImageType.Error).ShowDialog();

                TextBoxSeriaNameEqu.Focus();
            }
            else
            {
                try
                {

                    DataService.GetContext().Equipment.Add(equipment);

                    DataService.GetContext().SaveChanges();
                 
                         


                    new WindowCustomMB("Добавлено новое оборудование", MessageType.Success, ImageType.Success).ShowDialog();


                    this.Close();
                    ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                    ActionWindowClass.datagrid.ItemsSource = DataService.GetContext().Equipment.ToList();
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
