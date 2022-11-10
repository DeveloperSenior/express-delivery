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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpressDelivery.ViewModels
{
    
    public class MainViewModel: BaseViewModel
    {
        FirebaseClient firebaseClient = new FirebaseClient(Constants.DB_FIREBASE);
        private UserSession User;

        public MainViewModel()
        {
            var authService = DependencyService.Resolve<IAuth>();

            NavigateCommand = new Command(async (selectItem) => {
                var category = selectItem as Category;
                var page = (Page)Activator.CreateInstance(typeof(CategoriaDetalleView), category);
                page.Title = "Detalle " + category.Name;
                await App.Current.MainPage.Navigation.PushAsync(page);

            });
            UserDialogs.Instance.ShowLoading("Procesando");
            firebaseClient.Child(Constants.TABLE_CATEGORY).AsObservable<Category>().Subscribe((dbevent) =>
            {
                Categories.Add(dbevent.Object);
                
            });
            User = authService.GetCurrentUser();
            PutInfoUser(User.Email);

        }


        private async void PutInfoUser(string email)
        {
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
        public ICommand NavigateCommand { get;}
        #endregion
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();

    }

}
