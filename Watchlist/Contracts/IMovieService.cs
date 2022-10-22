﻿using Watchlist.Data;
using Watchlist.Models;

namespace Watchlist.Contracts
{
    public interface IMovieService
    {
         Task<IEnumerable<MovieViewModel>> GetAllAsync();
       
    }
}
