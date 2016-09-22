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

        public PatientMenuViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

            ReceptionCommand = new RelayCommand(() => NavigationService.NavigateTo(PageKeys.Appointment));

            GoDoctorSchedule = new RelayCommand(() => NavigationService.NavigateTo(PageKeys.DoctorsSchedule));
        }
        
        public ICommand ReceptionCommand { get; }

        public ICommand GoDoctorSchedule { get; }
        
    }
}
