using System;
using System.Linq;
using Common.Filters;
using Common.Models;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class AddActorCommand : CommandBase
    {
        private readonly MovieListViewModel _model;

        public AddActorCommand(MovieListViewModel model)
        {
            _model = model;
        }

        public override void Execute( object parameter )
        {
            if (_model.Actors.Contains(_model.Actor))
            {
                return;
            }

            _model.Actors.Insert(0, _model.Actor);
            _model.OnPropertyChanged(nameof(_model.Actors));
            _model.OnPropertyChanged();
        }
    }
}