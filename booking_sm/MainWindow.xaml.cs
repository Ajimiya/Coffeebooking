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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace booking_sm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void homebtn_Click(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(home);
        }

        public void setActiveUserControl(UserControl control)
        {
            home.Visibility = Visibility.Collapsed;
            about.Visibility = Visibility.Collapsed;
            register.Visibility = Visibility.Collapsed;
            login.Visibility = Visibility.Collapsed;
            booking.Visibility = Visibility.Collapsed;
            contact.Visibility = Visibility.Collapsed;

            control.Visibility = Visibility.Visible;

        }

        private void abtbtn_Click(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(about);
        }

        private void regbtn_Click(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(register);
        }

        private void logbtn_Click(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(login);
        }

        private void bookbtn_Click(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(booking);
        }

        private void contactbtn_Click(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(contact);
                
        }
    }
}
