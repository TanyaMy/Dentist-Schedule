using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace Lab1.Presentation.ViewModels.Common
{
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        public ViewModelBase()
        {
            NavigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            DialogService = new DialogService();
        }

        protected INavigationService NavigationService { get; }

        protected IDialogService DialogService { get; }
    }
}
