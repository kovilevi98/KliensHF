using Cookbook.Models;
using Cookbook.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Cookbook.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        private readonly SearchService _searchService;
        public static ObservableCollection<Doc> BookList { get; set; } =
             new ObservableCollection<Doc>();
        public static ObservableCollection<BookEntity> ResultList { get; set; } =
             new ObservableCollection<BookEntity>();
        public static string Result = "Results";
        private String NewUri { get; set; }

        public ListPageViewModel(String newUrl)
        {
            _searchService = new SearchService();
            NewUri = newUrl;

        }

        public async Task GetData()
        {
            var result = await _searchService.GetBookList(NewUri);
            if (result.numFound > 100)
            {
                var resultSecondPage = await _searchService.GetBookList(NewUri+"&page=2");
                AddItemToList(resultSecondPage);
            }
            AddItemToList(result);

            if (ResultList.Count == 0)
            {
                Result = "Do not find books with the specific search";
            }
        }
        private void AddItemToList(Rootobject result)
        {
            foreach (var d in result.docs)
            {
                ImageSource img = null;
                img = _searchService.GetImg(d.cover_edition_key, "M");
                var temp = new BookEntity
                {
                    Title = d.title_suggest,
                    Img = img,
                    isbn = d.isbn,
                    oclc = d.oclc,
                    lccn = d.lccn
                };
                ResultList.Add(temp);
                BookList.Add(d);
            }
        }
        public void ClearLists()
        {
            ResultList.Clear();
            BookList.Clear();
        }
    }
}
