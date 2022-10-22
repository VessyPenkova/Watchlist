using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength =10)]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength =5)]
        public string Director { get; set; }

        [Required]

        public string ImageUrl { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "10.00", ConvertValueInInvariantCulture =true)]
        public decimal Rating { get; set; }
      
        public string Genre { get; set; }
 
    }
}
