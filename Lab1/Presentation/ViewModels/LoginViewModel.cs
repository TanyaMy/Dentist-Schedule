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

        private bool _isErrorMessageVisible;
        private string _errorMessage;

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

        private void Login()
        {
            HideErrorMessage();

            try
            {
                CheckFields();
            }
            catch (Exception ex)
            {
                HandleError(ex);
                return;
            }

            string message = "";

            if (Email.Equals(PatientEmail, StringComparison.OrdinalIgnoreCase))
            {
                if (Password == PatientPassword)
                {
                    message = "Hello, Patient! You are logged in!";
                    NavigationService.NavigateTo(PageKeys.PatientMenu);
                }                      
            }           
            DialogService.ShowMessage(message, "Authorization");
        }

        private void HideErrorMessage()
        {
            ErrorMessageVisibility = false;

            ErrorMessage = string.Empty;
        }

        private void HandleError(Exception ex)
        {
            ErrorMessage = ex.Message;

            ErrorMessageVisibility = true;
        }

        private void CheckFields()
        {
            if (Email.Length == 0)
            {
                throw new Exception("You haven't entered email or phone!");
            }

            if (Password.Length == 0)
            {
                throw new Exception("You haven't entered password!");
            }
            if (!Email.Equals(PatientEmail, StringComparison.OrdinalIgnoreCase))
                throw new Exception("Wrong email or phone!");

            else if (Email.Equals(PatientEmail, StringComparison.OrdinalIgnoreCase))
            {
                if (Password != PatientPassword)
                {
                    throw new Exception("Wrong password!");
                }
            }

        }
        
    }
}