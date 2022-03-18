using APMService.DataFolder;
using APMService.ServiceFolder;
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
    /// Логика взаимодействия для PageChangePassword.xaml
    /// </summary>
    public partial class PageChangePassword : Page
    {
        public PageChangePassword()
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

        private void ButtonEmailSender_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordBoxPassword.Password))
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Неправильный логин или пароль", MessageType.Error, ImageType.Error).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
            }
            else if (string.IsNullOrWhiteSpace(PasswordBoxPassword2.Password))
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Пароль не подтверждён", MessageType.Error, ImageType.Error).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
            }
            else if (PasswordBoxPassword.Password != PasswordBoxPassword2.Password)
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Пароли не совпадают", MessageType.Error, ImageType.Error).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
            }
            else
            {
                try
                {
                    Users users = ActionWindowClass.UserTransition;
                    users.PasswordUsers = PasswordBoxPassword.Password;
                    DataService.GetContext().SaveChanges();
                    ActionWindowClass.MainFrame.NavigationService.RemoveBackEntry();
                    ActionWindowClass.MainFrame.Navigate(new PageAuthorization());
                    ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                    new WindowCustomMB("Ваш пароль был изменён", MessageType.Success, ImageType.Success).ShowDialog();
                    ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                }
                catch 
                {
                    ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                    new WindowCustomMB("Ошибка подключения базы данных", MessageType.Error, ImageType.Error).ShowDialog();
                    ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                }
            }

        }

        private void ButtonAuthorizationSystem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
