using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Command;

namespace Lab1.Presentation.ViewModels.Common
{
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        protected readonly ICommand _goBackCommand;

        public ViewModelBase()
        {
            NavigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            DialogService = new DialogService();

            _goBackCommand = new RelayCommand(NavigationService.GoBack);
        }

        protected INavigationService NavigationService { get; }

        protected IDialogService DialogService { get; }

        public ICommand GoBackCommand { get; }        
    }
}
