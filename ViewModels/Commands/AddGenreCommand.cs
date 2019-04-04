using System;
using Common.Filters;
using Common.Models;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class AddGenreCommand : CommandBase
    {
        private readonly MovieListViewModel _model;

        public AddGenreCommand(MovieListViewModel model)
        {
            _model = model;
        }

        public override void Execute( object parameter )
        {
            if (_model.Genres.Contains(_model.Genre) )
            {
                return;
            }

            _model.Genres.Insert(0, _model.Genre);

            _model.OnPropertyChanged(nameof(_model.Genres));
            _model.OnPropertyChanged();
        }
    }
}