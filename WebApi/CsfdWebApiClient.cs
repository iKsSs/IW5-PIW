using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Common.Models;
using Newtonsoft.Json;
using WebApi.Contract;
using WebApi.Models;

namespace WebApi
{
    public class CsfdWebApiClient : IWebApiClient
    {
        public List<MovieApiModel> GetMoviesByName(string name)
        {
            List<MovieApiModel> movies = null;
            var client = CreateClient();
            var response = client.GetAsync($"movie?search={name}").Result;
            movies = JsonToObjectConverter<List<MovieApiModel>>(response);
            return movies;
        }

        public MovieApiModel GetMovieByApiId(int? id)
        {
            MovieApiModel movie = null;
            var client = CreateClient();
            var response = client.GetAsync($"movie/{id}").Result;
            movie = JsonToObjectConverter<MovieApiModel>(response);
            return movie;
        }

        private HttpClient CreateClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://csfdapi.cz/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private T JsonToObjectConverter<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync();
                json.Wait();
                return JsonConvert.DeserializeObject<T>(json.Result);
            }
            return default(T);
        }
    }
}
