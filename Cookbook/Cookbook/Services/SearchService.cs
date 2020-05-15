using Cookbook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Cookbook.Services
{
    class SearchService
    {
        private readonly Uri serverUrl = new Uri("http://openlibrary.org/search.json?");
        private readonly Uri detailUrl = new Uri("http://openlibrary.org/");

        public async Task<ISBN> GetDetails(String s)
        {
            var resutl2 = await GetAsyncDetails<ISBN>(new Uri(detailUrl,s+"&format=json"));
            return resutl2;
        }

        public async Task<Rootobject> GetBookList(String s)
        {
            var resutl=await GetAsync<Rootobject>(new Uri(serverUrl, "/search.json?"+s));
            return resutl;
        }

        public ImageSource GetImg(String s,String size)
        {
            ImageSource imgsrc;
            if (s == null)
            {
                imgsrc = new BitmapImage(new Uri("ms-appx:///Assets/sample.png"));
            }
            else
            {
                Uri newServerUrl = new Uri("http://covers.openlibrary.org");
                Uri url = new Uri(newServerUrl, "/b/OLID/" + s + "-" + size + ".jpg");
                imgsrc = new BitmapImage(url);
            }
            return imgsrc;
        }

        public ImageSource GetImgFromUrl(String s)
        {
            ImageSource imgsrc;
            if (s == null)
            {
                imgsrc = new BitmapImage(new Uri("ms-appx:///Assets/sample.png"));
            }
            else
            {
                Uri newServerUrl = new Uri("http://covers.openlibrary.org");
                Uri url = new Uri(s);
                imgsrc = new BitmapImage(url);
            }
            if(imgsrc == null)
            {
                return new BitmapImage(new Uri("ms-appx:///Assets/sample.png"));
            }
            return imgsrc;
        }

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
        public static T DeserializeAndUnwrap<T>(string json)
        {
            JObject jo = JObject.Parse(json);
            return jo.Properties().First().Value.ToObject<T>();
        }
    }
}
