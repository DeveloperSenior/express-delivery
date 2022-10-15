using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressDelivery.Views
{
    public class MenuFlyoutMenuItem
    {
        public MenuFlyoutMenuItem()
        {
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string CommandPageView { get; set; }

        public bool IsShow { get; set; }
        public Type TargetType { get; set; }
    }
}