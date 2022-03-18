using APMService.DataFolder;
using APMService.ServiceFolder;
using APMService.WindowFolder.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для PageEmailImput.xaml
    /// </summary>
    public partial class PageEmailImput : Page
    {
        public PageEmailImput()
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
            Users user = DataService.GetContext().Users.FirstOrDefault(u => u.Email == TextBoxEmail.Text);
            if (user == null)
            {
                ActionWindowClass.borderThis.Visibility = Visibility.Visible;
                new WindowCustomMB("Пользователь с такой почтой не зарегистрирован", MessageType.Error, ImageType.Error).ShowDialog();
                ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
            }
            else
            {
                try
                {
                    string Code = RandomClass.Rand(6);
                    string a = "apmservise@mail.ru";
                    var client = new SmtpClient("smtp.mail.ru", 25);
                    client.Credentials = new NetworkCredential(a, "APM1488");
                    client.EnableSsl = true;
                    client.Send(a, TextBoxEmail.Text, "КОД для смены пароля", Code);
               
                    RandomClass.Saver = Code;
                    ActionWindowClass.MainFrame.Navigate(new PageEmailCode());
                    ActionWindowClass.UserTransition = user;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ButtonAuthorizationSystem_Click(object sender, RoutedEventArgs e)
        {
            ActionWindowClass.MainFrame.NavigationService.RemoveBackEntry();
            ActionWindowClass.MainFrame.Navigate(new PageAuthorization());
        }

      
    }
}