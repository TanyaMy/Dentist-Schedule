using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Presentation.Models;

namespace Lab1.Domain.Managers.Concrete
{
    class PatientsManager : IPatientsManager
    {
        private List<Patient> _patients;

        public PatientsManager()
        {
            _patients = new List<Patient>();

            for (int i = 0; i < 15; i++)
            {
                _patients.Add(new Patient
                {
                    Name = $"PatientName{i}",
                    Shedule = new List<Visit>
                    {
                        new Visit
                        {
                            DoctorId = 1,
                            Description = $"Descr{i}",
                            Date = DateTime.Now.AddDays(i).AddHours(i)
                        },
                        new Visit
                        {
                            DoctorId = 1,
                            Description = $"Descr{i}",
                            Date = DateTime.Now.AddDays(i + 5).AddHours(i + 8)
                        }
                    }
                });
            }
        }

        public List<Patient> GetPatients()
        {
            return _patients;
        }

        public List<Patient> GetPatientsByDoctorId(int doctorId)
        {
            return _patients.Where(p => p.Shedule.Any(s => s.DoctorId == doctorId)).ToList();
        }
    }
}
