using System;
using Common.Filters;
using Common.Models;
using ViewModels.BaseCommands;
using ViewModels.ViewModels;
using System.Windows.Input;

namespace ViewModels.Commands
{
    public class DownloadPosterFromWebApiCommand : CommandBase
    {
        private readonly MovieListViewModel _model;

        public DownloadPosterFromWebApiCommand(MovieListViewModel model)
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            var posterUri = _model.Service.DownloadPosterFromWebApi(_model.NewMovie.Name);
            _model.NewMovie.PosterImageUri = posterUri;
        }
    }
}