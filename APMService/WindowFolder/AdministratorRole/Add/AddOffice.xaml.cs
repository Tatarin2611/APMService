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
    /// Логика взаимодействия для AddOffice.xaml
    /// </summary>
    public partial class AddOffice : Window
    {
        NumberOffice numberOffice;
        public AddOffice()
        {
            InitializeComponent();
            
            numberOffice = new NumberOffice();
            DataContext = numberOffice;
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
            if (string.IsNullOrWhiteSpace(TextBoxEmail.Text))
            {

                new WindowCustomMB("Введите номер кабинета", MessageType.Error, ImageType.Error).ShowDialog();

                TextBoxEmail.Focus();
            }

            else
            {
                try
                {
                    DataService.GetContext().NumberOffice.Add(numberOffice);
                    DataService.GetContext().SaveChanges();

                    new WindowCustomMB("Новый кабинет был добавлен", MessageType.Success, ImageType.Success).ShowDialog();


                    this.Close();
                    ActionWindowClass.borderThis.Visibility = Visibility.Hidden;
                    ActionWindowClass.datagrid2.ItemsSource = DataService.GetContext().NumberOffice.ToList();


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

