using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressDelivery.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
