using APMService.ServiceFolder;
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

namespace APMService.PageFolder.Auntifications
{
    /// <summary>
    /// Логика взаимодействия для PageEmailCode.xaml
    /// </summary>
    public partial class PageEmailCode : Page
    {
        public PageEmailCode()
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
            if (TextBoxCode.Text == RandomClass.Saver)
            {
                ActionWindowClass.MainFrame.NavigationService.RemoveBackEntry();
                ActionWindowClass.MainFrame.Navigate(new PageChangePassword());
            }
            else
            {

               
            }
        }

        private void TextBoxCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonAuthorizationSystem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
