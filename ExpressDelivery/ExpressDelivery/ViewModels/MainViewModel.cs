using ExpressDelivery.Models;
using ExpressDelivery.Views;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpressDelivery.ViewModels
{
    
    public class MainViewModel: BaseViewModel
    {
        const string RESOURCE_FB = "https://expressdelivery-e9ad9-default-rtdb.firebaseio.com/";
        FirebaseClient firebaseClient = new FirebaseClient(RESOURCE_FB);

        public string ID;
        public string Name;
        public string Adress;
        public string Email;
        public string Phone;
        public string Pass;

        public UserSession User { get; set; }

        public string TxtID
        {
            get { return this.ID; }
            set { this.ID = value; }
        }
        public string TxtName
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        public string TxtAdress
        {
            get { return this.Adress; }
            set { this.Adress = value; }
        }
        public string TxtEmail
        {
            get { return this.Email; }
            set { this.Email = value; }
        }
        public string TxtPhone
        {
            get { return this.Phone; }
            set { this.Phone = value; }
        }
        public string TxtPass
        {
            get { return this.Pass; }
            set { this.Pass = value; }
        }

        public string IDTxt
        {
            get { return this.ID; }
            set { this.ID = value; }
        }

        public string PassTxt
        {
            get { return this.Pass; }
            set { this.Pass = value; }
        }

        public MainViewModel()
        {

            /*User = new UserSession
            {
                ID = "101312122321",
                Name = "Guest Consumidor",
                Address = "Avenida Siempre viva 123",
                Email = "guest@tdea.com.edu",
                Phone = "31045312312"
            };*/



            /*Categories = new List<Category>()
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
            Categories.ForEach((item) =>
            {
                firebaseClient.Child("Category").PostAsync(item);
            });*/

            firebaseClient.Child("Category").AsObservable<Category>().Subscribe((dbevent) =>
            {
                Categories.Add(dbevent.Object);
            });


        }
        //public UserSession User { get; set; }

        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(RegisterMethod);
            }
        }

        public ICommand SingInCommand
        {
            get
            {
                return new Command(SingInMethod);
            }
        }

        private async void SingInMethod()
        {
            if (this.ID == "123" && this.Pass == "321")
            {
                await Application.Current.MainPage.DisplayAlert(
                                "Ingreso",
                                "Bienvenido",
                                "Aceptar");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            "Los datos ingresados no son correctos",
                            "Aceptar");
            }
        }

        private async void RegisterMethod()
        {
            if (string.IsNullOrEmpty(this.ID) ||
                string.IsNullOrEmpty(this.Name) ||
                string.IsNullOrEmpty(this.Adress) ||
                string.IsNullOrEmpty(this.Email) ||
                string.IsNullOrEmpty(this.Phone) ||
                string.IsNullOrEmpty(this.Pass))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar todos los datos",
                    "Aceptar");
                return;
            }

            await Application.Current.MainPage.DisplayAlert(
                    "Info",
                    "El registro ha sido exitoso.",
                    "Aceptar");

            User = new UserSession
            {
                ID = TxtID,
                Name = TxtName,
                Address = TxtAdress,
                Email = TxtEmail,
                Phone = TxtPhone,
                Pass = TxtPass
            };
        }





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
