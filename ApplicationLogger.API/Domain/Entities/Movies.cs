using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLogger.Domain.Entities
{
    public class Movies
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id {  get; set; }    
        public string plot { get; set; }
        [BsonElement("genres")]
        public List<string> genres { get; set; }
        public int runtime { get; set; }
        [BsonElement("cast")]
        public List<string> cast {  get; set; }
        public string poster { get; set; }
        public string title { get; set; }
        public string fullplot { get; set; }
        [BsonElement("languages")]
        public List<string> languages { get; set; }
        public DateTime released { get; set; }
        [BsonElement("directors")]
        public List<string> directors {  get; set; }
        public string rated { get; set; }
        public MovieAwards awards { get; set; }
        public string lastupdated { get; set; }
        public int year { get; set; }
        public MovieIMDB imdb { get; set; }
        [BsonElement("countries")]
        public List<string> countries { get; set; }
        public string type { get; set; }
        //public object[] tomatoes { get; set; }
        public int num_mflix_comments { get; set; }
    }

    public class MovieAwards
    {
        [BsonElement("wins")]
        public int wins { get; set; }

        [BsonElement("nominations")]
        public int nominations { get; set; }

        [BsonElement("text")]
        public string text { get; set; }
    }

    public class MovieIMDB
    {
        [BsonElement("rating")]
        public double rating { get; set; }

        [BsonElement("votes")]
        public int votes { get; set; }

        [BsonElement("id")]
        public string id { get; set; }
    }


}
