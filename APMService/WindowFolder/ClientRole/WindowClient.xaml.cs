using APMService.DataFolder;
using APMService.ServiceFolder;
using APMService.WindowFolder.Auntifications;
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

namespace APMService.WindowFolder.ClientRole
{
    /// <summary>
    /// Логика взаимодействия для WindowClient.xaml
    /// </summary>
    public partial class WindowClient : Window
    {
        Order order;
        public WindowClient()
        {
            InitializeComponent();
            order = new Order();
            DataContext = order;
           
            ComboBoxLastNameClient.ItemsSource = DataService.GetContext().Staff.ToList().OrderByDescending(d => d.LastNameStaff);
            ComboBoxSeriaEquipment.ItemsSource = DataService.GetContext().Equipment.ToList().OrderByDescending(d => d.SeriaEquipment);

            StackPanelOne.Visibility = Visibility.Visible;
         
            StackPanelFour.Visibility = Visibility.Hidden;
            StackPanelThree.Visibility = Visibility.Hidden;


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
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void ButtonWindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ButtonWindowMaximize_Click_1(object sender, RoutedEventArgs e)
        {

            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;


            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;


            }
        }

        private void GridTopPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonWindowMaximize_Click(object sender, RoutedEventArgs e)
        {

            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;


            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;


            }
        }

        private void ButtonNextTwo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxDescription.Text))
            {
                BorderBlur.Visibility = Visibility.Visible;
                new WindowCustomMB("Опишите суть проблемы", MessageType.Error, ImageType.Error).ShowDialog();
                BorderBlur.Visibility = Visibility.Hidden;
                TextBoxDescription.Focus();
            }
            else
            {

                StackPanelOne.Visibility = Visibility.Hidden;
               
                StackPanelFour.Visibility = Visibility.Hidden;
                StackPanelThree.Visibility = Visibility.Visible;

                Storyboard storyboard = new Storyboard();
                DoubleAnimation doubleAnimation = new DoubleAnimation();
                doubleAnimation.From = 0;
                doubleAnimation.To = 1;
                doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                storyboard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(StackPanel.OpacityProperty));
                Storyboard.SetTargetName(doubleAnimation, StackPanelThree.Name);
                storyboard.Begin(this);
            }
        }

        private void ButtonCancelAuthorization_Click(object sender, RoutedEventArgs e)
        {
            new WindowAuntifications().Show();
            this.Close();

        }

       

        

        private void ButtonNextFour_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ComboBoxSeriaEquipment.Text))
            {
                BorderBlur.Visibility = Visibility.Visible;
                new WindowCustomMB("Выберите серийный номер оборудования", MessageType.Error, ImageType.Error).ShowDialog();
                BorderBlur.Visibility = Visibility.Hidden;
                ComboBoxSeriaEquipment.Focus();
            }
            else
            {
                StackPanelOne.Visibility = Visibility.Hidden;
                
                StackPanelFour.Visibility = Visibility.Visible;
                StackPanelThree.Visibility = Visibility.Hidden;
                Storyboard storyboard = new Storyboard();
                DoubleAnimation doubleAnimation = new DoubleAnimation();
                doubleAnimation.From = 0;
                doubleAnimation.To = 1;
                doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                storyboard.Children.Add(doubleAnimation);
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(StackPanel.OpacityProperty));
                Storyboard.SetTargetName(doubleAnimation, StackPanelFour.Name);
                storyboard.Begin(this);
            }
        }

        private void ButtonLeaveTwo_Click(object sender, RoutedEventArgs e)
        {
            StackPanelOne.Visibility = Visibility.Visible;
        
            StackPanelFour.Visibility = Visibility.Hidden;
            StackPanelThree.Visibility = Visibility.Hidden;

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



        private void ButtonLeaveFour_Click(object sender, RoutedEventArgs e)
        {
            StackPanelOne.Visibility = Visibility.Visible;
           
            StackPanelFour.Visibility = Visibility.Hidden;
            StackPanelThree.Visibility = Visibility.Hidden;

            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(StackPanel.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, StackPanelFour.Name);
            storyboard.Begin(this);
        }

        private void ButtonLeaveThree_Click(object sender, RoutedEventArgs e)
        {
            StackPanelOne.Visibility = Visibility.Hidden;
            
            StackPanelFour.Visibility = Visibility.Hidden;
            StackPanelThree.Visibility = Visibility.Visible;

            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(StackPanel.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, StackPanelThree.Name);
            storyboard.Begin(this);
        }

        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxDescription.Text))
            {
                BorderBlur.Visibility = Visibility.Visible;
                new WindowCustomMB("Опишите вашу проблему", MessageType.Error, ImageType.Error).ShowDialog();
                BorderBlur.Visibility = Visibility.Hidden;
                TextBoxDescription.Focus();
            }
          
            else if (string.IsNullOrWhiteSpace(ComboBoxSeriaEquipment.Text))
            {
                BorderBlur.Visibility = Visibility.Visible;
                new WindowCustomMB("Выберите серию оборудования. \n Её можно ужнать на обратной стороне оборудования", MessageType.Error, ImageType.Error).ShowDialog();
                BorderBlur.Visibility = Visibility.Hidden;
                ComboBoxSeriaEquipment.Focus();
            }
            else if (string.IsNullOrWhiteSpace(ComboBoxLastNameClient.Text))
            {
                BorderBlur.Visibility = Visibility.Visible;
                new WindowCustomMB("Выберите вашу фамилию", MessageType.Error, ImageType.Error).ShowDialog();
                BorderBlur.Visibility = Visibility.Hidden;
                ComboBoxLastNameClient.Focus();
            }
           

            else
            {
                try
                {
                    DataService.GetContext().Order.Add(order);
                    order.OrderStatusId = 5;
                    DataService.GetContext().SaveChanges();
                    BorderBlur.Visibility = Visibility.Visible;
                    new WindowCustomMB("Ваша заявка на ремонт оформлена, ожидайте!", MessageType.Success, ImageType.Success).ShowDialog();
                    BorderBlur.Visibility = Visibility.Hidden;

                    StackPanelOne.Visibility = Visibility.Visible;

                    StackPanelFour.Visibility = Visibility.Hidden;
                    StackPanelThree.Visibility = Visibility.Hidden;
                    
                    Storyboard storyboard = new Storyboard();
                    DoubleAnimation doubleAnimation = new DoubleAnimation();
                    doubleAnimation.From = 0;
                    doubleAnimation.To = 1;
                    doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                    storyboard.Children.Add(doubleAnimation);
                    Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(StackPanel.OpacityProperty));
                    Storyboard.SetTargetName(doubleAnimation, StackPanelThree.Name);
                    storyboard.Begin(this);
                    TextBoxDescription.Clear();

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
    }
}