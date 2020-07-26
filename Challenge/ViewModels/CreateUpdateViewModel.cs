using Caliburn.Micro;
using Challenge.Models;
using System.Windows.Controls;
using Challenge.Helpers;
using System.Linq;
using System;
using Devart.Data.MySql;
using System.Windows;
using Challenge.EventModels;

namespace Challenge.ViewModels
{
    public class CreateUpdateViewModel : Screen
    {
        private CustomerModel _customer;
        private string _title;
        private readonly string _connectionString = DBHelper.GetConnectionString();
        private string _isVisible = "Visible";
        private int _id = 0;
        private string _firstname;
        private string _lastname;
        private IEventAggregator _events;

        public CustomerModel Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                NotifyOfPropertyChange(() => Customer);
            }
        }

        public string LastName
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }

        public string FirstName
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value; 
                NotifyOfPropertyChange(() => Id);
            }
        }

        public string IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                NotifyOfPropertyChange(() => IsVisible);
            }
        }

        public string TextTitle
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => TextTitle);
            }
        }

        public CreateUpdateViewModel(IEventAggregator events)
        {
            _events = events;
            TextTitle = "Add Data Customer";
            IsVisible = "Hidden";
        }
        public CreateUpdateViewModel(IEventAggregator events, CustomerModel customer)
        {
            _events = events;
            TextTitle = "Edit Data Customer";
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
        }

        public void Save()
        {
            string query = "INSERT INTO customer (first_name, last_name) VALUES (@First, @Last)";
            if (Id > 0) {
                query = "UPDATE customer SET first_name=@First, last_name=@Last WHERE id=@Id";
            }
            MySqlConnection conn = new MySqlConnection(_connectionString);
            bool success = false;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add("@First", FirstName);
                cmd.Parameters.Add("@Last", LastName);
                if (Id > 0)
                {
                    cmd.Parameters.Add("@Id", Id);
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("Data Saved ");
                success = true;
                _events.PublishOnUIThread(new CustomerTransactionEvent());
            }
            catch (Exception E)
            {
                MessageBox.Show("Something Wrong " + E.Message);
            }
            finally
            {
                conn.Close();
            }

            if (success) {
                TryClose();
            }
        }

        public void Cancel() {
            TryClose();
        }
    }
}
