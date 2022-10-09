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
            Task.Run(RotateImage);
        }

        private async void RotateImage()
        {

                await BannerImg.RelRotateTo(360, 10000, Easing.SpringIn);
        }

    }
}
