using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class SaveDirectorCommand : CommandBase
    {
        private readonly MovieListViewModel _model;

        public SaveDirectorCommand( MovieListViewModel model )
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            var director = _model.NewDirector;
            _model.Service.AddDirector(director);
            _model.NewDirector = null;
            _model.OnPropertyChanged(nameof(_model.AvailableDirectors));
        }
    }
}