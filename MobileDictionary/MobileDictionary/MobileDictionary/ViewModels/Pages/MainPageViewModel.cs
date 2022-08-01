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

        private int _selectedViewModelIndex;

        public int SelectedViewModelIndex
        {
            get { return _selectedViewModelIndex; }
            set 
            {
                _selectedViewModelIndex = value; 
                OnPropertyChanged(nameof(SelectedViewModelIndex));

                switch (value)
                {
                    case 0:
                        SearchViewModel.Instance.IsActive = false;
                        FavouritesViewModel.Instance.IsActive = false;
                        HistoryViewModel.Instance.IsActive = true;
                        break;
                    case 1:
                        HistoryViewModel.Instance.IsActive = false;
                        FavouritesViewModel.Instance.IsActive = false;
                        SearchViewModel.Instance.IsActive = true;
                        break;
                    case 2:
                        HistoryViewModel.Instance.IsActive = false;
                        SearchViewModel.Instance.IsActive = false;
                        FavouritesViewModel.Instance.IsActive = true;
                        break;
                }
            }
        }

        #endregion

        public MainPageViewModel()
        {
            // Set views binding contexts.
            FavouritesViewModel = FavouritesViewModel.Instance;
            SearchViewModel = SearchViewModel.Instance;
            HistoryViewModel = HistoryViewModel.Instance;

            SelectedViewModelIndex = 1;
        }
    }
}
