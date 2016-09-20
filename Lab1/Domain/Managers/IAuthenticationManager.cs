using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Managers
{
    public interface IAuthenticationManager
    {
        void Login(string email, string password);

        void Register(string email, string password);

        void UpdateAccountInfo(string name, string surname, string phone, DateTime birthday, string address);
    }
}
