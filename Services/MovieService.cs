using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Channels;
using Common;
using Common.Filters;
using Common.Models;
using Services.Contracts;
using WebApi.Contract;

namespace Services
{
    public class MovieService : IService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Director> _directoRepository;
        private readonly IRepository<Actor> _actorRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<Genre> _genreRepository; 
        private readonly IWebApiClient _movieWebApiClient;

        public MovieService(IRepository<Movie> movieRepository, IRepository<Director> directorRepository, IRepository<Actor> actorRepository, IRepository<Country> countryRepository, IRepository<Genre> genreRepository, IWebApiClient movieWebApiClient)
        {
            _movieRepository = movieRepository;
            _directoRepository = directorRepository;
            _actorRepository = actorRepository;
            _movieWebApiClient = movieWebApiClient;
            _countryRepository = countryRepository;
            _genreRepository = genreRepository;
        }

        public List<Movie> GetByFilter(MovieFilter filter = null)
        {
            var result = filter == null 
                ? _movieRepository
                    .GetAll()
                    .Include(t => t.Actors)
                    .Include(t => t.Directors)
                    .Include(t => t.Ratings)
                    .Include(t => t.Countries)
                    .Include(t => t.Genres)
                    .ToList() 
                : _movieRepository
                    .GetBy(t => string.IsNullOrEmpty(filter.Name) ? true : t.Name == filter.Name)
                    .Include(t => t.Actors)
                    .Include(t => t.Directors)
                    .Include(t => t.Ratings)
                    .Include(t => t.Countries)
                    .Include(t => t.Genres)
                    .ToList();

            return result;
        }

        public Movie GetById(Guid id)
        {
            var result = _movieRepository.GetById(id);
            return result;
        }

        public void AddItem(Movie newModel)
        {
            _movieRepository.Add(newModel);
            _movieRepository.Save();
        }

        public void DeleteItem(Movie deletedModel)
        {
            _movieRepository.Delete(deletedModel);
            _movieRepository.Save();
        }

        public void UpdateItem(Movie updatedModel, Movie updatingModel)
        {
            //TODO
        }

        public void Dispose()
        {
            _movieRepository.Dispose();
            _actorRepository.Dispose();
            _directoRepository.Dispose();
            _countryRepository.Dispose();
            _genreRepository.Dispose();
        }

        public void LoadAll()
        {
            _movieRepository.LoadAll();
        }

        public List<Actor> GetAllActors()
        {
            return _actorRepository.GetAll().ToList();
        }

        public List<Director> GetAllDirectors()
        {
            return _directoRepository.GetAll().ToList();
        }

        public string DownloadPosterFromWebApi(string name)
        {
            var movies = _movieWebApiClient.GetMoviesByName(name);
            return movies.FirstOrDefault()?.PosterUri;
        }

        public List<Genre> GetAllGenres()
        {
            return _genreRepository.GetAll().ToList();
        }

        public List<Country> GetAllCountries()
        {
            return _countryRepository.GetAll().ToList();
        }

        public void AddDirector(Director director)
        {
            _directoRepository.Add(director);
            _directoRepository.Save();
        }

        public void AddActor(Actor actor)
        {
            _actorRepository.Add(actor);
            _actorRepository.Save();
        }
    }
}
