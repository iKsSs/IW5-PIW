using System;
using Common.Filters;
using Common.Models;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class AddCountryCommand : CommandBase
    {
        private readonly MovieListViewModel _model;

        public AddCountryCommand(MovieListViewModel model)
        {
            _model = model;
        }

        public override void Execute( object parameter )
        {
            if (_model.Countries.Contains(_model.Country) )
            {
                return;
            }

            _model.Countries.Insert(0, _model.Country);

            _model.OnPropertyChanged(nameof(_model.Countries));
            _model.OnPropertyChanged();
        }
    }
}