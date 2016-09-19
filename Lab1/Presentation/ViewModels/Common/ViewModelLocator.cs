using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;

namespace Lab1.Presentation.ViewModels.Common
{
    public class ViewModelLocator
    {
        public LoginViewModel Login => GetViewModel<LoginViewModel>();

        private T GetViewModel<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }
    }
}
