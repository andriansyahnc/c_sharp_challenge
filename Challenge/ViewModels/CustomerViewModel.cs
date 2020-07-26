using Caliburn.Micro;
using Challenge.EventModels;
using Challenge.Helpers;
using Challenge.Models;
using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;

namespace Challenge.ViewModels
{
    public class CustomerViewModel : Screen
    {
        private DataView customerData;
        private IWindowManager manager;
        private IEventAggregator _events;

        private CustomerModel _selectedItem;

        public CustomerModel SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; NotifyOfPropertyChange(() => SelectedItem); }
        }

        public BindableCollection<CustomerModel> Customer { get; set; }

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
                MySqlCommand command = new MySqlCommand("SELECT id, first_name, last_name FROM customer", conn);
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

        public void RefreshMenu()
        {
            Customer = new BindableCollection<CustomerModel>(GetCustomer());
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

    }
}
