using ApplicationsLogger.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ApplicationsLogger.Adapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMongoCollection<BsonDocument> _collection;

        public MoviesController(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("sample_mflix");
            _collection = database.GetCollection<BsonDocument>("movies");
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var moviesColletction = _collection.Find(new BsonDocument()).Limit(1).ToList();

            return Ok(moviesColletction);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Movies model)
        {
            
            if (model == null)
            {
                return BadRequest("Movie document cannot be null.");
            }

            try
            {
                BsonDocument movieDocument = model.ToBsonDocument();


                await _collection.InsertOneAsync(movieDocument);
                // Verificar se o documento foi inserido com sucesso

                ObjectId insertedId = movieDocument["_id"].AsObjectId;

                // Retornar uma resposta de sucesso com informações sobre o documento inserido
                return Ok(new { Message = "Movie added successfully.", InsertedId = insertedId.ToString() });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            
        }
       
    }
}
