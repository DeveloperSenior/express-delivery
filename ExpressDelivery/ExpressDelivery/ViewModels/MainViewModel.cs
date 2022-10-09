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
        }
        public UserSession User { get; set; }


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
