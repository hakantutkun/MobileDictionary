using MobileDictionary.Models;
using MobileDictionary.Services;
using MobileDictionary.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace MobileDictionary.ViewModels.Pages
{
    public class AllWordsViewModel : BasePageViewModel<AllWordsViewModel>
    {
        #region Properties

        /// <summary>
        /// The list that keeps all words
        /// </summary>
        private ObservableCollection<Kelime> _wordList;

        public ObservableCollection<Kelime> WordList
        {
            get { return _wordList; }
            set { _wordList = value; OnPropertyChanged(nameof(WordList)); }
        }

        /// <summary>
        /// A flag that keeps listviewvisibility
        /// </summary>
        private bool _listViewVisibility;

        public bool ListViewVisibility
        {
            get { return _listViewVisibility; }
            set { _listViewVisibility = value; OnPropertyChanged(nameof(ListViewVisibility)); }
        }

        /// <summary>
        /// A flag that keeps running state of spinner
        /// </summary>
        private bool _spinnerRunning = true;

        public bool SpinnerRunning
        {
            get { return _spinnerRunning; }
            set
            {
                _spinnerRunning = value;

                if (value)
                {
                    ListViewVisibility = false;
                }

                OnPropertyChanged(nameof(SpinnerRunning));
            }
        }

        /// <summary>
        /// DetailPage view model
        /// </summary>
        private DetailPageViewModel _detailPageViewModel;

        public DetailPageViewModel DetailPageViewModel
        {
            get { return _detailPageViewModel; }
            set { _detailPageViewModel = value; OnPropertyChanged(nameof(DetailPageViewModel)); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AllWordsViewModel()
        {
            // Set detail page view model instance
            DetailPageViewModel = DetailPageViewModel.Instance;

            // Create an instance for history list.
            WordList = new ObservableCollection<Kelime>();

            // Get words when page loads.
            GetWords();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the history words from the database.
        /// </summary>
        public void GetWords()
        {
            SpinnerRunning = true;

            // Get the words from database.
            Task.Run(() =>
            {
                Thread.Sleep(300);

                // Get the words from database service.
                var returnList = DBService.LoadAllWords().Result;

                // Set the fetched words to the history list.
                WordList = new ObservableCollection<Kelime>(returnList);

                // Set listview visibility to true
                ListViewVisibility = true;

                // Stop spinner running state
                SpinnerRunning = false;

            });
        }

        public async Task SetDetails(Kelime kelime)
        {
            List<Ornek> ornekList = await DBService.LoadExamples(kelime.KelimeID);

            DetailPageViewModel.SelectedWord = kelime;
            DetailPageViewModel.ExampleList = new ObservableCollection<Ornek>(ornekList);
        }

        #endregion
    }
}
