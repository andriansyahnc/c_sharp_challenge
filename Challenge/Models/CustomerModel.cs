namespace Challenge.Models
{
    public class CustomerModel
    {
        public CustomerModel(){}

        public CustomerModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
