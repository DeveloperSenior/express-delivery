using ExpressDelivery.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpressDelivery.Common
{
    public interface IAuth
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<string> LoginWithGoogle(string email, string password);
        Task<bool> SignUpWithEmailPassword(string username, string email, string password);
        bool SignOut();
        bool IsSignIn();
        UserSession GetCurrentUser();
    }
}
