using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Presentation.Models
{
    public class Patient
    {
        public string Name { get; set; }

        public List<Visit> Shedule { get; set; }
    }
}
