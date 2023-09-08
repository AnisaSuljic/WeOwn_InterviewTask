using System.ComponentModel.DataAnnotations;
using WeOwnAPI.ValueObjects;

namespace WeOwnAPI.DTOs
{
    public class MovieAndTvShowInsertDTO
    {
        [Required]
        [RegularExpression("^(Movie|TV Show)$", ErrorMessage = "Type must be 'Movie' or 'TVShow'.")]
        public string Type { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Director { get; set; } = null!;

        public string? Cast { get; set; }

        public string? Country { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
        public int Rating { get; set; }

        public string? Duration { get; set; }

        public string? ListedIn { get; set; }

        [MaxLength(250)]
        public string Description { get; set; } = null!;
    }
}
