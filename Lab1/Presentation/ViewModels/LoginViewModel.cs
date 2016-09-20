using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Lab1.Presentation.ViewModels.Common;
using Lab1.Domain.Managers;

namespace Lab1.Presentation.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private const string DoctorEmail = "doctor@nure.ua";
        private const string PatientEmail = "patient@nure.ua";
        private const string DoctorPassword = "doctor@nure.ua";
        private const string PatientPassword = "patient@nure.ua";

        private string _email;
        private string _password;
        private readonly IAuthenticationManager _authenticationManager;

        public LoginViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

            SubmitCommand = new RelayCommand(Login);

            Email = String.Empty;
            Password = String.Empty;
        }

        public ICommand SubmitCommand { get; }

        public string Email
        {
            get { return _email; }
            set { Set(() => Email, ref _email, value); }
        }

        public string Password
        {
            get { return _password; }
            set { Set(() => Password, ref _password, value); }
        }

        private void Login()
        {
            string message = "";

            if (Email.Length < 6)
            {
                message = "Your email is too short!";
            }
            else if (Password.Length == 0)
            {
                message = "You didn't entered password!";
            }
            else
            {
                if (Email.Equals(DoctorEmail, StringComparison.OrdinalIgnoreCase))
                {
                    if (Password == DoctorPassword)
                    {
                        message = "Hello, Doctor! You are logged in!";
                    }
                    else
                    {
                        message = "Hello, Doctor! Your password is wrong!";
                    }
                }
                else if (Email.Equals(PatientEmail, StringComparison.OrdinalIgnoreCase))
                {
                    if (Password == PatientPassword)
                    {
                        message = "Hello, Patient! You are logged in!";
                    }
                    else
                    {
                        message = "Hello, Patient! Your password is wrong!";
                    }
                }
                else
                {
                    message = "Wrong email!";
                }
            }

            DialogService.ShowMessage(message, "Authorization");
        }
    }
}
