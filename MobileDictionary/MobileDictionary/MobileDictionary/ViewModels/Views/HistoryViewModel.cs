﻿using MobileDictionary.Models;
using MobileDictionary.Services;
using MobileDictionary.ViewModels.Base;
using MobileDictionary.ViewModels.Pages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileDictionary.ViewModels.Views
{
    /// <summary>
    /// A view model class for HistoryView
    /// </summary>
    public class HistoryViewModel : BaseViewModel<HistoryViewModel>
    {
        #region Properties

        /// <summary>
        /// The list that keeps search results
        /// </summary>
        private ObservableCollection<Kelime> _historyList;

        public ObservableCollection<Kelime> HistoryList
        {
            get { return _historyList; }
            set { _historyList = value; OnPropertyChanged(nameof(HistoryList)); }
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

        #region Commands

        /// <summary>
        /// A command for delete search histroy
        /// </summary>
        public ICommand DeleteHistoryCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public HistoryViewModel()
        {
            // Set detail page view model instance
            DetailPageViewModel = DetailPageViewModel.Instance;

            DeleteHistoryCommand = new Command(DeleteHistory);

            // Create an instance for history list.
            HistoryList = new ObservableCollection<Kelime>();

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
                var returnList = DBService.LoadHistoryWords().Result;

                // Set the fetched words to the history list.
                HistoryList = new ObservableCollection<Kelime>(returnList);

                // Set listview visibility to true
                ListViewVisibility = true;

                // Stop spinner running state
                SpinnerRunning = false;

            });
        }

        /// <summary>
        /// Removes the selected word from favourites list.
        /// </summary>
        /// <param name="kelime"></param>
        public void RemoveWord(Kelime kelime)
        {
            // Set the word's searched flag to the false.
            kelime.IsSearched = 0;

            // Update the word in database.
            Task.Run(() =>
            {
                DBService.UpdateWord(kelime).Wait();

            }).Wait();

            // Remove the word from history list.
            HistoryList.Remove(kelime);

        }

        /// <summary>
        /// Deletes all words from history
        /// </summary>
        private void DeleteHistory()
        {
            foreach (var item in HistoryList)
            {
                // Update the word in database.
                Task.Run(() =>
                {
                    // Set the word's searched flag to the false.
                    item.IsSearched = 0;

                    DBService.UpdateWord(item).Wait();

                }).Wait();
            }

            HistoryList.Clear();
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
