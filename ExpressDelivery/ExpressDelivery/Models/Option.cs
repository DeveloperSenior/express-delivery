using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExpressDelivery.Models
{
    internal class Option
    {
        public string title { get; set; }
        public string detail { get; set; }
        public ImageSource image { get; set; }
        public Page page { get; set; }
    }
}
