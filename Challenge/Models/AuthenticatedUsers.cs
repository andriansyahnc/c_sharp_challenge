namespace Challenge.Models
{
    public class AuthenticatedUsers
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public AuthenticatedUsers()
        {
            Id = 0;
        }
    }
}
