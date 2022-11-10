using ExpressDelivery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpressDelivery.Views
{
    public partial class Menu : Shell
    {
        public Menu()
        {
            InitializeComponent();
            BindingContext = new SingInViewModel();
        }

    }
}