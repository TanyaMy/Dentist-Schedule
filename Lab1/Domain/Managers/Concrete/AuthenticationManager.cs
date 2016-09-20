using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Managers.Concrete
{
    class AuthenticationManager : IAuthenticationManager
    {
        public void Login(string email, string password)
        {
            //TODO: Implement logging in
        }

        public void Register(string email, string password)
        {
            //TODO: Implement registration
        }

        public void UpdateAccountInfo(string name, string surname, string phone, DateTime birthday, string address)
        {
            //TODO: Implement updating account info
        }
    }
}
