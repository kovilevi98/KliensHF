using Cookbook.Models;
using Cookbook.Services;
using Cookbook.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Media;

namespace Cookbook.ViewModels
{
    public  class DetailsPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly SearchService _searchService;
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
      
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private  ImportantDetails _details { get; set; }
        public ImportantDetails Details
        {
            get { return _details; }
            set
            {
                _details = value;
                OnPropertyChanged();
            }
        }
        public static BookEntity BookEntity { get; set; }
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
        public void SetBook(BookEntity newBook)
        {
            BookEntity = newBook;
        }
        public async Task GetData()
        {
            String newUrl;
            if (BookEntity.isbn.Length > 0)
            {
                newUrl = ("/api/books?bibkeys=ISBN:" + BookEntity.isbn[0] + "&jscmd=data&format=json");
            }
            else if (BookEntity.lccn.Length > 0)
            {
                newUrl = ("/api/books?bibkeys=LCCN:" + BookEntity.lccn[0] + "&jscmd=data&format=json");
            }
            else if (BookEntity.oclc.Length > 0)
            {
                newUrl = ("/api/books?bibkeys=OCLC:" + BookEntity.oclc[0] + "&jscmd=data&format=json");
            }
            else throw new Exception("wrong url for details");
            
            var result = await _searchService.GetDetails(newUrl);
            ImageSource imgt;
            if (result.cover != null)
            {
                imgt = _searchService.GetImgFromUrl(result.cover.large);
            }
            else
            {
                imgt = _searchService.GetImgFromUrl(null);
            }

            ImportantDetails temp = new ImportantDetails
            {
                img = imgt,
                Pages = result.number_of_pages,
                Title = "nincs adat",
                ImageL="nincs adat",
                ImageM= "nincs adat",
                AuthorName = "nincs adat",
                AuthorUrl = "nincs adat"
        };

            if (result.title != null)
            {
                temp.Title = result.title;
            }
            if (result.cover != null)
            {
                temp.ImageL = result.cover.large;
                temp.ImageM = result.cover.medium;
            }
            if (result.authors.Length > 0)
            {
                temp.AuthorName = result.authors[0].name;
                temp.AuthorUrl = result.authors[0].url;
            }
            Details = temp;
        }      
    }
}
