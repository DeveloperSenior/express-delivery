using Acr.UserDialogs;
using ExpressDelivery.Common;
using ExpressDelivery.Framework;
using ExpressDelivery.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ExpressDelivery.ViewModels
{
    public class SingInViewModel: BaseViewModel
    {
        private string password;
        private string email;
        public SingInViewModel() { 
            SignInCommand = new Command(OnSignIn);
            SignUpCommand = new Command(OnSignUp);
        }
        private async void OnSignIn()
        {
            if (
                string.IsNullOrEmpty(this.Email)||
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
                var authService = DependencyService.Resolve<IAuth>();
                UserDialogs.Instance.ShowLoading("Procesando");
                var token = await authService.LoginWithEmailPassword(Email, Password);

                if (token != "")
                {
                    //await Shell.Current.GoToAsync("//MainPage");
                    App.Current.MainPage = new Views.Menu();
                }
                else
                {
                    ShowError();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                await App.Current.MainPage.DisplayAlert("SignIn", "Ocurrio un error "+ ex.Message, "OK");
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }
        async private void ShowError()
        {
            await App.Current.MainPage.DisplayAlert("Autenticación Fallida", "E-mail o password incorrecto. Intente de nuevo!", "OK");
        }
        private void OnSignUp()
        {
            //await Shell.Current.GoToAsync("//SingUpView")
            App.Current.MainPage = new SingUpView();
        }

        #region Properties
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
        #endregion

        #region Commands

        public ICommand SignInCommand { get; }

        public ICommand SignUpCommand { get; }

        #endregion

    }
}
