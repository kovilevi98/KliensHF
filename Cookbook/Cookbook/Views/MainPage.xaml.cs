using Cookbook.Models;
using System;
using Windows.UI.Xaml.Controls;

namespace Cookbook.Views
{
    public sealed partial class MainPage : Page
    {
        public String newApiUrl { get; set; }
        SearchEntities search = new SearchEntities();
        public MainPage()
        {
            InitializeComponent();
            CreateSearch();
            this.DataContext = search;
        }

        private void CreateSearch()
        {
            search.Subject = "";
            search.Author = "";
            search.Title = "";

        }

        private void okButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            search.Title = TitleBox.Text;
            search.Subject = SubjectBox.Text;
            search.Author = AutorBox.Text;
            Char apostrophe = '"';
            String newApiUrl =("title="+ apostrophe + search.Title+ apostrophe + "&subject="+ apostrophe + search.Subject+ apostrophe+ "&author="+ apostrophe + search.Author+ apostrophe);
            ListPage.NewUrl = newApiUrl;
            Frame.Navigate(typeof(ListPage));

        }


    }
}

