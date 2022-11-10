using ExpressDelivery.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpressDelivery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriaDetalleView : ContentPage
    {
        public CategoriaDetalleView()
        {
        }
        public CategoriaDetalleView(Category category)
        {
            InitializeComponent();
            BindableLayout.SetItemsSource(listRelevantItemView, category.RelevantItems);
        }

    }
}