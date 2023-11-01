using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : UserControl
    {
        public login()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-TESA3TI;Initial Catalog=RegistrationDatabase;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM UserRegister WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", LoginUsernameTextBox.Text);
                        cmd.Parameters.AddWithValue("@Password", LoginPasswordBox.Password);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            MessageBox.Show("Login successful!");

                            Booking booking = new Booking(); 
                            Window mainWindow = Application.Current.MainWindow;
                            mainWindow.Content = booking;
                        }
                        else
                        {
                           MessageBox.Show("Login failed. Check your username and password.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                
            }
        }

        private void NavigateToAnotherPage_Click(object sender, RoutedEventArgs e)
        {

            // Create an instance of the destination page
            Register register = new Register();

            Window mainWindow = Application.Current.MainWindow;
            mainWindow.Content = register;
        }
    }
}
