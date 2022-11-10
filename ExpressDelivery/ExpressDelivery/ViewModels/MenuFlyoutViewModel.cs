using Acr.UserDialogs;
using ExpressDelivery.Common;
using ExpressDelivery.Framework;
using ExpressDelivery.Models;
using ExpressDelivery.Resources;
using ExpressDelivery.Views;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpressDelivery.ViewModels
{
    public class MenuFlyoutViewModel: BaseViewModel
    {
        
        public ICommand NavigateCommand { get; private set; }
        public List<MenuFlyoutMenuItem> MenuItems { get; set; }
        private UserSession User;
        public bool IsSession { get; set; }
        public bool IsNotSession { get; set; }

        FirebaseClient firebaseClient = new FirebaseClient(Constants.DB_FIREBASE);

        public MenuFlyoutViewModel()
        {
            var authService = DependencyService.Resolve<IAuth>();
            
            IsSession = authService.IsSignIn();
            if (IsSession)
            {
                User = authService.GetCurrentUser();
                PutInfoUser(User.Email);

            }
            IsNotSession = !IsSession;
            MenuItems = new List<MenuFlyoutMenuItem>()
                {
                    new MenuFlyoutMenuItem { Id = 0, Title = "Iniciar sesion",IsShow=!IsSession, TargetType=typeof(SingInView)  },
                    new MenuFlyoutMenuItem { Id = 1, Title = "Categorias", IsShow=true, TargetType=typeof(MainPage) },
                    new MenuFlyoutMenuItem { Id = 2, Title = "Registrar", IsShow=!IsSession, TargetType=typeof(SingUpView)  }

                };
            SignOutCommand = new Command(OnSignOut);
        }

        private void OnSignOut()
        {
            var authService = DependencyService.Resolve<IAuth>();
            UserDialogs.Instance.ShowLoading("Procesando");
            authService.SignOut();
            UserDialogs.Instance.HideLoading();
            App.Current.MainPage = new SingInView();
        }

        private async void PutInfoUser(string email)
        {
            UserDialogs.Instance.ShowLoading("Procesando");
            var respone = (await firebaseClient
                                   .Child(Constants.TABLE_USERS)
                                   .OnceAsync<UserSession>())
                                   .Where(a => a.Object.Email == email).FirstOrDefault();
            User.Address = respone.Object.Address;
            User.Phone = respone.Object.Phone;
            UserSession = new UserSession()
            {
                Email = respone.Object.Email,
                Name = respone.Object.Name,
                ID = User.ID,
                Address = respone.Object.Address,
                Phone = respone.Object.Phone
            };
            UserDialogs.Instance.HideLoading();

        }



        #region Properties
        public UserSession UserSession
        {
            get => User;
            set => SetProperty(ref User, value);
        }
        #endregion

        #region Commands
        public ICommand SignOutCommand { get; }
        #endregion
    }
}
