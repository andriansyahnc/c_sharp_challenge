using Caliburn.Micro;
using Challenge.EventModels;
using Challenge.Helpers;
using Challenge.Models;
using Devart.Data.MySql;
using System;
using System.Windows;

namespace Challenge.ViewModels
{
    public class DialogueViewModel: Screen
    {
        private IEventAggregator _events;
        private CustomerModel _customer;
        public DialogueViewModel(IEventAggregator events, CustomerModel customer)
        {
            _events = events;
            _customer = customer;
        }

        public void YesButton()
        {
            string connectionString = DBHelper.GetConnectionString();
            string query = "DELETE FROM customer WHERE id=@Id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            bool success = false;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add("@Id", _customer.Id);
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("Data Deleted ");
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

            if (success)
            {
                TryClose();
            }
        }
    }
}
