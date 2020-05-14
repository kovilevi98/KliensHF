using Cookbook.Models;
using Cookbook.Services;
using Cookbook.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.ViewModels
{
    public  class DetailsPageViewModel
    {
        private readonly SearchService _searchService;
        public static ISBN BookDetail { get; set; } =
             new ISBN();
        public static ImportantDetails details { get; set; }
        public static BookEntity BookEntity { get; set; }
        public DetailsPageViewModel(BookEntity newBook)
        {
            _searchService = new SearchService();
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
            details = new ImportantDetails
            {
                ImageL = result.cover.large,
                ImageM = result.cover.medium,
                Pages = result.number_of_pages,
                Title = result.title,
                AuthorName = result.authors[0].name,
                AuthorUrl = result.authors[0].url

            };
        }
    }
}
