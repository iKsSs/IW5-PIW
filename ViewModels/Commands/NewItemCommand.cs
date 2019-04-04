using System;
using System.Windows.Input;
using Common.Models;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class NewItemCommand : CommandBase
    {
        private MovieListViewModel _model;

        public NewItemCommand(MovieListViewModel model)
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            _model.NewMovie = new Movie();
        }
    }
}
