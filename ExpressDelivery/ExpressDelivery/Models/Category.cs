using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressDelivery.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageSource { get; set; }

        public List<Item> RelevantItems { get; set; }

    }
}
