using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPGuid.Models
{
    public class Route
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("country")]
        public string Country { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("image")]
        public string Image { get; set; }
        [BsonElement("rating")]
        public string Rating { get; set; }
        [BsonElement("topic")]
        public string Topic { get; set; }
        [BsonElement("placesForRoute")]
        public IEnumerable<PlacesForRoute> PlacesForRoute { get; set; }

        
    }
}
