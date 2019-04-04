using System.Drawing;
using Common.Models;

namespace Common
{
    public interface IPlugin
    {
        string DataProviderAuthor { get; }
        string DataProviderDescription { get; }
        string DataProviderName { get; }
        DataProviderTypes DataProviderType { get; }
        int DataProviderVersion { get; }
        IRepository<Movie> MovieRepository { get; }
        IRepository<Director> DirectorRepository { get; }
        IRepository<Actor> ActorRepository { get; }
    }

    public enum DataProviderTypes
    {
        Database,
        WebApi,
        WebApiReadOnly
    }
}
