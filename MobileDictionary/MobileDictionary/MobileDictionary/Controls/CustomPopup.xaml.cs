using MobileDictionary.ViewModels.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDictionary.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPopup : ContentView
    {
        public CustomPopup()
        {
            InitializeComponent();

            BindingContext = MainPageViewModel.Instance;
        }
    }
}