using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using Common.Models;
using Data;
using Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class MovieRepositoryTest
    {
        private readonly BaseRepository<Movie> _movieRepository;

        public MovieRepositoryTest()
        {
            _movieRepository = new BaseRepository<Movie>(new LocalDbContext());
            Init();
        }

        private void Init()
        {
            var movies = new List<Movie>()
            { new Movie()
            {
                Name = "Návštěva",
                Year = 2015,
                Plot = @"Mimozemšťané možná ještě Zemi nenavštívili, 
ovšem lidé vysílají signály do vesmíru, a
oznamují tak svou existenci jiným civilizacím už 
od vynálezu rozhlasu. Otázkou tedy není,
zda k takové návštěvě dojde, ale kdy. 
Film díky výjimečné možnosti obrátit se na
Úřad OSN pro vesmírné záležitosti, odborníky
z NASA, ISU (International Space University) a 
institutu SETI pro výzkum mimozemské inteligence a 
na vojenské poradce odvíjí mrazivě uvěřitelný scénář 
prvního kontaktu na světě, počínaje těmi 
nejprostšími otázkami: Proč jste tady? Jak myslíte?",
                Directors = {new Director
                {
                    Name = "Michael Madsen"
                } },
                Runtime = 84,
                OrginalName = "The Visit",
                //Poster = ,
                PosterImage = new BitmapImage(new Uri("D:/obr.bmp"))
            }
            };

            _movieRepository.DeleteAll();
            foreach (var movie in movies)
            {
                _movieRepository.Add(movie);
            }
            _movieRepository.Save();
        }

        [TestMethod]
        public void AddAndGetById()
        {
            //Arrange
            var movie = new Movie()
            {
                Name = "Ben Hur"
            };

            //Act
            _movieRepository.Add(movie);
            _movieRepository.Save();
            var result = _movieRepository.GetById(movie.Id);

            //Asserts
            Assert.IsNotNull(result);
            Assert.IsTrue(movie.Id == result.Id);
        }

        [TestMethod]
        public void GetByPredicate()
        {
            //Arange
            const string name = "Návštěva";

            //Act
            var result = _movieRepository.GetBy(p => p.Name == name).FirstOrDefault();

            //Asserts
            Assert.IsNotNull(result);
            Assert.IsTrue(name == result.Name);
        }
    }
}

//TODO other tests
