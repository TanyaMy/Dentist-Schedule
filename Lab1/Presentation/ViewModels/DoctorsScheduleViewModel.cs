using GalaSoft.MvvmLight.Command;
using Lab1.Domain.Managers;
using Lab1.Presentation.Models;
using Lab1.Presentation.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Lab1.Presentation.ViewModels
{
    public class DoctorsScheduleViewModel : ViewModelBase
    {
        private readonly IAuthenticationManager _authenticationManager;

        private List<string> _doctorList;
        private string _doctor;
        private string _schedule;
        private string[] _scedules;

        public DoctorsScheduleViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

            _doctorList = new List<string> {"Andreev B", "Petrova S",
            "Semenov Р", "Sidorov A", "Smith J"};
            _scedules = new string[] { "Mon-Wen: 8:00-13:00;  Fri: 10:00-13:00;  Sat: 18:00-20:00;  Sun: 12:00-19:00",
                "Mon-Thur: 13:00-20:00;  Fri: 12:00-18:00;  Sat: 12:00-20:00",
                "Tue-Fri: 8:00-16:00;  Fri: 10:00-13:00;  Sat: 18:00-20:00;  Sun: 12:00-19:00",
                "Mon-Wen: 8:00-13:00;  Thur: 10:00-13:00;  Fri: 18:00-20:00;  Sun: 12:00-15:00",
                "Tue-Thur: 8:00-13:00;  Sat: 10:00-14:00;  Sat: 16:00-18:00;  Sun: 13:00-16:00",
                "Tue-Wen: 8:00-13:00;  Thur: 9:00-16:00;  Fri: 18:00-20:00;  Sat: 14:00-20:00",
                "Mon-Sat: 8:00-13:00",
                "Wen-Sun: 8:00-13:00, 18:00-19:00" };
        }

        public List<string> DoctorList
        {
            get { return _doctorList; }
            set { Set(() => DoctorList, ref _doctorList, value); }
        }

        public string Doctor
        {
            get { return _doctor; }
            set { Set(() => Doctor, ref _doctor, value);
                Schedule = _scedules[new Random().Next(0, _scedules.Length)];
            }
        }

        public string Schedule
        {
            get { return _schedule; }
            set { Set(() => Schedule, ref _schedule, value); }
        }
    }
}
