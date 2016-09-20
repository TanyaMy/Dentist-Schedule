using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Lab1.Presentation.ViewModels.Common;
using Lab1.Domain.Managers;
using Lab1.Presentation.Models;
using Lab1.Presentation.Views;

namespace Lab1.Presentation.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private const string DoctorEmail = "doctor@nure.ua";
        private const string PatientEmail = "patient@nure.ua";
        private const string DoctorPassword = "doctor@nure.ua";
        private const string PatientPassword = "patient@nure.ua";

        private readonly IAuthenticationManager _authenticationManager;

        private string _email;
        private string _password;

        public LoginViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

            SubmitCommand = new RelayCommand(Login);
            RegistrationCommand = new RelayCommand(() => NavigationService.NavigateTo(PageKeys.Registration));

            Email = String.Empty;
            Password = String.Empty;
        }

        public ICommand SubmitCommand { get; }
        public ICommand RegistrationCommand { get; }

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
            try
            {
                CheckFields();
            }
            catch (Exception ex)
            {
                //TODO: Implement red light on error
                DialogService.ShowMessage(ex.Message, "Error");
                return;
            }

            string message = "";

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

            DialogService.ShowMessage(message, "Authorization");
        }

        private void CheckFields()
        {
            if (Email.Length == 0)
            {
                throw new Exception("You didn't entered email!");
            }

            if (Email.Length < 6)
            {
                throw new Exception("Your email has to contain not less than 6 symbols!");
            }

            if (Password.Length == 0)
            {
                throw new Exception("You didn't entered password!");
            }

            if (Password.Length < 6)
            {
                throw new Exception("Your password has to contain not less than 6 symbols!");
            }

            if (!IsValidEmail(Email))
            {
                throw new Exception("Your email is incorrect!");
            }
        }

        private bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}