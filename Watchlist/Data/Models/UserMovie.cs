using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watchlist.Data.Models
{
    public class UserMovie
    {
        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Required]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }
    }
}

//•	UserId – a string, Primary Key, foreign key (required)
//•	User – User
//•	MovieId – an integer, Primary Key, foreign key (required)
//•	Movie – Movie
