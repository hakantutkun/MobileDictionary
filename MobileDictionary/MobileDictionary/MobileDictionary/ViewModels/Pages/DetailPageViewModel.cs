using MobileDictionary.Models;
using MobileDictionary.Services;
using MobileDictionary.ViewModels.Base;
using Plugin.Share;
using Plugin.Share.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileDictionary.ViewModels.Pages
{
    /// <summary>
    /// Detail Page View Model
    /// </summary>
    public class DetailPageViewModel : BasePageViewModel<DetailPageViewModel>
    {
        #region Members

        /// <summary>
        /// The word instance for selected word.
        /// </summary>
        private Kelime _selectedWord;

        public Kelime SelectedWord
        {
            get { return _selectedWord; }
            set 
            { 
                _selectedWord = value;

                CheckIfWordIsSaved(value);

                SetWordAsSearched();

                OnPropertyChanged(nameof(SelectedWord)); 
            }
        }


        /// <summary>
        /// Selected Word List
        /// </summary>
        private ObservableCollection<Ornek> _exampleList;

        public ObservableCollection<Ornek> ExampleList
        {
            get { return _exampleList; }
            set 
            { 
                _exampleList = value;

                CheckBadgeState(value);

                OnPropertyChanged(nameof(ExampleList)); 
            }
        }

        /// <summary>
        /// Save Button Visibility Flag
        /// </summary>
        private bool _saveButtonVisibility = true;

        public bool SaveButtonVisibility
        {
            get { return _saveButtonVisibility; }
            set { _saveButtonVisibility = value; OnPropertyChanged(nameof(SaveButtonVisibility)); }
        }

        /// <summary>
        /// Remove button visibility flag
        /// </summary>
        private bool _removeButtonVisibility;

        public bool RemoveButtonVisibility
        {
            get { return _removeButtonVisibility; }
            set { _removeButtonVisibility = value; OnPropertyChanged(nameof(RemoveButtonVisibility)); }
        }

        /// <summary>
        /// Selected Tab Index flag
        /// </summary>
        private int _selectedTabIndex = 0;

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set { _selectedTabIndex = value; OnPropertyChanged(nameof(SelectedTabIndex)); }
        }

        /// <summary>
        /// Badge Visibility flag
        /// </summary>
        private bool _badgeVisibility;

        public bool BadgeVisibility
        {
            get { return _badgeVisibility; }
            set { _badgeVisibility = value; OnPropertyChanged(nameof(BadgeVisibility)); }
        }

        /// <summary>
        /// Number of Examples
        /// </summary>
        private int _numberOfExamples;

        public int NumberOfExamples
        {
            get { return _numberOfExamples; }
            set { _numberOfExamples = value; OnPropertyChanged(nameof(NumberOfExamples)); }
        }


        #endregion

        #region Commands

        /// <summary>
        /// Save Command
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Listen Command
        /// </summary>
        public ICommand ListenCommand { get; set; }

        /// <summary>
        /// Share Command
        /// </summary>
        public ICommand ShareCommand { get; set; }

        /// <summary>
        /// Copy Command
        /// </summary>
        public ICommand CopyCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DetailPageViewModel()
        {
            // Set Command Instances
            SaveCommand = new Command(SaveWord);
            ListenCommand = new Command(ListenWord);
            ShareCommand = new Command(ShareWord);
            CopyCommand = new Command(CopyWord);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Save Word
        /// </summary>
        private async void SaveWord()
        {
            // Check if the word saved before
            if (SelectedWord.IsFav.Equals(1))
            {
                // If saved, remove word
                SelectedWord.IsFav = 0;

                // Update removed word
                await DBService.UpdateWord(SelectedWord);

                // Display an alert to user which indicates that word has been removed
                //await DisplayAlert("Bilgi", "Kelime kaydedilen kelimlelerden çıkarıldı.", "Tamam");

                // Show save button back.
                SaveButtonVisibility = true;

                // Remove hide button.
                RemoveButtonVisibility = false;
            }
            // if word has not been saved before,
            else
            {
                // Set the word as saved
                SelectedWord.IsFav = 1;

                // Set the wword's favourite time to current time
                SelectedWord.FavTime = DateTime.Now.ToString();

                // Update the word as saved.
                await DBService.UpdateWord(SelectedWord);

                // Display an alert to user which indicates that word has been added to favourites.
                //await DisplayAlert("Bilgi", "Kelime kaydedilen kelimlelere eklendi..", "Tamam");

                // Hide save button.
                SaveButtonVisibility = false;

                // Show remove button.
                RemoveButtonVisibility = true;
            }
        }

        /// <summary>
        /// Listen Word
        /// </summary>
        private void ListenWord()
        {
            // Display an alert to the user which indicates that this button is not active yet.
            //await DisplayAlert("Bilgi", "Bu özellik henüz kullanılamıyor.", "Tamam");
        }

        /// <summary>
        /// Share Word
        /// </summary>
        private async void ShareWord()
        {

            // Fire the share window of the app
            await CrossShare.Current.Share(new ShareMessage
            {
                // Set Title
                Title = "Mingi Tav Sözlük",

                // Set content that will be shared
                Text = SelectedWord.KaracaycaAnlam + " : " + SelectedWord.TurkceAnlam
            });
        }

        /// <summary>
        /// Copy Word
        /// </summary>
        private async void CopyWord()
        {
            // Copy the word to the clipboard.
            await Clipboard.SetTextAsync(SelectedWord.KaracaycaAnlam);

            // Display an alert to the user which indicates that word has been copied to the clipboard.
            //await DisplayAlert("Bilgi", "Kelime panoya başarıyla kopyalandı.", "Tamam");
        }

        /// <summary>
        /// Fires when selected word changed.
        /// </summary>
        private void SetWordAsSearched()
        {
            // Update the word asynchronously.
            Task.Run(() =>
            {
                // Set the word's searched tag to true.
                SelectedWord.IsSearched = 1;

                // Set the word's search time to current time.
                SelectedWord.SearchTime = DateTime.Now.ToString();

                // Update the word
                DBService.UpdateWord(SelectedWord).Wait();

            }).Wait();
        }

        /// <summary>
        /// Checks if the word has been saved before.
        /// </summary>
        /// <param name="kelime">Selected word</param>
        private void CheckIfWordIsSaved(Kelime kelime)
        {
            if (kelime.IsFav.Equals(1))
            {
                // Hide save button
                SaveButtonVisibility = false;

                // Show Remove button
                RemoveButtonVisibility = true;
            }
        }

        /// <summary>
        /// Checks Badge State
        /// </summary>
        /// <param name="value">Received example list</param>
        private void CheckBadgeState(ObservableCollection<Ornek> value)
        {
            // Check if received list has any members.
            if (value.Count > 0)
            {
                // If received list has members, set badge as visible.
                BadgeVisibility = true;

                // Set badge number.
                NumberOfExamples = value.Count;
            }
            else
            {
                // If received list has no members, set badge as invisible.
                BadgeVisibility = false;

                // Set badge number to zero.
                NumberOfExamples = 0;
            }
        }

        #endregion
    }
}
