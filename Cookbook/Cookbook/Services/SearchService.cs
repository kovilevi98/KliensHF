using Cookbook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

/// <summary>
/// this is the Server class. It contain all aff the API call
/// </summary>
namespace Cookbook.Services
{
    class SearchService
    {
        private readonly Uri serverUrl = new Uri("http://openlibrary.org/search.json?");
        private readonly Uri detailUrl = new Uri("http://openlibrary.org/");

        /// <summary>
        /// It call the async api call for a book's details with the good url, and wait for the response
        /// </summary>
        /// <param name="url">it is the specific end of the api url</param>
        /// <returns>return with details of a given book </returns>
        public async Task<ISBN> GetDetails(String url)
        {
            var resutlt = await GetAsyncDetails<ISBN>(new Uri(detailUrl, url + "&format=json"));
            return resutlt;
        }

        /// <summary>
        /// It call the async api call for the book list and wait for the response.
        /// </summary>
        /// <param name="url">it is the specific end of the api url</param>
        /// <returns>with the list of the book</returns>
        public async Task<BookList> GetBookList(String url)
        {
            var result = await GetAsync<BookList>(new Uri(serverUrl, "/search.json?" + url));
            return result;
        }

        /// <summary>
        /// it returns with an imagesource from a book code and size, if not found it returns with a sample image
        /// </summary>
        /// <param name="code">this is the code of the book</param>
        /// <param name="size">the image size</param>
        /// <returns>the specific imagesource</returns>
        public ImageSource GetImg(String code, String size)
        {
            ImageSource imgsrc;
            if (code == null)
            {
                imgsrc = new BitmapImage(new Uri("ms-appx:///Assets/sample.png"));
            }
            else
            {
                Uri newServerUrl = new Uri("http://covers.openlibrary.org");
                Uri url = new Uri(newServerUrl, "/b/OLID/" + code + "-" + size + ".jpg");
                imgsrc = new BitmapImage(url);
            }
            return imgsrc;
        }
        /// <summary>
        /// it get a whole url not just the book code and returns with an imagesource for the book
        /// </summary>
        /// <param name="code">the image url for the book</param>
        /// <returns>Imagesource for the book</returns>
        public ImageSource GetImgFromUrl(String code)
        {
            ImageSource imgsrc;
            if (code == null)
            {
                imgsrc = new BitmapImage(new Uri("ms-appx:///Assets/sample.png"));
            }
            else
            {
                Uri url = new Uri(code);
                imgsrc = new BitmapImage(url);
            }
            if (imgsrc == null)
            {
                return new BitmapImage(new Uri("ms-appx:///Assets/sample.png"));
            }
            return imgsrc;
        }
        /// <summary>
        /// the async API call 
        /// </summary>
        /// <typeparam name="T">the return object's class</typeparam>
        /// <param name="uri">the whole url of the API</param>
        /// <returns>with the API result</returns>
        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
        /// <summary>
        /// the async API call for details
        /// </summary>
        /// <typeparam name="T">the return object's class</typeparam>
        /// <param name="uri">the whole url of the API</param>
        /// <returns>with the API result</returns>
        private async Task<T> GetAsyncDetails<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = DeserializeAndUnwrap<T>(json);
                return result;
            }
        }
        /// <summary>
        /// the specific convert from a Json string the T object
        /// </summary>
        /// <typeparam name="T">the return object's class</typeparam>
        /// <param name="json">the whole return message from the API</param>
        /// <returns>with the T object with the data</returns>
        public static T DeserializeAndUnwrap<T>(string json)
        {
            JObject jObject = JObject.Parse(json);
            return jObject.Properties().First().Value.ToObject<T>();
        }
    }
}
