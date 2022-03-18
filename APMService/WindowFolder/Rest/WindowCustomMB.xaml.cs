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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using APMService.ServiceFolder;

namespace APMService.WindowFolder.Rest
{
    /// <summary>
    /// Логика взаимодействия для WindowCustomMB.xaml
    /// </summary>
    public partial class WindowCustomMB : Window
    {
        public WindowCustomMB(string Message, MessageType Type, ImageType image)
        {
            InitializeComponent();
            TextBlockMessage.Text = Message;
            switch (Type)
            {

                case MessageType.Info:
                    TextBlockHeader.Text = "Информация";
                    break;
                case MessageType.Confirmation:
                    TextBlockHeader.Text = "Confirmation";
                    break;
                case MessageType.Success:
                    {
                        TextBlockHeader.Text = "Успех";
                    }
                    break;
                case MessageType.Warning:
                    TextBlockHeader.Text = "Предупреждение";
                    break;
                case MessageType.Error:
                    {
                        TextBlockHeader.Text = "Ошибка";
                    }
                    break;
            }
            switch (image)
            {
                case ImageType.Error:
                    ImageError.Visibility = Visibility.Visible;
                    ImageSuccess.Visibility = Visibility.Collapsed;
                    ImageWarning.Visibility = Visibility.Collapsed;
                    ButtonClose.Background = new SolidColorBrush(Color.FromRgb(224, 80, 98));
                    break;
                case ImageType.Warning:
                    ImageWarning.Visibility = Visibility.Visible;
                    ImageSuccess.Visibility = Visibility.Collapsed;
                    ImageError.Visibility = Visibility.Collapsed;
                    ButtonClose.Background = new SolidColorBrush(Color.FromRgb(253, 196, 70));
                    break;
                case ImageType.Success:
                    ImageSuccess.Visibility = Visibility.Visible;
                    ImageWarning.Visibility = Visibility.Collapsed;
                    ImageError.Visibility = Visibility.Collapsed;
                    ButtonClose.Background = new SolidColorBrush(Color.FromRgb(68, 171, 182));
                    break;

            }
        }


        public enum MessageType
        {
            Info,
            Confirmation,
            Success,
            Warning,
            Error,
        }

        public enum ImageType
        {
            Error,
            Success,
            Warning,
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
           
        }
    }
}