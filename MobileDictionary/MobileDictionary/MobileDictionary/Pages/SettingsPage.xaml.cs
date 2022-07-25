using MobileDictionary.Helpers;
using MobileDictionary.ViewModels.Pages;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDictionary.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            BindingContext = SettingsViewModel.Instance;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void RadioSystemTapped(object sender, EventArgs e)
        {
            radioSystem.IsChecked = true;
            radioLight.IsChecked = false;
            radioDark.IsChecked = false;

            Settings.Theme = 0;

            TheTheme.SetTheme();
        }

        private void RadioLightTapped(object sender, EventArgs e)
        {
            radioLight.IsChecked = true;
            radioSystem.IsChecked = false;
            radioDark.IsChecked = false;
            Settings.Theme = 1;

            TheTheme.SetTheme();
        }

        private void RadioDarkTapped(object sender, EventArgs e)
        {
            radioDark.IsChecked = true;
            radioSystem.IsChecked = false;
            radioLight.IsChecked = false;
            Settings.Theme = 2;

            TheTheme.SetTheme();
        }

        private void radioSystem_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var element = (RadioButton)sender;

            if (element.IsChecked)
            {
                radioSystem.IsChecked = true;
                Settings.Theme = 0;
                TheTheme.SetTheme();
            }
        }

        private void radioLight_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var element = (RadioButton)sender;

            if (element.IsChecked)
            {
                radioLight.IsChecked = true;
                Settings.Theme = 1;
                TheTheme.SetTheme();
            }
        }


        private void radioDark_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var element = (RadioButton)sender;

            if (element.IsChecked)
            {
                radioDark.IsChecked = true;
                Settings.Theme = 2;
                TheTheme.SetTheme();
            }
        }
    }
}