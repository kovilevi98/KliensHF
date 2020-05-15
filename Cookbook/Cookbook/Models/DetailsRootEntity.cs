using Windows.UI.Xaml.Media;

namespace Cookbook.Models
{
    /// <summary>
    /// Generated classes from an API call for one Book, they containd all information for one book
    /// </summary>
    public class ISBN
    {
        public Publisher[] Publishers { get; set; }
        public string Pagination { get; set; }
        public Identifiers Identifiers { get; set; }
        public Classifications Classifications { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Notes { get; set; }
        public int Number_of_pages { get; set; }
        public Cover Cover { get; set; }
        public Subject[] Subjects { get; set; }
        public string Publish_date { get; set; }
        public string Key { get; set; }
        public Author[] Authors { get; set; }
        public string By_statement { get; set; }
        public Publish_Places[] Publish_places { get; set; }
    }

    public class Identifiers
    {
        public string[] Lccn { get; set; }
        public string[] Openlibrary { get; set; }
        public string[] Isbn_10 { get; set; }
        public string[] Oclc { get; set; }
        public string[] Librarything { get; set; }
        public string[] Goodreads { get; set; }
    }

    public class Classifications
    {
        public string[] Dewey_decimal_class { get; set; }
    }

    public class Publisher
    {
        public string Name { get; set; }
    }

    public class Subject
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }

    public class Author
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }

    public class Publish_Places
    {
        public string Name { get; set; }
    }

    public class Cover
    {
        public string Small { get; set; }
        public string Large { get; set; }
        public string Medium { get; set; }
    }

    /// <summary>
    /// They are just the important entities for a book, what i used on the DetailsPage
    /// </summary>
    public class ImportantDetails
    {
        public string AuthorName { get; set; }
        public string AuthorUrl { get; set; }
        public string ImageM { get; set; }
        public string ImageL { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public ImageSource Img { get; set; }

    }
}
