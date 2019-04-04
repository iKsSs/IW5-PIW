using System;
using System.Windows.Input;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class CancelNewActorCommand: CommandBase
    {
        private readonly MovieListViewModel _model;

        public CancelNewActorCommand( MovieListViewModel model )
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            _model.NewActor = null;
        }
    }
}
