using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Cookbook.Models
{
    public class BookEntity
    {
        public String Title { get; set; }
        public ImageSource Img { get; set; }
        public string[] isbn { get; set; }
        public string[] oclc { get; set; }
        public string[] lccn { get; set; }
    }
}
