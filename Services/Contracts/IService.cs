using System;
using System.Collections.Generic;
using Common.Filters;
using Common.Models;

namespace Services.Contracts
{
    public interface IService
    {
        List<Movie> GetByFilter(MovieFilter filter);
        Movie GetById(Guid id);
        void AddItem(Movie newModel);
        void DeleteItem(Movie deletedModel);
        void UpdateItem(Movie updatedModel, Movie updatingModel);
        void Dispose();
        void LoadAll();
        List<Actor> GetAllActors();
        List<Director> GetAllDirectors();
        string DownloadPosterFromWebApi(string name);
        List<Genre> GetAllGenres();
        List<Country> GetAllCountries();
        void AddDirector(Director director);
        void AddActor(Actor actor);
    }
}
