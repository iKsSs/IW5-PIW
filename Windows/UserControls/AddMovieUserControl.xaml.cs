using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Common.Models;
using Microsoft.Win32;
using ViewModels.Contracts;
using System.Windows.Interactivity;

namespace Windows.UserControls
{
    /// <summary>
    /// Interaction logic for AddMovieUserControl.xaml
    /// </summary>
    public partial class AddMovieUserControl : UserControl, IUserControl
    {
        public AddMovieUserControl()
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

        private void AddNewPosterButton_Click( object sender, RoutedEventArgs e )
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
                PosterImage.Source = new BitmapImage(new Uri(op.FileName));
                
            }
        }
    }
}
