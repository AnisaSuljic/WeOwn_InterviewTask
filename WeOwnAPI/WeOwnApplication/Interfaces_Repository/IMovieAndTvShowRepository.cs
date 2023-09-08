using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeOwnDomain.Database;

namespace WeOwnApplication.Interfaces_Repository
{
    public interface IMovieAndTvShowRepository
    {
        List<MovieAndTvShow> GetAllMovies(int pageIndex, float pageSize);
        List<MovieAndTvShow> GetAllMoviesByDirector(string director, int pageIndex, float pageSize);
        MovieAndTvShow Delete(int Id);
        MovieAndTvShow Insert(MovieAndTvShow movie);
        MovieAndTvShow Update(int Id, MovieAndTvShow movie);
    }
}
