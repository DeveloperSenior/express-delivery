﻿using ExpressDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpressDelivery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriaDetalleView : ContentPage
    {
        public CategoriaDetalleView()
        {
            

            InitializeComponent();
            IEnumerable<Item> items = new Item[]

            {
                new Item()
                       {
                           Id = 1, Name="Azetaminofen", Image = "Azetaminofen.png", Description= "Para Aliviar el dolor de cabeza", Price=5000
                },

                new Item()
                       {
                           Id = 1, Name="Pizza", Image = "Pizza.png", Description= "Una buena pizza para quitar tus antojos", Price=5000
                },

                new Item()
                       {
                           Id = 1, Name="Corona", Image = "Corona.png", Description= "", Price=5000
                },

                 new Item()
                       {
                           Id = 1, Name="Raton Volador", Image = "Azetaminofen.png", Description= "Para tu mascota juguetona este raton es ideal", Price=5000
                }


            };
            BindableLayout.SetItemsSource(listRelevantItemView, items);

        }



    }
}