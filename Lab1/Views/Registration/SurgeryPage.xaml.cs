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

namespace Lab1.Views.Registration
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SurgeryPage : Page
    {
        public SurgeryPage()
        {
            this.InitializeComponent();
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistrationPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            confirmBox.Hide();
            Frame.Navigate(typeof(RegistrationPage));
        }

       

        private bool notEmptyFields()
        {
            if (nameTB.Text != null && surnameTB.Text != null && addressTB != null
                && phoneTB != null && complaintsTB.Text != null) return true;
            return false;
        }
    }
}
