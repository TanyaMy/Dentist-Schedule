using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Presentation.Models
{
    public class Visit
    {
        public int DoctorId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }
    }
}
