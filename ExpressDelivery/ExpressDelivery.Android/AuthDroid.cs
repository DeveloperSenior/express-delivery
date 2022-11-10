using System;
using System.Threading.Tasks;
using FireAuth.Droid;
using Xamarin.Forms;
using Firebase.Auth;
using ExpressDelivery.Models;
using ExpressDelivery.Common;

[assembly: Dependency(typeof(AuthDroid))]
namespace FireAuth.Droid
{
    public class AuthDroid : IAuth
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
        }

        public async Task<string> LoginWithGoogle(string email, string password)
        {

            return null;
        }

        public async Task<bool> SignUpWithEmailPassword(string username, string email, string password)
        {
            var authResult = await FirebaseAuth.Instance
                                .CreateUserWithEmailAndPasswordAsync(email, password);

            var userProfileChangeRequestBuilder = new UserProfileChangeRequest.Builder();
            userProfileChangeRequestBuilder.SetDisplayName(username);

            var userProfileChangeRequest = userProfileChangeRequestBuilder.Build();
            await authResult.User.UpdateProfileAsync(userProfileChangeRequest);

            return await Task.FromResult(true);
        }

        public bool IsSignIn()
        => FirebaseAuth.Instance.CurrentUser != null;
        public UserSession GetCurrentUser()
        {
            var userFb = FirebaseAuth.Instance.CurrentUser;
            var user = new UserSession
            {
                Name = userFb.DisplayName,
                Email = userFb.Email,
                ID = userFb.Uid
            };

            return user;
        }
            

        public bool SignOut()
        {
            try
            {
                FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine( e.GetBaseException().Message);
                return false;
            }
        }


    }
}