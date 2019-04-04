using System;
using System.Windows.Input;
using Common.Filters;
using Common.Models;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;

namespace ViewModels.Commands
{
    public class RemoveMovieCommand : CommandBase
    {
        private readonly MovieListViewModel _model;

        public RemoveMovieCommand(MovieListViewModel model)
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            var item = _model.SelectedMovie;
            _model.Service.DeleteItem(item);
            _model.OnPropertyChanged(nameof(_model.Movies));
            _model.OnPropertyChanged();
            //nepouzivame observable collection, nutno zavolat a upozornit view model, ze zobrazovane vysledky se mohly zmenit
        }
    }
}
