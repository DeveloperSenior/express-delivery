using ExpressDelivery.Common;
using ExpressDelivery.Models;
using ExpressDelivery.Resources;
using ExpressDelivery.ViewModels;
using ExpressDelivery.Views;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpressDelivery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuFlyout : ContentView
    {

        public ListView ListView;

        public MenuFlyout()
        {
            InitializeComponent();
            ListView = MenuItemsListView;
            ListView.ItemSelected += ListView_ItemSelected;
            BindingContext = new MenuFlyoutViewModel();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuFlyoutMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            /*Detail = new NavigationPage(page);*/
            await Navigation.PushAsync(page);
            Shell.Current.FlyoutIsPresented = false;
            ListView.SelectedItem = null;
        }

    }
}