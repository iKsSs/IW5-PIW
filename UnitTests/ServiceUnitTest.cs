using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Models;
using Data;
using Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using WebApi;
using WebApi.Contract;

namespace UnitTests
{
    [TestClass]
    public class ServiceUnitTest
    {
        private readonly Mock<IRepository<Movie>> _movieRepositoryMock;
        private readonly Mock<IRepository<Actor>> _actorRepositoryMock;
        private readonly Mock<IRepository<Director>> _directorRepositoryMock;
        private readonly Mock<IRepository<Country>> _countryRepositoryMock;
        private readonly Mock<IRepository<Genre>> _genreRepositoryMock;
        private readonly IWebApiClient _movieWebApiClientMock;
        private readonly MovieService _service;

        public ServiceUnitTest()
        {
            _movieRepositoryMock = new Mock<IRepository<Movie>>();
            _actorRepositoryMock = new Mock<IRepository<Actor>>();
            _directorRepositoryMock = new Mock<IRepository<Director>>();
            _countryRepositoryMock = new Mock<IRepository<Country>>();
            _genreRepositoryMock = new Mock<IRepository<Genre>>();
            _movieWebApiClientMock = new CsfdWebApiClient();
            _service = new MovieService(_movieRepositoryMock.Object, _directorRepositoryMock.Object, _actorRepositoryMock.Object, _countryRepositoryMock.Object, _genreRepositoryMock.Object,_movieWebApiClientMock);
        }

        [TestMethod]
        public void GetMoviesByFilter()
        {
            var expected = new Movie
            {
                Name = "Name",
                Year = 2006,
                Actors = {new Actor
                {
                    Name   = "Actor",
                }}
            };

            _movieRepositoryMock.Setup(f => f.GetAll()).Returns(new List<Movie> { expected }.AsQueryable());

            var result = _service.GetByFilter().First();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Equals(expected));
        }
    }
}
