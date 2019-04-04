using System;
using System.Windows.Input;
using Common.Filters;
using Common.Models;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class AddDirectorCommand : CommandBase
    {
        private readonly MovieListViewModel _model;

        public AddDirectorCommand(MovieListViewModel model)
        {
            _model = model;
        }
        
        public override void Execute(object parameter)
        {
            if (_model.Directors.Contains(_model.Director) )
            {
                return;
            }

            _model.Directors.Insert(0, _model.Director);

            _model.OnPropertyChanged(nameof(_model.Directors));
            _model.OnPropertyChanged();
        }
    }
}