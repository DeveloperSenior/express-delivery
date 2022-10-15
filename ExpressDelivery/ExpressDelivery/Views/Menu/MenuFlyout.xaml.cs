using ExpressDelivery.Models;
using ExpressDelivery.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpressDelivery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuFlyout : ContentPage
    {
        public ListView ListView;
        public ICommand NavigateCommand { get; private set; }
        public List<MenuFlyoutMenuItem> MenuItems { get; set; }
        public UserSession User { get; set; }
        public bool IsSession { get; set; }
        public bool IsNotSession { get; set; }


        public MenuFlyout()
        {
            InitializeComponent();
            
            ListView = MenuItemsListView;
            User = new ViewModels.MainViewModel().User;
            IsSession = (User?.ID != null);
            IsNotSession = !IsSession;
            MenuItems = new List<MenuFlyoutMenuItem>()
                {
                    new MenuFlyoutMenuItem { Id = 0, Title = "Iniciar sesion",IsShow=!IsSession },
                    new MenuFlyoutMenuItem { Id = 1, Title = "Categorias", IsShow=true },
                    new MenuFlyoutMenuItem { Id = 2, Title = "Registrar", IsShow=!IsSession }

                };
            BindingContext = this;
        }

    }
}