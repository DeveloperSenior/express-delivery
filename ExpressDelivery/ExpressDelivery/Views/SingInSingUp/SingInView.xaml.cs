using ExpressDelivery.Common;
using ExpressDelivery.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpressDelivery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class SingInView : ContentPage
    {
        
        public SingInView()
        {
            InitializeComponent();
            BindingContext = new SingInViewModel();
        }
      
    }
}