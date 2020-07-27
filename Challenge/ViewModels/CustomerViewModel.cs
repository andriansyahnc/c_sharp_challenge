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
    public class CustomerViewModel : Screen
    {
        private DataView customerData;
        private IWindowManager manager;
        private IEventAggregator _events;

        private CustomerModel _selectedItem;

        private int _filterId = 0;
        private string _filterFirstName = "";
        private string _filterLastName = "";

        public string FilterLastName
        {
            get { return _filterLastName; }
            set
            {
                _filterLastName = value;
                NotifyOfPropertyChange(() => FilterLastName);
            }
        }


        public string FilterFirstName
        {
            get { return _filterFirstName; }
            set
            {
                _filterFirstName = value;
                NotifyOfPropertyChange(() => FilterFirstName);
            }
        }


        public int FilterID
        {
            get { return _filterId; }
            set
            {
                _filterId = value;
                NotifyOfPropertyChange(() => FilterID);
            }
        }


        public CustomerModel SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; NotifyOfPropertyChange(() => SelectedItem); }
        }

        private BindableCollection<CustomerModel> customerModel;

        public BindableCollection<CustomerModel> Customer
        {
            get { return customerModel; }
            set
            {
                customerModel = value;
                NotifyOfPropertyChange(() => Customer);
            }
        }


        public CustomerViewModel(IEventAggregator events)
        {
            _events = events;
            Customer = new BindableCollection<CustomerModel>(GetCustomer());
            manager = new WindowManager();
        }

        public DataView CustomerData
        {
            get { return customerData; }
            set
            {
                if (customerData == value)
                {
                    return;
                }
                customerData = value;
                NotifyOfPropertyChange(() => CustomerData);
            }
        }

        private List<CustomerModel> GetCustomer()
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            string connectionString = DBHelper.GetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                List<string> where = new List<string>();
                StringBuilder query = new StringBuilder("SELECT id, first_name, last_name FROM customer");
                Dictionary<string, string> whereParams = new Dictionary<string, string>();
                if (FilterID > 0)
                {
                    where.Add("ID = @Id");
                    whereParams.Add("@Id", FilterID.ToString());
                }
                if (FilterFirstName != "")
                {
                    where.Add("first_name LIKE @First");
                    whereParams.Add("@First", "%" + FilterFirstName + "%");
                }
                if (FilterLastName != "")
                {
                    where.Add("last_name LIKE @Last");
                    whereParams.Add("@Last", "%" + FilterLastName + "%");
                }

                if (where.Count > 0)
                {
                    query.Append(" WHERE " + String.Join(" AND ", where.ToArray()));
                }

                MySqlCommand command = new MySqlCommand(query.ToString(), conn);
                foreach (var param in whereParams.ToArray())
                {
                    command.Parameters.Add(param.Key, param.Value);
                }
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerModel model = new CustomerModel();
                        model.Id = reader.GetInt32("id");
                        model.FirstName = reader.GetString("first_name");
                        model.LastName = reader.GetString("last_name");
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

        public void AddMenu()
        {
            manager.ShowWindow(new CreateUpdateViewModel(_events), null, null);
        }

        public void EditMenu()
        {
            manager.ShowWindow(new CreateUpdateViewModel(_events, SelectedItem), null, null);
        }

        public void DeleteMenu()
        {
            manager.ShowWindow(new DialogueViewModel(_events, SelectedItem), null, null);
        }

        public void FilterButton()
        {
            Customer = new BindableCollection<CustomerModel>(GetCustomer());
            Console.WriteLine("Ganteng");
        }

    }
}
