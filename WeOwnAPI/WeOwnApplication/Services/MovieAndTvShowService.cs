using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeOwnApplication.Interfaces_Repository;
using WeOwnApplication.Interfaces_Service;
using WeOwnDomain.Database;

namespace WeOwnApplication.Services
{
    public class MovieAndTvShowService : IMovieAndTvShowService
    {
        private readonly IMovieAndTvShowRepository _movieRepository;

        public MovieAndTvShowService(IMovieAndTvShowRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public List<MovieAndTvShow> GetAllMovies(int pageIndex, float pageSize)
        {
            return _movieRepository.GetAllMovies(pageIndex, pageSize);
        }
        public List<MovieAndTvShow> GetAllMoviesByDirector(string director, int pageIndex = 1, float pageSize = 10)
        {
            return _movieRepository.GetAllMoviesByDirector(director, pageIndex, pageSize);
        }
        public MovieAndTvShow Delete(int Id)
        {
            return _movieRepository.Delete(Id);
        }        
        public MovieAndTvShow Insert(MovieAndTvShow movie)
        {
            return _movieRepository.Insert(movie);
        } 
        public MovieAndTvShow Update(int Id, MovieAndTvShow movie)
        {
            return _movieRepository.Update(Id, movie);
        }        
    }
}
