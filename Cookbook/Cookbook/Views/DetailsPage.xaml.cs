using Cookbook.Models;
using Cookbook.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Cookbook.Views
{
    /// <summary>
    /// The Page of the Details
    /// </summary>
    public sealed partial class DetailsPage : Page
    {
        /// <summary>
        /// a bookEntity object
        /// </summary>
        public static BookEntity BookEntity { get; set; }
        /// <summary>
        /// object of the DetailsPageViewModel
        /// </summary>
        public static DetailsPageViewModel detailsPageViewModel;
        public DetailsPage()
        {
            this.InitializeComponent();
            detailsPageViewModel = new DetailsPageViewModel();
            detailsPageViewModel.SetBook(BookEntity);
            DataContext = detailsPageViewModel;
            GetList();
        }
        /// <summary>
        /// call the viewmodel getData function for the api call
        /// </summary>
        public async static void GetList()
        {
            await detailsPageViewModel.GetData();
        }

       
    }
}
