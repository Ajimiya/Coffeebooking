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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

            string connectionString = "Data Source=DESKTOP-TESA3TI;Initial Catalog=RegistrationDatabase;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO UserRegister (FirstName, LastName, Age, Place, Gender, ContactNumber, Email, Username, Password) " +
                                         "VALUES (@FirstName, @LastName, @Age, @Place, @Gender, @ContactNumber, @Email, @Username, @Password)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", FirstNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@LastName", LastNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@Age", AgeTextBox.Text);
                        cmd.Parameters.AddWithValue("@Place", PlaceTextBox.Text);

                        // Assuming you want to store the gender as a string
                        cmd.Parameters.AddWithValue("@Gender", (MaleRadioButton.IsChecked == true) ? "Male" : "Female");

                        cmd.Parameters.AddWithValue("@ContactNumber", ContactNumberTextBox.Text);
                        cmd.Parameters.AddWithValue("@Email", EmailTextBox.Text);
                        cmd.Parameters.AddWithValue("@Username", UsernameTextBox.Text);
                        cmd.Parameters.AddWithValue("@Password", PasswordBox.Password);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Registration successful!");


                        login login = new login();
                        Window mainWindow = Application.Current.MainWindow;
                        mainWindow.Content = login;
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
            login login = new login();

            Window mainWindow = Application.Current.MainWindow;
            mainWindow.Content = login;
        }
    }
}
