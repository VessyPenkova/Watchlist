using Watchlist.Data;
using Watchlist.Models;

namespace Watchlist.Contracts
{
    public interface IMovieService
    {
         Task<IEnumerable<MovieViewModel>> GetAllAsync();
         Task<IEnumerable<Genre>> GetGanresAsync();
         Task AddMoviesAsync(AddMovieViewModel model);
         Task AddMovieToCollectionAsync(int movieId, string userId);
         Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userid);

    }
}
