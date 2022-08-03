using MobileDictionary.ViewModels.Pages;
using System;
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

            this.Opacity = 0;

            BindingContext = MainPageViewModel.Instance;

            ((MainPageViewModel)BindingContext).PopupVisibilityChangedEvent += new MainPageViewModel.PopupVisibilityChangedDelegate(PopupVisibilityChanged);
        }

        private async void PopupVisibilityChanged(bool state)
        {
            if(state)
            {
                await this.FadeTo(1, 300, Easing.CubicIn);
            }
            else
            {
                if(this.Opacity > 0)
                    await this.FadeTo(0, 300, Easing.CubicOut);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await this.FadeTo(0, 300, Easing.CubicOut);
            ((MainPageViewModel)BindingContext).CustomPopupVisibility = false;
        }
    }
}