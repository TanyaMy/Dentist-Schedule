using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Automation;
using GalaSoft.MvvmLight.Command;
using Lab1.Domain.Managers;
using Lab1.Presentation.ViewModels.Common;

namespace Lab1.Presentation.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly IAuthenticationManager _authenticationManager;

        private readonly ICommand _goBackCommand;
        private readonly ICommand _submitCommand;

        private string _name;
        private string _surname;
        private string _phone;
        private string _address;
        private DateTime _birthDate;

        private string _login;
        private string _password;
        private string _confirmPassword;

        public RegistrationViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

            _goBackCommand = new RelayCommand(NavigationService.GoBack);
            _submitCommand = new RelayCommand(Register);
        }

        public ICommand GoBackCommand => _goBackCommand;

        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }

        public string Surname
        {
            get { return _surname; }
            set { Set(() => Surname, ref _surname, value); }
        }

        public string Phone
        {
            get { return _phone; }
            set { Set(() => Phone, ref _phone, value); }
        }

        public string Address
        {
            get { return _address; }
            set { Set(() => Address, ref _address, value); }
        }

        public DateTime Birthday
        {
            get { return _birthDate; }
            set { Set(() => Birthday, ref _birthDate, value); }
        }

        public string Login
        {
            get { return _login; }
            set { Set(() => Login, ref _login, value); }
        }

        public string Password
        {
            get { return _password; }
            set { Set(() => Password, ref _password, value); }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { Set(() => ConfirmPassword, ref _confirmPassword, value); }
        }

        private void Register()
        {
            try
            {
                CheckFields();
            }
            catch (Exception ex)
            {
                DialogService.ShowError(ex, "Registration", "OK", null);
            }

            _authenticationManager.Register(_login, _password);
            _authenticationManager.UpdateAccountInfo(_name, _surname, _phone, _birthDate, _address);

            DialogService.ShowMessageBox("Registration is successful", "Registration");
        }

        private void CheckFields()
        {
            if (_password != _confirmPassword)
            {
                throw new Exception("Passwords don't match");
            }

            if (string.IsNullOrEmpty(_login))
            {
                throw new Exception("You have to enter email");
            }
        }
    }
}
