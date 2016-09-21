using GalaSoft.MvvmLight.Command;
using Lab1.Domain.Managers;
using Lab1.Presentation.Models;
using Lab1.Presentation.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab1.Presentation.ViewModels
{
    public class PatientMenuViewModel : ViewModelBase
    {
        private readonly IAuthenticationManager _authenticationManager;

        private readonly ICommand _goBackCommand;

        public PatientMenuViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

            _goBackCommand = new RelayCommand(NavigationService.GoBack);
            ReceptionCommand = new RelayCommand(() => NavigationService.NavigateTo(PageKeys.Appointment));
        }

        public ICommand GoBackCommand => _goBackCommand;
        public ICommand ReceptionCommand { get; }
    }
}
