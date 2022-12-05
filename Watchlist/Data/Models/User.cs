using Microsoft.AspNetCore.Identity;
using Watchlist.Models;

namespace Watchlist.Data.Models
{
    public class User : IdentityUser
    {
        public List<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
