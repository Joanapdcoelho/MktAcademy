using MktAcademyMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MktAcademyMobile.Views
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