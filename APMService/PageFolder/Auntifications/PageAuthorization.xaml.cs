using APMService.ServiceFolder;
using APMService.WindowFolder.AdministratorRole;
using APMService.WindowFolder.ClientRole;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static APMService.WindowFolder.Rest.WindowCustomMB;

namespace APMService.PageFolder.Auntifications
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        Window winAuth = ActionWindowClass.CurrentWindow;
        public PageAuthorization()
        {
            InitializeComponent();
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1.0));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(StackPanel.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, StackPanelAnimation.Name);
            storyboard.Begin(this);
        }
        private void ButtonAuthorization_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TextBoxLogin.Text))
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Введите логин", MessageType.Error, ImageType.Error).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                TextBoxLogin.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordBoxPassword.Password))
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Введите пароль", MessageType.Error, ImageType.Error).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                PasswordBoxPassword.Focus();
            }
            else
            {
                try
                {
                    var user = DataService.GetContext()
                        .Users
                        .FirstOrDefault(u => u.LoginUsers == TextBoxLogin.Text &&
                        u.PasswordUsers == PasswordBoxPassword.Password);

                    if (user == null)
                    {
                        ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                        new WindowCustomMB("Неверный логин или пароль", MessageType.Error, ImageType.Error).ShowDialog();
                        ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                        return;
                    }

                    switch (user.RolesId)
                    {
                        case 1:
                            new WindowAdministrator().Show();
                            winAuth.Close();
                            break;
                        case 2:
                            new WindowClient().Show();
                            winAuth.Close();
                            break;
                    }
                }
                catch
                {
                    ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                    new WindowCustomMB("Ошибка подключения базы данных", MessageType.Error, ImageType.Error).ShowDialog();
                    ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                }
            }

        }

        private void ButtonRegistrationSystem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonFartSystemAccess_Click(object sender, RoutedEventArgs e)
        {
            ActionWindowClass.MainFrame.NavigationService.RemoveBackEntry();
            ActionWindowClass.MainFrame.Navigate(new PageEmailImput());
        }
    }
}