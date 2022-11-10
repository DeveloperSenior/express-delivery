using Acr.UserDialogs;
using ExpressDelivery.Common;
using ExpressDelivery.Framework;
using ExpressDelivery.Models;
using ExpressDelivery.Resources;
using ExpressDelivery.Views;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ExpressDelivery.ViewModels
{
    public class SingUpViewModel: BaseViewModel
    {

        FirebaseClient firebaseClient = new FirebaseClient(Constants.DB_FIREBASE);

        private string password;
        private string email;
        private string username;
        private string ID;
        private string address;
        private string phone;

        public SingUpViewModel()
        {
            SignInCommand = new Command(OnSignIn);
            SignUpCommand = new Command(OnSignUp);
        }

        private async void OnSignUp()
        {
            if (
                string.IsNullOrEmpty(this.Username) ||
                string.IsNullOrEmpty(this.Address) ||
                string.IsNullOrEmpty(this.Email) ||
                string.IsNullOrEmpty(this.Phone) ||
                string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar todos los datos",
                    "Aceptar");
                return;
            }
            try
            {
                UserDialogs.Instance.ShowLoading("Procesando");
                var authService = DependencyService.Resolve<IAuth>();
                if (await authService.SignUpWithEmailPassword(Username, Email, Password))
                {


                    var toUpdatePerson = (await firebaseClient
                                   .Child(Constants.TABLE_USERS)
                                   .OnceAsync<UserSession>())
                                   .Where(a => a.Object.Email == Email).FirstOrDefault();

                    if (toUpdatePerson == null)
                    {
                        var user = authService.GetCurrentUser();
                        await firebaseClient
                                .Child(Constants.TABLE_USERS)
                                .PostAsync(new UserSession()
                                {
                                    ID = user.ID,
                                    Address = Address,
                                    Email = user.Email,
                                    Name = user.Name,
                                    Phone = Phone
                                });

                    }

                    App.Current.MainPage = new Views.Menu();
                }
                else
                {
                    Console.WriteLine("A problem occurs when creating a user");
                    await App.Current.MainPage.DisplayAlert("SignUp", "Ha ocurrido un error.", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                await App.Current.MainPage.DisplayAlert("SignUp", "Ha ocurrido un error.", "OK");
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }

        }

        private void OnSignIn()
        {
            App.Current.MainPage = new SingInView();

        }

        #region Properties
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }
        #endregion

        #region Commands

        public ICommand SignInCommand { get; }

        public ICommand SignUpCommand { get; }

        #endregion

    }


}
