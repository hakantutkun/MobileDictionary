using MobileDictionary.ViewModels.Base;
using MobileDictionary.ViewModels.Views;

namespace MobileDictionary.ViewModels.Pages
{
    public class MainPageViewModel : BasePageViewModel<MainPageViewModel>
    {
        #region Members 

        /// <summary>
        /// Favourites View Model
        /// </summary>
        private FavouritesViewModel _favouritesViewModel;

        public FavouritesViewModel FavouritesViewModel
        {
            get { return _favouritesViewModel; }
            set { _favouritesViewModel = value; OnPropertyChanged(nameof(FavouritesViewModel)); }
        }

        /// <summary>
        /// HistoryViewModel
        /// </summary>
        private HistoryViewModel _historyViewModel;

        public HistoryViewModel HistoryViewModel
        {
            get { return _historyViewModel; }
            set { _historyViewModel = value; OnPropertyChanged(nameof(HistoryViewModel)); }
        }


        /// <summary>
        /// SearchViewModel
        /// </summary>
        private SearchViewModel _searchViewModel;

        public SearchViewModel SearchViewModel
        {
            get { return _searchViewModel; }
            set { _searchViewModel = value; OnPropertyChanged(nameof(SearchViewModel)); }
        }

        #endregion

        public MainPageViewModel()
        {
            // Set views binding contexts.
            FavouritesViewModel = FavouritesViewModel.Instance;
            SearchViewModel = SearchViewModel.Instance;
            HistoryViewModel = HistoryViewModel.Instance;
        }
    }
}
