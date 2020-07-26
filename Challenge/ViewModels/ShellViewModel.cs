using Caliburn.Micro;

namespace Challenge.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private HomeViewModel _homeVM;
        private CustomerViewModel _customerVM;

        public ShellViewModel()
        {
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
