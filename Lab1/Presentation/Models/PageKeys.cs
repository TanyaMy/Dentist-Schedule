using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Presentation.Views;

namespace Lab1.Presentation.Models
{
    public enum PageKeys
    {
        [PageType(typeof(LoginPage))]
        Login,
        [PageType(typeof(RegistrationPage))]
        Registration,
        [PageType(typeof(PatientMenuPage))]
        PatientMenu,
        [PageType(typeof(AppointmentPage))]
        Appointment,
        [PageType(typeof(DoctorMenuPage))]
        DoctorMenu,
        [PageType(typeof(PatientReviewPage))]
        PatientReview,
        [PageType(typeof(PatientSearchPage))]
        PatientSearch
    }

    public class PageTypeAttribute : Attribute
    {
        public PageTypeAttribute(Type pageType)
        {
            PageType = pageType;
        }

        public Type PageType { get; private set; }
    }
}
