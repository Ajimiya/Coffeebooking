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
    /// Interaction logic for Conatct.xaml
    /// </summary>
    public partial class Conatct : UserControl
    {
        public Conatct()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;
            string message = MessageTextBox.Text;

            // Define the connection string for your database
            string connectionString = "Data Source=DESKTOP-TESA3TI;Initial Catalog=RegistrationDatabase;Integrated Security=True";

            // Create a SQL connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Define the SQL INSERT statement
                string insertQuery = "INSERT INTO Contact (Name, Email, Message) VALUES (@Name, @Email, @Message)";

                // Create a SqlCommand object
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Message", message);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Submitted successfully..! we will reach you soon!");


                    NameTextBox.Text = "";
                    EmailTextBox.Text = "";
                    MessageTextBox.Text = "";
                }
            }
        }
    }
}
