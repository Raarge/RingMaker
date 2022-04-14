using RingMaker.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RingMaker.Views
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