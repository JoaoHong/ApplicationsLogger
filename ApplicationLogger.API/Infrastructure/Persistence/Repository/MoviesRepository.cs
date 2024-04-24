using ApplicationsLogger.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLogger.Infrastructure.Persistence.Repository
{
    public class MoviesRepository
    {
        private readonly IMongoCollection<Movies> _movieCollection;

        public MoviesRepository(MongoDbContext dbContext)
        {
            _movieCollection = dbContext.GetCollection<Movies>("movies");
        }

        public void InserMovies(Movies movie)
        {
            _movieCollection.InsertOne(movie);
        }
    }
}
