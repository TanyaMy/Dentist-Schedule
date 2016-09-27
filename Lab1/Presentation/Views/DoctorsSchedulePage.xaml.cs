using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab1.Presentation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DoctorsSchedulePage : Page
    {
        public DoctorsSchedulePage()
        {
            this.InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DoctorsCB.SelectedItem.ToString() == "Andreev B - Consultation")
                ScheduleTB.Text = "Mon-Wed: 10-14, 16-19" + "\n" +
                    "Fri: 12-20" + "\n" + "Sun:12-18";
            else if (DoctorsCB.SelectedItem.ToString() == "Petrova S - Consultation")
                ScheduleTB.Text = "Mon-Tue: 11-15, 17-20" + "\n" +
                    "Thur: 12-20" + "\n" + "Sat:12-14";
            else if (DoctorsCB.SelectedItem.ToString() == "Semenov Р - Cosmetology")
                ScheduleTB.Text = "Tue-Fri: 10-14, 16-19" + "\n" +
                    "Sat: 09-12, 15-19" + "\n" + "Sun:12-18";
            else if (DoctorsCB.SelectedItem.ToString() == "Sidorov A - Cosmetology")
                ScheduleTB.Text = "Tue-Wed: 10-14, 16-19" + "\n" +
                    "Fri: 10-12, 14-16" + "\n" + "Sun:12-18";
            else if (DoctorsCB.SelectedItem.ToString() == "Smith J - Filling")
                ScheduleTB.Text = "Mon-Wed: 10-14, 16-19" + "\n" +
                    "Fri: 10-18" + "\n" + "Sun:12-18";
            else if (DoctorsCB.SelectedItem.ToString() == "Alexin B - Filling")
                ScheduleTB.Text = "Tue-Wed: 10-14, 16-19" + "\n" +
                    "Thur: 12-14, 16-19" + "\n" + "Sun:12-18";
            else if (DoctorsCB.SelectedItem.ToString() == "Braun S - Сhildren's dentistry")
                ScheduleTB.Text = "Mon-Wed: 10-14, 16-19" + "\n" +
                    "Fri: 12-13, 15-20" + "\n" + "Sun:14-18";
            else if (DoctorsCB.SelectedItem.ToString() == "Sokolova Р - Сhildren's dentistry")
                ScheduleTB.Text = "Mon-Wed: 10-14, 16-19" + "\n" +
                    "Thur: 12-20" + "\n" + "Sat:12-18";
            else if (DoctorsCB.SelectedItem.ToString() == "Red A - Surgery")
                ScheduleTB.Text = "Mon-Wed: 10-14, 16-19" + "\n" +
                    "Fri: 12-20" + "\n" + "Sun:12-18";
            else if (DoctorsCB.SelectedItem.ToString() == "Sen J - Surgery")
                ScheduleTB.Text = "Mon-Wed: 10-14, 16-19" + "\n" +
                    "Thur: 11-16" + "\n" + "Sat:10-17";
        }
    }
}
