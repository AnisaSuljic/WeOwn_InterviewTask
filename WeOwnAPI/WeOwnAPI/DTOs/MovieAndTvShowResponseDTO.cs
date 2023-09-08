namespace WeOwnAPI.DTOs
{
    public class MovieAndTvShowResponseDTO
    {
        public int Pages { get; set; } //Number of pages
        public int CurrentPage { get; set; } //Current page

        public List<MovieAndTvShowDTO> MoviesAndTvSeries { get; set; } = new List<MovieAndTvShowDTO>();
    }
}
