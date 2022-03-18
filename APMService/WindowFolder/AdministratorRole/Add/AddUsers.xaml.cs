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
    /// Логика взаимодействия для AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Window
    {
        
        Users users;

     
        public AddUsers()
        {
            InitializeComponent();
            users = new Users();
            DataContext = users;
            ComboBoxRole.ItemsSource = DataService.GetContext().Roles.ToList();
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
            if (string.IsNullOrWhiteSpace(ComboBoxRole.Text))
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Выберите роль", MessageType.Error, ImageType.Error).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                ComboBoxRole.Focus();
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
            if (string.IsNullOrWhiteSpace(ComboBoxRole.Text))
            {
              
                new WindowCustomMB("Выберите роль для пользователя", MessageType.Error, ImageType.Error).ShowDialog();
             
                ComboBoxRole.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TextBoxEmail.Text))
            {
            
                new WindowCustomMB("Заполните электронную почту", MessageType.Error, ImageType.Error).ShowDialog();

                TextBoxEmail.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TextBoxLogin.Text))
            {
               
                new WindowCustomMB("Заполните логин", MessageType.Error, ImageType.Error).ShowDialog();
       
                TextBoxLogin.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordBoxPassword.Text))
            {
               
                new WindowCustomMB("Заполните пароль", MessageType.Error, ImageType.Error).ShowDialog();
                
                PasswordBoxPassword.Focus();
            }

            else
            {
                try
                {
                    DataService.GetContext().Users.Add(users);
                    DataService.GetContext().SaveChanges();
                  
                    new WindowCustomMB("Добавлен новый пользователь", MessageType.Success, ImageType.Success).ShowDialog();
                    
                    
                    this.Close();
                    ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                    ActionWindowClass.datagrid.ItemsSource = DataService.GetContext().Users.ToList();
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
