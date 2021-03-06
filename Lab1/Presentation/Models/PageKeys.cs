﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Presentation.ViewModels;
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
        [PageType(typeof(MainPage))]
        Main,
        [PageType(typeof(DoctorsSchedulePage))]
        DoctorsSchedule
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
