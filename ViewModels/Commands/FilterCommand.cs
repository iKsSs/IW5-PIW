using System;
using System.Windows.Input;
using Common.Filters;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class FilterCommand : CommandBase 
    {
        private readonly MovieListViewModel _model;

        public FilterCommand(MovieListViewModel model)
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            _model.MovieFilter = parameter as MovieFilter; 
        }
    }
}
