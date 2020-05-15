using Cookbook.Models;
using Cookbook.Services;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Media;

namespace Cookbook.ViewModels
{
    /// <summary>
    /// the viewmodel class for DetailsPage. It contains all of the logics and calls, implement the INotifyPropertyChanged for the databinding refresh
    /// </summary>
    public class DetailsPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly SearchService _searchService;
        /// <summary>
        /// the event for the changeing property
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public static BookEntity BookEntity { get; set; }

        /// <summary>
        /// property change function
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// the important details of a book it call OnPropertyChanged if change something
        /// </summary>
        private ImportantDetails _details { get; set; }
        public ImportantDetails Details
        {
            get { return _details; }
            set
            {
                _details = value;
                OnPropertyChanged();
            }
        }
          /// <summary>
          /// default constructor
          /// </summary>
        public DetailsPageViewModel()
        {
            Details = new ImportantDetails()
            {
                Pages = 0,
                Title = "nincs adat",
                AuthorName = "nincs adat",
                AuthorUrl = "nincs adat"
            };
            _searchService = new SearchService();

        }
        /// <summary>
        /// set the current book what book's entity needed
        /// </summary>
        /// <param name="newBook"></param>
        public void SetBook(BookEntity newBook)
        {
            BookEntity = newBook;
        }
        /// <summary>
        /// create the good url for the api call, and call the service function with it. And make the new detailsBook with the result
        /// </summary>
        public async Task GetData()
        {
            String newUrl;
            if (BookEntity.Isbn.Length > 0)
            {
                newUrl = ("/api/books?bibkeys=ISBN:" + BookEntity.Isbn[0] + "&jscmd=data&format=json");
            }
            else if (BookEntity.Lccn.Length > 0)
            {
                newUrl = ("/api/books?bibkeys=LCCN:" + BookEntity.Lccn[0] + "&jscmd=data&format=json");
            }
            else if (BookEntity.Oclc.Length > 0)
            {
                newUrl = ("/api/books?bibkeys=OCLC:" + BookEntity.Oclc[0] + "&jscmd=data&format=json");
            }
            else throw new Exception("wrong url for details");

            var result = await _searchService.GetDetails(newUrl);
            ImageSource imgt;
            if (result.Cover != null)
            {
                imgt = _searchService.GetImgFromUrl(result.Cover.Large);
            }
            else
            {
                imgt = _searchService.GetImgFromUrl(null);
            }

            ImportantDetails temp = new ImportantDetails
            {
                Img = imgt,
                Pages = result.Number_of_pages,
                Title = "nincs adat",
                ImageL = "nincs adat",
                ImageM = "nincs adat",
                AuthorName = "nincs adat",
                AuthorUrl = "nincs adat"
            };

            if (result.Title != null)
            {
                temp.Title = result.Title;
            }
            if (result.Cover != null)
            {
                temp.ImageL = result.Cover.Large;
                temp.ImageM = result.Cover.Medium;
            }
            if (result.Authors.Length > 0)
            {
                temp.AuthorName = result.Authors[0].Name;
                temp.AuthorUrl = result.Authors[0].Url;
            }
            Details = temp;
        }
    }
}
