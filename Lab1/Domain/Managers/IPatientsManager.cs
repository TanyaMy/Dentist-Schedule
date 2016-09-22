using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Presentation.Models;

namespace Lab1.Domain.Managers
{
    public interface IPatientsManager
    {
        List<Patient> GetPatients();
        List<Patient> GetPatientsByDoctorId(int doctorId);
    }
}
