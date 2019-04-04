using Common;
using Common.Filters;
using Common.Models;
using Data;
using Data.Repository;
using Services;
using Services.Contracts;
using SimpleInjector;
using WebApi;
using WebApi.Contract;
using Container = SimpleInjector.Container;

namespace Windows
{
    public class SimpleInjector
    {
        public static Container Booster()
        {
            var container = new Container();

            //Registers
            container.Register<LocalDbContext, LocalDbContext>(Lifestyle.Singleton);
            container.Register<IRepository<Movie>, MovieRepository>(Lifestyle.Singleton);
            container.Register<IRepository<Actor>, ActorRepository>(Lifestyle.Singleton);
            container.Register<IRepository<Director>, DirectorRepository>(Lifestyle.Singleton);
            container.Register<IRepository<Country>, CountryRepository>(Lifestyle.Singleton);
            container.Register<IRepository<Genre>, GenreRepository>(Lifestyle.Singleton);
            container.Register<IService, MovieService>(Lifestyle.Singleton);
            container.Register<IWebApiClient, CsfdWebApiClient>(Lifestyle.Singleton);

            container.Verify();

            return container;
        }
    }
}
