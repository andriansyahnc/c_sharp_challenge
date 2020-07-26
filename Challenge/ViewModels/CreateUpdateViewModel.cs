using Challenge.Models;

namespace Challenge.ViewModels
{
    public class CreateUpdateViewModel
    {
        private CustomerModel _customer;
        public CreateUpdateViewModel(int id)
        {
            _customer = new CustomerModel(id);

        }
    }
}
