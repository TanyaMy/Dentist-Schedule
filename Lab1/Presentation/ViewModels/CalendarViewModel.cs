using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Domain.Managers;
using Lab1.Presentation.Models;
using Lab1.Presentation.ViewModels.Common;

namespace Lab1.Presentation.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        private readonly IPatientsManager _patientsManager;

        private List<Patient> _patients;
        private List<DateTime> _selectedDates;

        private readonly int _doctorId;

        public CalendarViewModel(IPatientsManager patientsManager)
        {
            _patientsManager = patientsManager;

            //TODO: Set doctor id from params
            _doctorId = 1;
        }

        private void InitData()
        {
            _patients = _patientsManager.GetPatientsByDoctorId(_doctorId);

            foreach (var patient in _patients)
            {
                foreach (var visit in patient.Shedule)
                {
                    if (_selectedDates.Any(x => x == visit.Date))
                        return;

                    _selectedDates.Add(visit.Date);
                }
            }
        }
    }
}
