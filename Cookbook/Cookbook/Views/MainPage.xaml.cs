using Cookbook.Models;
using System;
using Windows.UI.Xaml.Controls;

namespace Cookbook.Views
{
    /// <summary>
    /// the codebehind class for the mainpage
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// the api url from the search result
        /// </summary>
        public String NewApiUrl { get; set; }
        /// <summary>
        /// the search entities object
        /// </summary>
        private SearchEntities Search = new SearchEntities();
        public MainPage()
        {
            InitializeComponent();
            CreateSearch();
            this.DataContext = Search;
        }
        /// <summary>
        /// initalize the search object
        /// </summary>
        private void CreateSearch()
        {
            Search.Subject = "";
            Search.Author = "";
            Search.Title = "";

        }
        /// <summary>
        /// the click event for the search button, and it make the api url and send to the next page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Search.Title = TitleBox.Text;
            Search.Subject = SubjectBox.Text;
            Search.Author = AutorBox.Text;
            Char apostrophe = '"';
            String newApiUrl =("title="+ apostrophe + Search.Title+ apostrophe + "&subject="+ apostrophe + Search.Subject+ apostrophe+ "&author="+ apostrophe + Search.Author+ apostrophe);
            ListPage.NewUrl = newApiUrl;
            Frame.Navigate(typeof(ListPage));

        }
    }
}

