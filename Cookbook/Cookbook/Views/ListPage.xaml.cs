using Cookbook.Models;
using Cookbook.ViewModels;
using System;
using Windows.UI.Xaml.Controls;

namespace Cookbook.Views
{
    /// <summary>
    /// The Page of the BookList
    /// </summary>
    public sealed partial class ListPage : Page
    {
        /// <summary>
        /// it is the specific url for the API calls
        /// </summary>
        public static String NewUrl { get; set; }
        /// <summary>
        /// an object of the ListPageViewModel
        /// </summary>
        public static ListPageViewModel listPageViewModel;

        public ListPage()
        {
            this.InitializeComponent();
            listPageViewModel = new ListPageViewModel(NewUrl);
            listPageViewModel.ClearLists();
            GetList();
        }
        /// <summary>
        /// call the getdata
        /// </summary>
        public async static void GetList()
        {
            await listPageViewModel.GetData();
        }
        /// <summary>
        /// back button clicklistener for back to the previous page and clear the lists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                listPageViewModel.ClearLists();
            }
        }
        /// <summary>
        /// click listener for each gridview item. and open the details page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var bookEntity = (BookEntity)e.ClickedItem;
            DetailsPage.BookEntity = bookEntity;
            Frame.Navigate(typeof(DetailsPage));
        }

        
    }
}
