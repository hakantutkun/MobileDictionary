using SQLite;
using System.ComponentModel;

namespace MobileDictionary.Models
{
    /// <summary>
    /// Default summary for Kelime.cs
    /// </summary>
    public class Kelime : INotifyPropertyChanged
    {
        /// <summary>
        /// The id of the word
        /// </summary>
        [PrimaryKey]
        public long KelimeID { get; set; }

        /// <summary>
        /// Karachay meaning of the word
        /// </summary>
        public string KaracaycaAnlam { get; set; }

        /// <summary>
        /// Turkish meaning of the word
        /// </summary>
        public string TurkceAnlam { get; set; }

        /// <summary>
        /// A flag that controls if the word has been searched before
        /// </summary>
        public long IsSearched { get; set; }

        /// <summary>
        /// Latest search time
        /// </summary>
        public string SearchTime { get; set; }

        /// <summary>
        /// A flag that controls if the word has been saved as favourite word.
        /// </summary>
        private long _isFav;

        public long IsFav
        {
            get { return _isFav; }
            set { _isFav = value; OnPropertyChanged(nameof(IsFav)); }
        }


        /// <summary>
        /// Favourite addition time
        /// </summary>
        public string FavTime { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));
        }

    }
}
