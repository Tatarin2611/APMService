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
using System.Windows.Threading;

namespace APMService.WindowFolder.Rest
{
    /// <summary>
    /// Логика взаимодействия для WindowLoading.xaml
    /// </summary>
    public partial class WindowLoading : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public WindowLoading()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(WaitingEvent);
            timer.Interval = new TimeSpan(0, 0, 4);
            timer.Start();
        }
        private void WaitingEvent(object sender, EventArgs e)
        {
            new WindowFolder.Auntifications.WindowAuntifications().Show();
            this.Close();
            timer.Stop();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }

}