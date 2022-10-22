using Microsoft.AspNetCore.Identity;

namespace Watchlist.Models
{
    public class User: IdentityUser
    {
      public   List<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
