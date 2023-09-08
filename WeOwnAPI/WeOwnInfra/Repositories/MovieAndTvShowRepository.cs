using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeOwnApplication.Interfaces_Repository;
using WeOwnDomain.Database;

namespace WeOwnInfra.Repositories
{
    public class MovieAndTvShowRepository : IMovieAndTvShowRepository
    {
        private readonly WeOwnContext _context;

        public MovieAndTvShowRepository(WeOwnContext context)
        {
            _context = context;
        }
      
        public List<MovieAndTvShow> GetAllMovies(int pageIndex, float pageSize)
        {
            IQueryable<MovieAndTvShow> movieList = _context.MovieAndTvShows;

            movieList = movieList
                .Skip((pageIndex - 1) * (int)pageSize)
                .Take((int)pageSize)
                .OrderByDescending(x => x.ReleaseYear);


            return movieList.ToList();
        }

        public List<MovieAndTvShow> GetAllMoviesByDirector(string director, int pageIndex, float pageSize)
        {
            IQueryable<MovieAndTvShow> movieList = _context.MovieAndTvShows.Where(x => x.Director.ToLower().Equals(director.ToLower()));


            var movieListResult = movieList
                .Where(x => x.Type == "Movie")
                .Skip((pageIndex - 1) * (int)pageSize)
                .Take((int)pageSize)
                .OrderByDescending(x => x.Rating);

            if (!movieListResult.Any())
            {
                movieList = movieList.Where(x => x.Type == "TV Show")
                .Skip((pageIndex - 1) * (int)pageSize)
                .Take((int)pageSize)
                .OrderByDescending(x => x.Rating);

                return movieList.ToList();
            }

            return movieListResult.ToList();
        }

        public MovieAndTvShow Insert(MovieAndTvShow movie)
        {
            _context.MovieAndTvShows.Add(movie);
            _context.SaveChanges();

            _context.MovieAndTvShows.Find(movie.Id).ShowId = "s" + movie.Id;

            _context.SaveChanges();

            return movie; 
        }

        public MovieAndTvShow Update(int Id, MovieAndTvShow movie)
        {
            var movieForUpdate = _context.MovieAndTvShows.Find(Id);
            if (movieForUpdate == null)
                throw new ArgumentNullException("There is no movies with id " + Id);


            movieForUpdate.Type = movie.Type;
            movieForUpdate.Title = movie.Title;
            movieForUpdate.Director = movie.Director;
            movieForUpdate.Cast = movie.Cast;
            movieForUpdate.Country = movie.Country;
            movieForUpdate.DateAdded = movie.DateAdded;
            movieForUpdate.ReleaseYear = movie.ReleaseYear;
            movieForUpdate.Rating = movie.Rating;
            movieForUpdate.Duration = movie.Duration;
            movieForUpdate.ListedIn = movie.ListedIn;
            movieForUpdate.Description = movie.Description;


            _context.SaveChanges();

            return movieForUpdate;
        }

        public MovieAndTvShow Delete(int Id)
        {
            var movie = _context.MovieAndTvShows.Find(Id);
            if (movie == null)
                throw new ArgumentNullException();
            var x = movie;
            _context.MovieAndTvShows.Remove(movie);
            _context.SaveChanges();
            return x;
        }
    }
}
