
using ExpressDelivery.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using ExpressDelivery.ViewModels;

namespace ExpressDelivery.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            IEnumerable<Item> items = new Item[]{};
            BindableLayout.SetItemsSource(listRelevantItemView, items);
            BindingContext = new MainViewModel();
        }

        public ObservableCollection<Item> RelevantItemsData { get; set; }

        private void OnCarouselPositionChanged(object sender, PositionChangedEventArgs e)
        {
            var carousel = sender as CarouselView;
            var views = carousel.VisibleViews;

            if (views.Count > 0)
            {
                foreach (var view in views)
                {
                    var img = view.FindByName<Image>("CategoryImg");
                    ViewExtensions.CancelAnimations(img);
                }
            }
        }

        private void OnCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            Category category = e.CurrentItem as Category;
            RelevantItemsData = category.RelevantItems;
            BindableLayout.SetItemsSource(listRelevantItemView, RelevantItemsData);
        }

    }
}
