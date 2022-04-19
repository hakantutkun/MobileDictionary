﻿using MobileDictionary.ViewModels.Pages;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDictionary
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Main Page of the application.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            Switcher.SelectedIndex = 1;

            // Set the binding context
            BindingContext = MainPageViewModel.Instance;

            //customPopup.BindingContext = MainPageViewModel.Instance;

        }

        ///// <summary>
        ///// Refreshes History List when clicked to tab
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void HistoryTabItem_TabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        //{
        //    // Get the words from history view model.
        //    HistoryViewModel.Instance.GetWords();
        //}

        ///// <summary>
        ///// Refreshes Favourites List when clicked to tab
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void FavouritesTabItem_TabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        //{
        //    // Get the words from favourites view model.
        //    FavouritesViewModel.Instance.GetWords();
        //}
    }
}
