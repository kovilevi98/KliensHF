using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Cookbook.Models
{

    public class ISBN
    {
        public Publisher[] publishers { get; set; }
        public string pagination { get; set; }
        public Identifiers identifiers { get; set; }
        public Classifications classifications { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string notes { get; set; }
        public int number_of_pages { get; set; }
        public Cover cover { get; set; }
        public Subject[] subjects { get; set; }
        public string publish_date { get; set; }
        public string key { get; set; }
        public Author[] authors { get; set; }
        public string by_statement { get; set; }
        public Publish_Places[] publish_places { get; set; }
    }

    public class Identifiers
    {
        public string[] lccn { get; set; }
        public string[] openlibrary { get; set; }
        public string[] isbn_10 { get; set; }
        public string[] oclc { get; set; }
        public string[] librarything { get; set; }
        public string[] goodreads { get; set; }
    }

    public class Classifications
    {
        public string[] dewey_decimal_class { get; set; }
    }

    public class Publisher
    {
        public string name { get; set; }
    }

    public class Subject
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Author
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Publish_Places
    {
        public string name { get; set; }
    }

    public class Cover
    {
        public string small { get; set; }
        public string large { get; set; }
        public string medium { get; set; }
    }


    public class ImportantDetails
    {
        public string AuthorName { get; set; }
        public string AuthorUrl { get; set; }
        public string ImageM { get; set; }
        public string ImageL { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public ImageSource img { get; set; }

        
    }
}
