using GalaSoft.MvvmLight.Command;
using Lab1.Domain.Managers;
using Lab1.Presentation.Models;
using Lab1.Presentation.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Lab1.Presentation.ViewModels
{
    public class AppointmentViewModel : ViewModelBase
    {
        private readonly IAuthenticationManager _authenticationManager;

        private List<string> _purposeList;
        private List<string> _doctorList;
        private string _purpose;
        private string _doctor;
        private DateTime _visitDate;
        private DateTime _visitTime;
        private string _complaints;
        private string _chooseBtnContent;

        private bool _isErrorMessageVisible;
        private string _errorMessage;

        public AppointmentViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

            _purposeList = new List<string> { "Consultation", "Cosmetology", "Filling",
            "Сhildren's dentistry", "Surgery", "Other"};

            _purpose = "Consultation";

            _doctor = "No";

            _chooseBtnContent = Char.ConvertFromUtf32(0xE73E);

            _doctorList = new List<string> { "No", "Andreev B", "Petrova S",
            "Semenov Р", "Sidorov A", "Smith J"};

            SubmitCommand = new RelayCommand(Submit);

            LookScheduleCommand = new RelayCommand(() => NavigationService.NavigateTo(PageKeys.DoctorsSchedule));
        }

        public ICommand SubmitCommand { get; }

        public ICommand LookScheduleCommand { get; }

        public List<string> PurposeList
        {
            get { return _purposeList; }
            set { Set(() => PurposeList, ref _purposeList, value); }
        }

        public string Purpose
        {
            get { return _purpose;  }
            set { Set(() => Purpose, ref _purpose, value); }
        }

        public List<string> DoctorList
        {
            get
            {
                return _doctorList;
            }
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

        private void Submit()
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

            string confirm = "Dear Patient, thanks for your registration!"
                + "\n" + "The number of your request is 46512." + "\n" +
                "We are waiting for you on Monday, 11.10.16 at 8:30."
               + "\n" + "Your doctor is ";
            string doctor;
            if (_doctor == "No")
                doctor = "Ivanov I";
            else doctor = _doctor;
            confirm += doctor + ".";

            DialogService.ShowMessage(confirm, "Appointment");
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
            if ((string.IsNullOrEmpty(_complaints)))                 
            {
                throw new Exception("Please, fill Complaints field");
            }
        }
       
    }
}

