using Microsoft.EntityFrameworkCore;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllAsync()
        {
            var entites = await context.Movies.ToListAsync();

            return entites
                .Select(m => new MovieViewModel()
                { 
                Director = m.Director,
                Genre = m?.Genre.Name,
                Id = m.Id, 
                ImageUrl = m.ImageUrl,
                Rating = m.Rating,
                Title = m.Title
                });
        }
    }
}

