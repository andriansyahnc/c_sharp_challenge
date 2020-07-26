using Challenge.Helpers;
using Devart.Data.MySql;
using System;

namespace Challenge.Models
{
    public class SessionHelper : ISessionHelper
    {
        private string _connectionString;
        private AuthenticatedUsers user;
        public SessionHelper()
        {
            _connectionString = DBHelper.GetConnectionString();
        }

        public bool IsAuthenticated() {
            if (Session.Id > 0) {
                return true;
            }
            return false;
        }

        public AuthenticatedUsers Authenticate(string username, string password)
        {
            user = new AuthenticatedUsers();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT id, username FROM user WHERE username=@name AND password=@password", conn);
                command.Parameters.Add("@name", username);
                command.Parameters.Add("@password", password);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user.Username = reader.GetString("username");
                    user.Id = reader.GetInt32("id");
                    Session.Id = user.Id;
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }

            return user;
        }
    }
}
