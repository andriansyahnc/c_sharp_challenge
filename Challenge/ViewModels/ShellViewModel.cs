using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenge.ViewModels
{
    public class ShellViewModel: Conductor<object>
    {
        private HomeViewModel _homeVM;

        public ShellViewModel(HomeViewModel homeVm)
        {
            _homeVM = homeVm;
            ActivateItem(_homeVM);
        }

    }
}
