using System.ComponentModel.DataAnnotations;


namespace Watchlist.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]

        public string Name { get; set; }
    }
}

//•	Has Id – a unique integer, Primary Key
//•	Has Name – a string with min length 5 and max length 50 (required)

