using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Input;
using Common.Annotations;
using Common.Filters;
using Common.Models;
using Services;
using Services.Contracts;
using ViewModels.Commands;
using ViewModels.Contracts;

namespace ViewModels.ViewModels
{
    public class MovieListViewModel : INotifyPropertyChanged
    {
        public IService Service { get; private set; }

        public ICommand MovieFilterCommand { get; private set; }
        public ICommand NewMovieCommand { get; private set; }
        public ICommand CancelNewMovieCommand { get; private set; }
        public ICommand SaveMovieCommand { get; private set; }
        public ICommand DownloadPosterFromWebApiCommand { get; private set; }

        public ICommand AddGenreCommand { get; private set; }
        public ICommand AddCountryCommand { get; private set; }
        public ICommand AddDirectorCommand { get; private set; }
        public ICommand AddActorCommand { get; private set; }

        public ICommand NewDirectorCommand { get; private set; }
        public ICommand NewActorCommand { get; private set; }
        public ICommand CancelNewDirectorCommand { get; private set; }
        public ICommand CancelNewActorCommand { get; private set; }
        public ICommand SaveDirectorCommand { get; private set; }
        public ICommand SaveActorCommand { get; private set; }

        public ICommand RemoveMovieCommand { get; private set; }

        public MovieListViewModel(IService service)
        {
            Service = service;

            MovieFilter = new MovieFilter();
            SelectedMovie = null;
            NewMovie = null;
            NewActor = null;
            NewDirector = null;

            MovieFilterCommand = new FilterCommand(this);
            NewMovieCommand = new NewItemCommand(this);
            CancelNewMovieCommand = new CancelNewItemCommand(this);
            SaveMovieCommand = new SaveMovieCommand(this);
            DownloadPosterFromWebApiCommand = new DownloadPosterFromWebApiCommand(this);

            AddGenreCommand = new AddGenreCommand(this);
            AddCountryCommand = new AddCountryCommand(this);
            AddDirectorCommand = new AddDirectorCommand(this);
            AddActorCommand = new AddActorCommand(this);

            NewDirectorCommand = new NewDirectorCommand(this);
            NewActorCommand = new NewActorCommand(this);
            CancelNewActorCommand = new CancelNewActorCommand(this);
            CancelNewDirectorCommand = new CancelNewDirectorCommand(this);
            SaveActorCommand = new SaveActorCommand(this);
            SaveDirectorCommand = new SaveDirectorCommand(this); 
            
            RemoveMovieCommand = new RemoveMovieCommand(this);      

            Genres = new ObservableCollection<Genre>();
            Countries = new ObservableCollection<Country>();
            Directors = new ObservableCollection<Director>();
            Actors = new ObservableCollection<Actor>();
        }

        public List<Movie> Movies => Service.GetByFilter(MovieFilter);

        private MovieFilter _movieFilter;

        public MovieFilter MovieFilter
        {
            set
            {
                _movieFilter = value;
                OnPropertyChanged(nameof(Movies));
                OnPropertyChanged();
            }
            get { return _movieFilter; }
        }

        private Movie _selectedMovie;

        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
                OnPropertyChanged();
            }
        }

        private Movie _newMovie;

        public Movie NewMovie
        {
            get { return _newMovie; }
            set
            {
                _newMovie = value;
                OnPropertyChanged(nameof(Movies));
                OnPropertyChanged();
            }
        }

        private Actor _newActor;

        public Actor NewActor
        {
            get { return _newActor; }
            set
            {
                _newActor = value;
                OnPropertyChanged();
            }
        }

        private Director _newDirector;

        public Director NewDirector
        {
            get { return _newDirector; }
            set
            {
                _newDirector = value;
                OnPropertyChanged();
            }
        }

        public List<Actor> AvailableActors => Service.GetAllActors().OrderBy(o => o.Name).ToList();
        public List<Director> AvailableDirectors => Service.GetAllDirectors().OrderBy(o => o.Name).ToList();
        public List<Genre> AvailableGenres => Service.GetAllGenres().OrderBy(o => o.Name).ToList();
        public List<Country> AvailableCountries => Service.GetAllCountries().OrderBy(o=>o.Name).ToList();
        
        public ObservableCollection<Genre> Genres { get; set; }
        public ObservableCollection<Country> Countries { get; set; }
        public ObservableCollection<Director> Directors { get; set; }
        public ObservableCollection<Actor> Actors { get; set; }

        public Genre Genre { get; set; }
        public Country Country { get; set; }
        public Actor Actor { get; set; }
        public Director Director { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void OnProgramShutdownStarted(object sender, EventArgs e)
        {
            Service.Dispose();
        }
    }
}
