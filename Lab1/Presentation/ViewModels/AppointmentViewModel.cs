using GalaSoft.MvvmLight.Command;
using Lab1.Domain.Managers;
using Lab1.Presentation.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab1.Presentation.ViewModels
{
    public class AppointmentViewModel : ViewModelBase
    {
        private readonly IAuthenticationManager _authenticationManager;

        private readonly ICommand _goBackCommand;

        private List<string> _purposeList = new List<string> { "Consultation", "Cosmetology", "Filling",
            "Сhildren's dentistry", "Surgery", "Other"};
        private List<string> _doctorList = new List<string> { "No", "Andreev B", "Petrova S",
            "Semenov Р", "Sidorov A", "Smith J"};
        private string _purpose;
        private string _doctor;
        private DateTime _visitDate;
        private DateTime _visitTime;
        private string _complaints;

        public AppointmentViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

            SubmitCommand = new RelayCommand(Submit);
            _goBackCommand = new RelayCommand(NavigationService.GoBack);            
        }

        public ICommand GoBackCommand => _goBackCommand;
        public ICommand SubmitCommand { get; }

        public List<string> PurposeList
        {
            get { return _purposeList; }
            set { Set(() => PurposeList, ref _purposeList, value); }
        }

        public string Purpose
        {
            get { return _purpose; }
            set { Set(() => Purpose, ref _purpose, value); }
        }

        public List<string> DoctorList
        {
            get { return _doctorList; }
            set { Set(() => DoctorList, ref _doctorList, value); }
        }

        public string Doctor
        {
            get { return _doctor; }
            set { Set(() => Doctor, ref _doctor, value); }
        }

        public DateTime VisitDate
        {
            get { return _visitDate; }
            set { Set(() => VisitDate, ref _visitDate, value); }
        }

        public DateTime VisitTime
        {
            get { return _visitTime; }
            set { Set(() => VisitTime, ref _visitTime, value); }
        }

        public string Complaints
        {
            get { return _complaints; }
            set { Set(() => Complaints, ref _complaints, value); }
        }

        private void Submit()
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
            
            DialogService.ShowMessage("Thanks! We are waiting for you!", "Appointment");
        }

        private void CheckFields()
        {
            if (
                   (string.IsNullOrEmpty(_complaints)) || (!_purposeList.Contains(_purpose))
                    || (!_doctorList.Contains(_doctor))
               )
            {
                throw new Exception("You have to fill required fields!");
            }
        }      
        
    }
}

