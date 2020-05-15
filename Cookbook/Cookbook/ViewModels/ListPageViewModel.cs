using Cookbook.Models;
using Cookbook.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Media;

namespace Cookbook.ViewModels
{
    /// <summary>
    /// the viewmodel class for ListPage. It contains all of the logics and calls
    /// </summary>
    public class ListPageViewModel : ViewModelBase
    {
        /// <summary>
        /// object from the service class
        /// </summary>
        private readonly SearchService _searchService;
        /// <summary>
        /// list with the all books all entities
        /// </summary>
        public static ObservableCollection<Doc> BookList { get; set; } =
             new ObservableCollection<Doc>();
        /// <summary>
        /// list with the all books needed entites
        /// </summary>
        public static ObservableCollection<BookEntity> ResultList { get; set; } =
             new ObservableCollection<BookEntity>();
        /// <summary>
        /// the page's title
        /// </summary>
        public static string Result = "Results";
        /// <summary>
        /// the specific url for the api call
        /// </summary>
        private String NewUri { get; set; }


        public ListPageViewModel(String newUrl)
        {
            _searchService = new SearchService();
            NewUri = newUrl;
        }

        /// <summary>
        /// call the specific service funcion with the specific url 
        /// </summary>
        /// <returns></returns>
        public async Task GetData()
        {
            var result = await _searchService.GetBookList(NewUri);
            if (result.NumFound > 100)
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
        /// <summary>
        /// add book for the booklist and with the important entities to the resultList
        /// </summary>
        /// <param name="result">the api calls result object</param>
        private void AddItemToList(BookList result)
        {
            foreach (var d in result.Docs)
            {
                ImageSource img = _searchService.GetImg(d.Cover_edition_key, "M");
                var temp = new BookEntity
                {
                    Title = d.Title_suggest,
                    Img = img,
                    Isbn = d.Isbn,
                    Oclc = d.Oclc,
                    Lccn = d.Lccn
                };
                ResultList.Add(temp);
                BookList.Add(d);
            }
        }
        /// <summary>
        /// clear both of the booklist
        /// </summary>
        public void ClearLists()
        {
            ResultList.Clear();
            BookList.Clear();
        }
    }
}
