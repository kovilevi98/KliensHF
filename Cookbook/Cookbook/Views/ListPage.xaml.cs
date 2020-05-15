using Cookbook.Models;
using Cookbook.ViewModels;
using System;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Cookbook.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListPage : Page
    {
        public static String NewUrl { get; set; }
        public static ListPageViewModel listPageViewModel;

        public ListPage()
        {
            this.InitializeComponent();
            listPageViewModel = new ListPageViewModel(NewUrl);
            listPageViewModel.ClearLists();
            GetList();
        }

        public async static void GetList()
        {
            await listPageViewModel.GetData();
        }

        private void BackButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                listPageViewModel.ClearLists();
            }
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var bookEntity = (BookEntity)e.ClickedItem;
            DetailsPage.BookEntity = bookEntity;
            Frame.Navigate(typeof(DetailsPage));
        }

        
    }
}
