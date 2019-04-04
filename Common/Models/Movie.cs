using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace Common.Models
{
    public class Movie : BaseModel
    {
        private string _orginalName;
        private string _name;
        private string _plot;
        private byte[] _poster;
        private int _runtime;
        private int _year;

        public string OrginalName
        {
            get { return _orginalName; }
            set
            {
                if (this._orginalName != value)
                {
                    this._orginalName = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (this._name != value)
                {
                    this._name = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Plot
        {
            get { return _plot; }
            set
            {
                if (this._plot != value)
                {
                    this._plot = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public byte[] Poster
        {
            get { return _poster; }
            set
            {
                if (this._poster != value)
                {
                    this._poster = value;
                    this.OnPropertyChanged(nameof(PosterImage));
                    this.OnPropertyChanged();
                }
            }
        }

        [NotMapped]
        public BitmapImage PosterImage
        {
            get
            {
                if (Poster != null)
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = new MemoryStream(Poster);
                    image.EndInit();
                    return image;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                byte[] data;
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(value));
                using (var ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                }
                Poster = data;
                this.OnPropertyChanged(nameof(Poster));
                this.OnPropertyChanged();
            }
        }

        [NotMapped]
        public string PosterImageUri
        {
            set
            {
                string tempFilename = $"temp-{Guid.NewGuid()}.jpg";
                using (var client = new WebClient())
                {
                    client.DownloadFile(value, tempFilename);
                }
                PosterImage = new BitmapImage(new Uri(tempFilename, UriKind.Relative)); 
                this.OnPropertyChanged(nameof(PosterImage));
                this.OnPropertyChanged();
            }
        }

        public int Runtime
        {
            get { return _runtime; }
            set
            {
                if (this._runtime != value)
                {
                    this._runtime = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                if (this._year != value)
                {
                    this._year = value;
                    this.OnPropertyChanged();
                }
            }
        }

        //Navigation property
        public HashSet<Country> Countries { get; set; }
        public HashSet<Genre> Genres { get; set; }
        public HashSet<Actor> Actors { get; set; }
        public HashSet<Director> Directors { get; set; }
        public HashSet<Rating> Ratings { get; set; }

        public Movie()
        {
            Actors = new HashSet<Actor>();
            Directors = new HashSet<Director>();
            Ratings = new HashSet<Rating>();
        }

        public override string ToString()
        {
            return $"ID: {base.Id}, Name: {Name}";
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public bool Equals(Movie compared)
        {
            var result =
                OrginalName.SequenceEqual(compared.OrginalName) &&
                Name == compared.Name &&
                Plot == compared.Plot &&
                Poster.SequenceEqual(compared.Poster) &&
                Year == compared.Year &&
                Runtime == compared.Runtime;
            return result;
        }
    }
}
