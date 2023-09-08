using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeOwnDomain.Database;

namespace WeOwnApplication.Interfaces_Service
{
    public interface IMovieAndTvShowService
    {
        List<MovieAndTvShow> GetAllMovies(int pageIndex, float pageSize);
        List<MovieAndTvShow> GetAllMoviesByDirector(string director, int pageIndex = 1, float pageSize = 10);
        MovieAndTvShow Delete(int Id);
        MovieAndTvShow Insert(MovieAndTvShow movie);
        MovieAndTvShow Update(int Id, MovieAndTvShow movie);

    }
}
