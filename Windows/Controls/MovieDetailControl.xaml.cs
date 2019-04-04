using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common.Models;

namespace Windows.Controls
{
    /// <summary>
    /// Interaction logic for MovieDetailControl.xaml
    /// </summary>
    public partial class MovieDetailControl : UserControl
    {
        public MovieDetailControl()
        {
            InitializeComponent();
            this.DataContext = new Movie()
            {
                Name = "Film1",
                LocalNames = new List<string> {"Movie1"},
                Runtime = 50,
                Year = 1999,
                Plot = "Interesting movie!",
                Genres = new List<string> {"action", "drama"},
                Countries = new List<string> {"CZE", "USA"}
            };
        }
    }
}
