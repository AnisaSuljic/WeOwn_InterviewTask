using WeOwnAPI.Helpers;
using WeOwnAPI.ValueObjects;

namespace WeOwnAPI.DTOs
{
    public class MovieAndTvShowDTO
    {

        public Typee Type { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string? Cast { get; set; }

        public string? Country { get; set; }

        public DateTime? DateAdded { get; set; }

        public int ReleaseYear { get; set; }

        public Rating Rating { get; set; } = null!;

        public string? Duration { get; set; }

        public string? ListedIn { get; set; }

        public Description? Description { get; set; }

    }
}
