using Caliburn.Micro;
using Challenge.Models;
using System.Windows;

namespace Challenge.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        private string _password;
        private ISessionHelper _sessionHelper;

        public LoginViewModel(ISessionHelper sessionHelper)
        {
            _sessionHelper = sessionHelper;
        }
        
        public string Username
        {
            get { return _username; }
            set {
                _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get { return _password; }
            set {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool CanLogIn {
            get
            {
                bool output = false;
                if (Username?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
        }

        public void LogIn() {
            AuthenticatedUsers users = _sessionHelper.Authenticate(Username, Password);

            if (users.Id != 0)
            {
                IWindowManager manager = new WindowManager();
                manager.ShowWindow(new ShellViewModel(), null, null);
                TryClose();
            }
            else {
                MessageBox.Show("Credential not found", "OK");
            }
        }

    }
}
