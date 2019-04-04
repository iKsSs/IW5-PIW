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
using Microsoft.Win32;

namespace Windows.UserControls
{
    /// <summary>
    /// Interaction logic for AddActorUserControl.xaml
    /// </summary>
    public partial class AddActorUserControl : UserControl
    {
        public AddActorUserControl()
        {
            InitializeComponent();
        }
 
        public void Show()
        {
            this.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void AddNewPortraitButton_Click( object sender, RoutedEventArgs e )
        {
            var op = new OpenFileDialog
            {
                Title = "Select a picture",
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                         "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                         "Portable Network Graphic (*.png)|*.png"
            };

            if ( op.ShowDialog() == true )
            {
                PortraitImage.Source = new BitmapImage(new Uri(op.FileName));

            }
        }
    }
}
