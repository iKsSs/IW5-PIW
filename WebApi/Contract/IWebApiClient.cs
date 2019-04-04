using System.Collections.Generic;
using Common.Models;
using WebApi.Models;

namespace WebApi.Contract
{
    public interface IWebApiClient
    {
        List<MovieApiModel> GetMoviesByName(string name);
        MovieApiModel GetMovieByApiId(int? id);
    }
}
