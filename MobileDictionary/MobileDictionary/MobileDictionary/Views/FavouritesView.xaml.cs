using MobileDictionary.Models;
using MobileDictionary.Pages;
using MobileDictionary.Services;
using MobileDictionary.ViewModels.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDictionary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritesView : ContentView
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public FavouritesView()
        {
            // Initialize the components
            InitializeComponent();

            // Set the binding context
            BindingContext = FavouritesViewModel.Instance;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Removes the selected word from the favourites list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Clicked(object sender, System.EventArgs e)
        {
            // Get the clicked item as button.
            Button btn = sender as Button;

            // Get the selected word by using the button's binding context
            Kelime kelime = (Kelime)btn.BindingContext;

            // Remove word from the list by using view model.
            ((FavouritesViewModel)BindingContext).RemoveWord(kelime);
        }

        /// <summary>
        /// Redirects to detail page when an item of the list tapped.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void wordListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // Get the list view item as tapped item.
            ListView item = sender as ListView;

            // Get the selected word by casting the selected item.
            var kelime = (Kelime)item.SelectedItem;

            await ((FavouritesViewModel)BindingContext).SetDetails(kelime);

            // Redirect to detail page with the word and examples.
            await Navigation.PushModalAsync(new DetailPage());
        }

        #endregion
    }
}