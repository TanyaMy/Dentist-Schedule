using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Media;
using GalaSoft.MvvmLight.Command;
using Lab1.Domain.Managers;
using Lab1.Presentation.ViewModels.Common;
using Lab1.Presentation.Models;

namespace Lab1.Presentation.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly IAuthenticationManager _authenticationManager;

        private readonly Brush DEFAULT_BACKGROUND = new SolidColorBrush(Colors.White);
        private readonly Brush ERROR_BACKGROUND = new SolidColorBrush(Colors.OrangeRed);
        private readonly Brush SUCCESS_BACKGROUND = new SolidColorBrush(Colors.GreenYellow);

        private string _name;
        private string _surname;
        private string _phone;
        private string _address;
        private DateTime _birthDate;
        private string _login;
        private string _password;
        private string _confirmPassword;

        private Brush _nameBackground;
        private Brush _surnameBackground;
        private Brush _phoneBackground;
        private Brush _addressBackground;
        private Brush _loginBackground;
        private Brush _passwordBackground;
        private Brush _confirmPasswordBackground;

        private bool _isErrorMessageVisible;
        private string _errorMessage;

        public RegistrationViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

            SubmitCommand = new RelayCommand(Register);

            NameBackground = DEFAULT_BACKGROUND;
            SurnameBackground = DEFAULT_BACKGROUND;
            PhoneBackground = DEFAULT_BACKGROUND;
            AddressBackground = DEFAULT_BACKGROUND;
            LoginBackground = DEFAULT_BACKGROUND;
            PasswordBackground = DEFAULT_BACKGROUND;
            ConfirmPasswordBackground = DEFAULT_BACKGROUND;
        }

        public ICommand SubmitCommand { get; }

        public string Name
        {
            get { return _name; }
            set
            {
                Set(() => Name, ref _name, value); 

                if (IsFieldEmpty(Name))
                {
                    NameBackground = ERROR_BACKGROUND;
                    HandleError("Name is required");
                }
                else
                {
                    NameBackground = SUCCESS_BACKGROUND;
                }
            }
        }

        public Brush NameBackground
        {
            get { return _nameBackground; }
            set { Set(() => NameBackground, ref _nameBackground, value); }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                Set(() => Surname, ref _surname, value);

                if (IsFieldEmpty(Surname))
                {
                    SurnameBackground = ERROR_BACKGROUND;
                    HandleError("Surname is required");
                }
                else
                {
                    SurnameBackground = SUCCESS_BACKGROUND;
                }
            }
        }

        public Brush SurnameBackground
        {
            get { return _surnameBackground; }
            set { Set(() => SurnameBackground, ref _surnameBackground, value); }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                Set(() => Phone, ref _phone, value);
                
                if (IsFieldEmpty(Phone))
                {
                    PhoneBackground = ERROR_BACKGROUND;
                    HandleError("Phone is required");
                }
                else
                {
                    PhoneBackground = SUCCESS_BACKGROUND;
                }
            }
        }

        public Brush PhoneBackground
        {
            get { return _phoneBackground; }
            set { Set(() => PhoneBackground, ref _phoneBackground, value); }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                Set(() => Address, ref _address, value);
                
                if (IsFieldEmpty(Address))
                {
                    AddressBackground = ERROR_BACKGROUND;
                    HandleError("Address is required");
                }
                else
                {
                    AddressBackground = SUCCESS_BACKGROUND;
                }
            }
        }

        public Brush AddressBackground
        {
            get { return _addressBackground; }
            set { Set(() => AddressBackground, ref _addressBackground, value); }
        }

        public DateTime Birthday
        {
            get { return _birthDate; }
            set { Set(() => Birthday, ref _birthDate, value); }
        }

        public string Login
        {
            get { return _login; }
            set
            {
                Set(() => Login, ref _login, value);

                if (!IsLoginValid())
                {
                    LoginBackground = ERROR_BACKGROUND;
                    HandleError("Login is invalid");
                }
                else
                {
                    LoginBackground = SUCCESS_BACKGROUND;
                }
            }
        }

        public Brush LoginBackground
        {
            get { return _loginBackground; }
            set { Set(() => LoginBackground, ref _loginBackground, value); }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                Set(() => Password, ref _password, value);
                
                if (!IsPasswordValid())
                {
                    PasswordBackground = ERROR_BACKGROUND;
                    HandleError("Your password has to contain not less than 6 symbols!");
                }
                else
                {
                    PasswordBackground = SUCCESS_BACKGROUND;
                }
            }
        }

        public Brush PasswordBackground
        {
            get { return _passwordBackground; }
            set { Set(() => PasswordBackground, ref _passwordBackground, value); }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                Set(() => ConfirmPassword, ref _confirmPassword, value);

                if (!IsPasswordConfirmationCorrect())
                {
                    ConfirmPasswordBackground = ERROR_BACKGROUND;
                    HandleError("Passwords don't match");
                }
                else
                {
                    ConfirmPasswordBackground = SUCCESS_BACKGROUND;
                }
            }
        }

        public Brush ConfirmPasswordBackground
        {
            get { return _confirmPasswordBackground; }
            set { Set(() => ConfirmPasswordBackground, ref _confirmPasswordBackground, value); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { Set(() => ErrorMessage, ref _errorMessage, value); }
        }

        public bool ErrorMessageVisibility
        {
            get { return _isErrorMessageVisible; }
            set { Set(() => ErrorMessageVisibility, ref _isErrorMessageVisible, value); }
        }

        private void Register()
        {
            HideErrorMessage();

            try
            {
                CheckFields();
            }
            catch (Exception ex)
            {
                HandleError(ex.Message);
                return;
            }

            _authenticationManager.Register(_login, _password);
            _authenticationManager.UpdateAccountInfo(_name, _surname, _phone, _birthDate, _address);

            DialogService.ShowMessageBox("Registration is successful", "Registration");
            NavigationService.NavigateTo(PageKeys.PatientMenu);
        }

        private void HideErrorMessage()
        {
            ErrorMessageVisibility = false;

            ErrorMessage = string.Empty;
        }

        private void HandleError(string message)
        {
            ErrorMessage = message;

            ErrorMessageVisibility = true;
        }

        private void CheckFields()
        {
            Name = Name;
            Surname = Surname;
            Phone = Phone;
            Address = Address;
            Login = Login;
            Password = Password;
            ConfirmPassword = ConfirmPassword;

            if (IsFieldEmpty(_name) ||
                IsFieldEmpty(_surname) ||
                IsFieldEmpty(_phone) ||
                IsFieldEmpty(_address))
            {
                throw new Exception("You have to fill required fields!");
            }

            if (IsLoginValid())
            {
                throw new Exception("Your e-mail has to contain not less than 6 symbols!");
            }

            if (IsPasswordValid())
            {
                throw new Exception("Your password has to contain not less than 6 symbols!");
            }

            if (IsPasswordConfirmationCorrect())
            {
                throw new Exception("Passwords don't match");
            }
        }

        private bool IsFieldEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        private bool IsLoginValid()
        {
            return !IsFieldEmpty(_login) && !(_login.Length < 6);
        }

        private bool IsPasswordValid()
        {
            return !IsFieldEmpty(_password) && !(_password.Length < 6);
        }

        private bool IsPasswordConfirmationCorrect()
        {
            return IsPasswordValid() && _password == _confirmPassword;
        }
    }
}
