using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using Lab1.Presentation.Models;

namespace Lab1.Presentation.ViewModels.Common
{
    public static class Extensions
    {
        public static void NavigateTo(this INavigationService navigationService, PageKeys pageKey, params object[] parameters)
        {
            navigationService.NavigateTo(pageKey.ToString(), parameters);
        }
    }
}
