using Cookbook.Models;
using Cookbook.ViewModels;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Cookbook.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsPage : Page
    {
        public static BookEntity BookEntity { get; set; }
        public static DetailsPageViewModel detailsPageViewModel;
        public DetailsPage()
        {
            this.InitializeComponent();
            detailsPageViewModel = new DetailsPageViewModel();
            detailsPageViewModel.SetBook(BookEntity);
            DataContext = detailsPageViewModel;
            GetList();
        }

        public async static void GetList()
        {
            await detailsPageViewModel.GetData();
        }

       
    }
}
