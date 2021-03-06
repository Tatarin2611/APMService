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
    /// Логика взаимодействия для EditStaff.xaml
    /// </summary>
    public partial class EditStaff : Window
    {
        
        public EditStaff(Staff staff)
        {
            InitializeComponent();
            ComboBoxUsers.ItemsSource = DataService.GetContext().Users.ToList();

            DataContext = staff;
            ComboBoxOffice.ItemsSource = DataService.GetContext().NumberOffice.ToList();
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
            if (string.IsNullOrWhiteSpace(ComboBoxUsers.Text))
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Выберите пользователя", MessageType.Error, ImageType.Error).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                ComboBoxUsers.Focus();
            }
            else if (string.IsNullOrWhiteSpace(ComboBoxOffice.Text))
            {

                new WindowCustomMB("Выберите кабинет для сотрудника", MessageType.Error, ImageType.Error).ShowDialog();

                ComboBoxUsers.Focus();
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
            ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
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
            if (string.IsNullOrWhiteSpace(ComboBoxUsers.Text))
            {

                new WindowCustomMB("Выберите пользователя", MessageType.Error, ImageType.Error).ShowDialog();

                ComboBoxUsers.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TextBoxLastName.Text))
            {

                new WindowCustomMB("Заполните фамилию", MessageType.Error, ImageType.Error).ShowDialog();

                TextBoxLastName.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TextBoxFirstNameStaff.Text))
            {

                new WindowCustomMB("Заполните имя", MessageType.Error, ImageType.Error).ShowDialog();

                TextBoxFirstNameStaff.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TextBoxMiddleNameStaff.Text))
            {

                new WindowCustomMB("Заполните отчество", MessageType.Error, ImageType.Error).ShowDialog();

                TextBoxMiddleNameStaff.Focus();
            }

            else
            {
                try
                {

                    DataService.GetContext().SaveChanges();

                    new WindowCustomMB("Данные о cотруднике были изменены", MessageType.Success, ImageType.Success).ShowDialog();


                    this.Close();
                    ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                    ActionWindowClass.datagrid.ItemsSource = DataService.GetContext().Staff.ToList();
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
