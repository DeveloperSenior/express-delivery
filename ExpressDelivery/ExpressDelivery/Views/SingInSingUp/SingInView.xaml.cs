using ExpressDelivery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpressDelivery.Views.SingInSingUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingInView : ContentPage
    {
        public SingInView()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
        private async void SingUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SingUpView());

        }
    }
}