using System.ComponentModel.DataAnnotations;

namespace Watchlist.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; } = null!;
    }
}


//•	Has Id – a unique integer, Primary Key
//•	Has Name – a string with min length 5 and max length 50 (required)

