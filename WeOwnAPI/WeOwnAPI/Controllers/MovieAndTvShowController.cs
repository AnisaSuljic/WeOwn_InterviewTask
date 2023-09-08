using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeOwnAPI.DTOs;
using WeOwnAPI.Helpers;
using WeOwnApplication.Interfaces_Service;
using WeOwnDomain.Database;

namespace WeOwnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieAndTvShowController : ControllerBase
    {
        private readonly IMovieAndTvShowService _movieService;
        private readonly IMapper _mapper;
        private readonly WeOwnContext _context;

        public MovieAndTvShowController(IMovieAndTvShowService movieService, IMapper mapper, WeOwnContext context)
        {
            _movieService = movieService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<MovieAndTvShowResponseDTO> GetAllMovies(int pageIndex = 1, float pageSize = 10)
        {
            if (pageIndex <= 0 || pageSize <= 0)
                return NotFound();

            var moviesFromService = _movieService.GetAllMovies(pageIndex, pageSize);
            var pageCount = Math.Ceiling(_context.MovieAndTvShows.Count() / pageSize);

            var response = new MovieAndTvShowResponseDTO()
            {
                MoviesAndTvSeries = _mapper.Map<List<MovieAndTvShowDTO>>(moviesFromService),
                CurrentPage = pageIndex,
                Pages = (int)pageCount
            };

            return Ok(response);
        }

        [HttpGet("GetAllMoviesByDirector/{director}")]
        public ActionResult<MovieAndTvShowResponseDTO> GetAllMoviesByDirector(string director, int pageIndex = 1, float pageSize = 10)
        {
            if (pageIndex <= 0 || pageSize <= 0)
                return NotFound();

            var moviesFromService = _movieService.GetAllMoviesByDirector(director, pageIndex, pageSize);
            var pageCount = Math.Ceiling(_context.MovieAndTvShows.Count() / pageSize);

            var response = new MovieAndTvShowResponseDTO()
            {
                MoviesAndTvSeries = _mapper.Map<List<MovieAndTvShowDTO>>(moviesFromService),
                CurrentPage = pageIndex,
                Pages = (int)pageCount
            };

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public ActionResult<MovieAndTvShowResponseDTO> Delete(int Id)
        {
            if (Id <= 0)
                return NotFound();

            try
            {
                var movie = _movieService.Delete(Id);
                
                return Ok(_mapper.Map<MovieAndTvShowDTO>(movie));
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }

        [HttpPost]
        public ActionResult<MovieAndTvShowResponseDTO> Insert([FromBody] MovieAndTvShowInsertDTO newMovie)
        {
            try
            {
                var movie = _mapper.Map<MovieAndTvShow>(newMovie);
                var addedMovie = _movieService.Insert(movie);

                return Ok(_mapper.Map<MovieAndTvShowDTO>(addedMovie));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message + '\n' + ex.InnerException);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + '\n' + ex.InnerException);
            }

        }
        
        [HttpPut("{Id}")]
        public ActionResult<MovieAndTvShowResponseDTO> Update(int Id, MovieAndTvShowInsertDTO newMovie)
        {
            try
            {
                var movie = _mapper.Map<MovieAndTvShow>(newMovie);
                var updateMovie = _movieService.Update(Id, movie);

                return Ok(_mapper.Map<MovieAndTvShowDTO>(updateMovie));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message + '\n' + ex.InnerException);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + '\n' + ex.InnerException);
            }

        }

        
    }
}
