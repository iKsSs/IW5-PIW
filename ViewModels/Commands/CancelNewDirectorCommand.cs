using System;
using System.Windows.Input;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class CancelNewDirectorCommand: CommandBase
    {
        private readonly MovieListViewModel _model;

        public CancelNewDirectorCommand( MovieListViewModel model )
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            _model.NewDirector = null;
        }
    }
}
