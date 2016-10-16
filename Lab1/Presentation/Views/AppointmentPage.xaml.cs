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
    public sealed partial class AppointmentPage : Page
    {
        public AppointmentPage()
        {
            this.InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PurposeCB.SelectedItem.ToString() == "Consultation")
                DoctorsCB.ItemsSource = new List<string> { "No", "Andreev B", "Petrova S",
            "Semenov Р", "Sidorov A", "Smith J"};
            else if (PurposeCB.SelectedItem.ToString() == "Cosmetology")
                DoctorsCB.ItemsSource = new List<string> { "No", "Alexin B", "Braun S",
            "Sokolova Р", "Red A", "Sen J"};
            else if (PurposeCB.SelectedItem.ToString() == "Filling")
                DoctorsCB.ItemsSource = new List<string> { "No", "Barry B", "Black S",
            "Sant Р", "Tall A"};
            else if (PurposeCB.SelectedItem.ToString() == "Сhildren's dentistry")
                DoctorsCB.ItemsSource = new List<string> { "No", "Carry B", "Doddy S",
            "Supper Р", "Querry A"};
            else if (PurposeCB.SelectedItem.ToString() == "Surgery")
                DoctorsCB.ItemsSource = new List<string> { "No", "Olovjov B", "Smith S",
            "Taranov Р"};
            else if (PurposeCB.SelectedItem.ToString() == "Other")
                DoctorsCB.ItemsSource = new List<string> { "Cherry K" };
            else DoctorsCB.ItemsSource = new List<string> { "Cherry K", "Carry B", "Doddy S", "Andreev B" };
        }

        
        private void chooseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (chooseBtn.Content.ToString() == Char.ConvertFromUtf32(0xE73E))
                chooseBtn.Content = "";
            else
                chooseBtn.Content = Char.ConvertFromUtf32(0xE73E);
        }
    }
}
