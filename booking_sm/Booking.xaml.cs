using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : UserControl
    {

        public ObservableCollection<Coffee> Coffees { get; set; }
        public Coffee ID { get; private set; }

        public Booking()
        {
            InitializeComponent();

            DataContext = this;

            Coffees = new ObservableCollection<Coffee>();
            LoadCoffeeDataFromDatabase();
        }
        private void LoadCoffeeDataFromDatabase()
        {

            string connectionString = "Data Source=DESKTOP-TESA3TI;Initial Catalog=RegistrationDatabase;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string query = "SELECT Name, ImagePath, Price FROM CoffeeTable";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Coffee coffee = new Coffee
                            {
                                Name = reader["Name"].ToString(),
                                ImagePath = reader["ImagePath"].ToString(),
                                Price = (int)Convert.ToDecimal(reader["Price"])
                            };


                            Coffees.Add(coffee);
                        }
                    }
                }
            }
        }

    
    }
}
