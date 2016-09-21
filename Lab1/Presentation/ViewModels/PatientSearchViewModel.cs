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
    public class PatientSearchViewModel : ViewModelBase
    {
        private readonly IAuthenticationManager _authenticationManager;

        public PatientSearchViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

            SearchCommand = new RelayCommand(() => NavigationService.NavigateTo(PageKeys.PatientReview));
        }

        public ICommand SearchCommand { get; }
    }
}
