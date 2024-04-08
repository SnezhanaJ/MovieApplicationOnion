using MovieApplication.Domain.Domain;
using MovieApplication.Repository.Interface;
using MovieApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Service.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _moviesRepository;
        public MovieService(IRepository<Movie> moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public void CreateNewMovie(Movie p)
        {
            _moviesRepository.Insert(p);
        }

        public void DeleteMovie(Guid id)
        {
            var movie = _moviesRepository.Get(id);
            _moviesRepository.Delete(movie);
        }

        public List<Movie> GetAllMovies()
        {
            return _moviesRepository.GetAll().ToList();
        }

        public Movie GetDetailsForMovie(Guid? id)
        {
            return _moviesRepository.Get(id);
        }

        public void UpdateExistingMovie(Movie p)
        {
            _moviesRepository.Update(p);
        }
    }
}
