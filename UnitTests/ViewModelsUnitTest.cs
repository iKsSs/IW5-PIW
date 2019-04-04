//using System.Collections.Generic;
//using Common.Filters;
//using Common.Models;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Services;
//using Services.Contracts;
//using ViewModels;
//using ViewModels.ViewModels;

//namespace UnitTests
//{
//    [TestClass]
//    public class ViewModelsUnitTest
//    {
//        private readonly Mock<IService> _movieServiceMock;

//        public ViewModelsUnitTest()
//        {
//            _movieServiceMock = new Mock<IService>();
//        }

//        [TestMethod]
//        public void GetMoviesTest()
//        {
//            var filter1 = new MovieFilter
//            {
//                Name = "Film1"
//            };
//            var filter2 = new MovieFilter
//            {
//                Name = "Film2"
//            };

//            _movieServiceMock.Setup(f => f.GetByFilter(filter1))
//                .Returns(new List<Movie> { new Movie() { Name = filter1.Name } });
//            _movieServiceMock.Setup(f => f.GetByFilter(filter2))
//                .Returns(new List<Movie> { new Movie() { Name = filter2.Name } });

//            var viewModel = new MovieListViewModel(_movieServiceMock.Object);

//            viewModel.MovieFilter = filter1;
//            var result1 = viewModel.Movies;

//            viewModel.MovieFilter = filter2;
//            var result2 = viewModel.Movies;

//            Assert.IsTrue(result1[0].Name == filter1.Name);
//            Assert.IsTrue(result2[0].Name == filter2.Name);
//        }
//    }
//}
