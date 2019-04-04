using System;
using System.Windows.Input;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class CancelNewItemCommand : CommandBase
    {
        private readonly MovieListViewModel _model;

        public CancelNewItemCommand(MovieListViewModel model)
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            _model.NewMovie = null;
        }
    }
}
