using Caliburn.Micro;
using Challenge.EventModels;
using Challenge.Models;
using Challenge.ViewModels;

namespace Challenge.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<CustomerTransactionEvent>
    {
        private HomeViewModel _homeVM;
        private CustomerViewModel _customerVM;
        private IEventAggregator _events;

        public ShellViewModel(ISessionHelper _session, IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
            if (_session.IsAuthenticated() != true) {
                IWindowManager manager = new WindowManager();
                manager.ShowWindow(new LoginViewModel(_session, _events), null, null);
            }
            _homeVM = new HomeViewModel();
            ActivateItem(_homeVM);
        }

        public ShellViewModel(HomeViewModel homeVm)
        {
            _homeVM = homeVm;
            ActivateItem(_homeVM);
        }

        public void HomeMenu()
        {
            _homeVM = new HomeViewModel();
            ActivateItem(_homeVM);
        }

        public void CustomerMenu()
        {
            _customerVM = new CustomerViewModel(_events);
            ActivateItem(_customerVM);
        }

        public void Handle(CustomerTransactionEvent message)
        {
            CustomerMenu();
        }
    }
}
