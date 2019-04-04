using System;
using System.Windows.Input;
using Common.Models;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class NewDirectorCommand : CommandBase
    {
        private readonly MovieListViewModel _model;

        public NewDirectorCommand( MovieListViewModel model )
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            _model.NewDirector = new Director();
        }
    }
}
