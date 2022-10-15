using ExpressDelivery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExpressDelivery.ViewModels
{
    
    public class MainViewModel: BaseViewModel
    {

        public MainViewModel()
        {
            User = new UserSession
            {
                ID = "101312122321",
                Name = "Guest Consumidor",
                Address = "Avenida Siempre viva 123",
                Email = "guest@tdea.com.edu",
                Phone = "31045312312"
            };

            Categories = new List<Category>()
            {
                new Category()
                {
                   Id = 1, Name = "Pet Shop!", ImageSource = "petshop.png", RelevantItems = new List<Item>()
                   {
                       new Item()
                       {
                           Id = 1, Name="Raton Volador", Image = "petshop.png", Description= "Para tu mascota juguetona este raton es ideal", Price=5000
                       },
                       new Item()
                       {
                           Id = 1, Name="Collar antipulgas", Image = "petshop.png", Description= "Para que tu mascota no sufra de piquiña", Price=15000
                       }
                   }
                },
                new Category()
                {
                   Id = 2, Name = "Licores!", ImageSource = "drink.png", RelevantItems = new List<Item>()
                   {
                       new Item()
                       {
                           Id = 1, Name="Ron viejo Caldas 8 años", Image = "drink.png", Description= "Para tus noches de fiesta", Price=55000
                       },
                       new Item()
                       {
                           Id = 1, Name="Vodka Absolute", Image = "drink.png", Description= "Para tus noches de fiesta y placer", Price=255000
                       }
                   }
                },
                new Category()
                {
                   Id = 3, Name = "Comida rapida!", ImageSource = "fastfood.png", RelevantItems = new List<Item>()
                   {
                       new Item()
                       {
                           Id = 1, Name="Combo salchipapa", Image = "fastfood.png", Description= "Papas a la francesa, gaseosa 1 litro, hamburguesa doble queso", Price=15000
                       },
                       new Item()
                       {
                           Id = 1, Name="Hamburguesa Super", Image = "fastfood.png", Description= "hamburguesa con queso,carney tocineta", Price=10000
                       },
                       new Item()
                       {
                           Id = 1, Name="Salchipapas Bacanas", Image = "fastfood.png", Description= "Papas a la francesa,Salchicha, Queso y pico de gallo", Price=9500
                       }
                   }
                },
                new Category()
                {
                   Id = 4, Name = "Farmacia!", ImageSource = "pilldrugs.png", RelevantItems = new List<Item>()
                   {
                       new Item()
                       {
                           Id = 1, Name="Crema corporal", Image = "pilldrugs.png", Description= "La mejor SkinCare del mercado", Price=105000
                       },
                       new Item()
                       {
                           Id = 1, Name="Pañitos humedos", Image = "pilldrugs.png", Description= "30 pañitos humedos con olora bebe", Price=25000
                       },
                       new Item()
                       {
                           Id = 1, Name="Crema dental", Image = "pilldrugs.png", Description= "Cremadental Colgate 130oz", Price=5500
                       },
                       new Item()
                       {
                           Id = 1, Name="Acetaminofen", Image = "pilldrugs.png", Description= "100 tabletas de 500 mlg", Price=15000
                       }
                   }
                }
            };
        }
        public UserSession User { get; set; }

        public List<Category> Categories { get; set; }


    }
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
