using ApplicationsLogger.Domain.Entities;
using ApplicationsLogger.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLogger.Application.Service
{
    public class MoviesService
    {

        private readonly MoviesRepository _moviesRepository;

        public MoviesService(MoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }   

        public void AddMovie(Movies model)
        {
            _moviesRepository.InserMovies(model);

            Console.WriteLine("Adicionar Filme");
        }
    }
}
