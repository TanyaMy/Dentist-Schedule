﻿using GalaSoft.MvvmLight.Command;
using Lab1.Domain.Managers;
using Lab1.Presentation.Models;
using Lab1.Presentation.ViewModels.Common;
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

        public DoctorsScheduleViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

            _doctorList = new List<string> {"Andreev B - Consultation", "Petrova S - Consultation",
            "Semenov Р - Cosmetology", "Sidorov A - Cosmetology", "Smith J - Filling",
            "Alexin B - Filling", "Braun S - Сhildren's dentistry", "Sokolova Р - Сhildren's dentistry",
            "Red A - Surgery", "Sen J - Surgery"};
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

        public string Schedule
        {
            get
            {
                return _schedule;
            }
            set { Set(() => Schedule, ref _schedule, value); }
        }
    }
}
