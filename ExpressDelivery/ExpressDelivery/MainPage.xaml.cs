using ExpressDelivery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpressDelivery.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void CarouselPositionChanged(object sender, PositionChangedEventArgs e)
        {
            var carousel = sender as CarouselView;
            var views = carousel.VisibleViews;

            if (views.Count > 0)
            {
                foreach (var view in views)
                {
                    var img = view.FindByName<Image>("CategoryImg");
                    ViewExtensions.CancelAnimations(img);
                    //Task.Run(async () => await img.RelRotateTo(360, 5000, Easing.BounceOut));
                }
            }
        }

    }
}
