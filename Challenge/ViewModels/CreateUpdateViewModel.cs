using Caliburn.Micro;
using Challenge.Models;

namespace Challenge.ViewModels
{
    public class CreateUpdateViewModel : Screen
    {
        private CustomerModel _customer;
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        public CustomerModel Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                NotifyOfPropertyChange(() => Customer);
            }
        }

        public CreateUpdateViewModel()
        {
            Title = "Add Data Customer";
        }
        public CreateUpdateViewModel(CustomerModel customer)
        {
            Title = "Edit Data Customer";
            Customer = customer;
        }
    }
}
