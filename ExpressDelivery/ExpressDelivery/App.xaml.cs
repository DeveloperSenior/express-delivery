using ExpressDelivery.Common;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace ExpressDelivery
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var authService = DependencyService.Resolve<IAuth>();
            UserDialogs.Instance.ShowLoading("Procesando");
            if (authService.IsSignIn())
            {
                MainPage = new Views.Menu();
            }
            else
            {
                MainPage = new Views.SingInView();
            }
            UserDialogs.Instance.HideLoading();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
