using Carousel.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Carousel.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}