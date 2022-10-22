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
            var entites = await context.Movies
                .Include(m => m.Genre)
                .ToListAsync();

            return entites
                .Select(m => new MovieViewModel()
                { 
                Director = m.Director,
                Genre = m?.Genre?.Name,
                Id = m.Id, 
                ImageUrl = m.ImageUrl,
                Rating = m.Rating,
                Title = m.Title
                });
        }

        public async Task<IEnumerable<Genre>> GetGanresAsync()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task AddMoviesAsync(AddMovieViewModel model)
        {
            var entity = new Movie()
            {
                Director = model.Director,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Title = model.Title
            };
            await context.Movies.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddMovieToCollectionAsync(int movieId, string userId)
        {

            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new ArgumentException("Invalid user Id");
            }
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                throw new ArgumentException("Invalid movie Id");
            }
            user.UsersMovies.Add(new UserMovie()
            {
                MovieId = movie.Id,
                UserId = user.Id,
                Movie = movie, 
                User = user 
            });

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(un => un.Movie)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id");
            }
            return user.UsersMovies
                .Select(m => new MovieViewModel()
                {
                  Director = m.Movie.Director,
                  Genre = m.Movie.Genre.Name,
                  Id = m.Movie.Id,
                  ImageUrl = m.Movie.ImageUrl,
                  Title = m.Movie.Title, 
                  Rating = m.Movie.Rating

                });   
        }
    }
}

