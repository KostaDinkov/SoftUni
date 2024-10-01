using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.Data.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(40)]
        [MinLength(1)]
        public required string Title { get; set; }
        
        [Required]
        [MaxLength(40)]
        [MinLength(4)]
        public required string Genre { get; set; }

        [Required]
        [MaxLength(40)]
        public required string Director { get; set; }
        
        [Required]
        [Range(1,999)]
        public required int Duration { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public required DateOnly ReleaseDate { get; set; }
    }
}
