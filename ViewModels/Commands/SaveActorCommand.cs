using System;
using System.Linq;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class SaveActorCommand: CommandBase
    {
        private readonly MovieListViewModel _model;

        public SaveActorCommand( MovieListViewModel model )
        {
            _model = model;
        }

        public override void Execute( object parameter )
        {
            var actor = _model.NewActor;
            _model.Service.AddActor(actor);
            _model.NewActor = null;
            _model.OnPropertyChanged(nameof(_model.AvailableActors));
        }
    }
}
