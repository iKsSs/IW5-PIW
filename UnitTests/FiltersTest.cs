using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Filters;

namespace UnitTests
{
    [TestClass]
    public class FiltersTest
    {
        [TestMethod]
        public void MovieFilterTestIfSomeParamsAreNull()
        {
            const string movieName = "Movie name";
            var filter = new MovieFilter(Guid.NewGuid(), movieName, null, null);

            Assert.IsTrue(filter.Name == movieName);
            Assert.IsNull(filter.Rating);
            Assert.IsNull(filter.Year);
        }

        [TestMethod]
        public void MovieFilterTestIfAllParamsAreNull()
        {
            var filter = new MovieFilter(null, null, null, null);

            Assert.IsNull(filter.Rating);
            Assert.IsNull(filter.Name);
            Assert.IsNull(filter.Year);
            Assert.IsNull(filter.Id);
        }

        [TestMethod]
        public void MovieFilterTestIfAllParamsAreCorrect()
        {
            const string name = "My Movie";
            const int rating = 10;
            const int year = 2009;

            var filter = new MovieFilter(Guid.NewGuid(), name, rating, year);

            Assert.IsTrue(filter.Rating == rating);
            Assert.IsTrue(filter.Name == name);
            Assert.IsTrue(filter.Year == year);
        }
    }
}
