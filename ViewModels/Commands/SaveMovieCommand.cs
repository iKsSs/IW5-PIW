using System;
using System.Collections.Generic;
using System.Linq;
using Common.Filters;
using Common.Models;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class SaveMovieCommand : CommandBase
    {
        private readonly MovieListViewModel _model;

        public SaveMovieCommand(MovieListViewModel model)
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            var movie = _model.NewMovie;
            movie.Actors = new HashSet<Actor>(_model.Actors);
            movie.Directors = new HashSet<Director>(_model.Directors);
            movie.Genres = new HashSet<Genre>(_model.Genres);
            movie.Countries = new HashSet<Country>(_model.Countries);
            _model.Service.AddItem(movie);
            _model.Actors.Clear();
            _model.Directors.Clear();
            _model.Genres.Clear();
            _model.Countries.Clear();
            _model.NewMovie = null;
        }
    }
}
