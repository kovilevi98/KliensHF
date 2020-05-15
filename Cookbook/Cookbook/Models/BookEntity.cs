using System;
using Windows.UI.Xaml.Media;

namespace Cookbook.Models
{
    /// <summary>
    /// Object for Entity of an object what is in the list
    /// </summary>
    public class BookEntity
    {
        public String Title { get; set; }
        public ImageSource Img { get; set; }
        public string[] Isbn { get; set; }
        public string[] Oclc { get; set; }
        public string[] Lccn { get; set; }
    }
}
