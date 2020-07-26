using Caliburn.Micro;
using Challenge.Models;
using Challenge.ViewModels;

namespace Challenge.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private HomeViewModel _homeVM;
        private CustomerViewModel _customerVM;

        public ShellViewModel(ISessionHelper _session)
        {
            if (_session.IsAuthenticated() != true) {
                IWindowManager manager = new WindowManager();
                manager.ShowWindow(new LoginViewModel(_session), null, null);
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
            _customerVM = new CustomerViewModel();
            ActivateItem(_customerVM);
        }
    }
}
