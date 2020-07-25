using Caliburn.Micro;
using Challenge.Helpers;
using Challenge.Models;
using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Challenge.ViewModels
{
    public class CustomerViewModel: Screen
    {
        private DataView customerData;

        public BindableCollection<CustomerModel> Customer { get; set; }

        public CustomerViewModel()
        {
            Customer = new BindableCollection<CustomerModel>(GetCustomer());
        }

        public DataView CustomerData
        {
            get { return customerData; }
            set {
                if (customerData == value) {
                    return;
                }
                customerData = value;
                NotifyOfPropertyChange(() => CustomerData);
            }
        }

        private List<CustomerModel> GetCustomer() {
            List<CustomerModel> customers = new List<CustomerModel>();
            string connectionString = DBHelper.GetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT id, first_name FROM customer", conn);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerModel model = new CustomerModel();
                        model.Id = reader.GetInt32("id");
                        model.FirstName = reader.GetString("first_name");
                        customers.Add(model);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return customers;
        }

    }
}
