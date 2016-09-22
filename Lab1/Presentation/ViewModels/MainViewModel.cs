using GalaSoft.MvvmLight.Command;
using Lab1.Domain.Managers;
using Lab1.Presentation.Models;
using Lab1.Presentation.ViewModels.Common;
using System.Windows.Input;

namespace Lab1.Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAuthenticationManager _authenticationManager;

        public MainViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

            RegistrationCommand = new RelayCommand(() => NavigationService.NavigateTo(PageKeys.Registration));

            LogInCommand = new RelayCommand(() => NavigationService.NavigateTo(PageKeys.Login));
        }

        public ICommand RegistrationCommand { get; }

        public ICommand LogInCommand { get; }
    }
}
