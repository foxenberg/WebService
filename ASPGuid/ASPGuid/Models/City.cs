using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPGuid.Models
{
    public class City
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("routes")]
        [BsonRepresentation(BsonType.Array)]
        public IEnumerable<Route> routes { get; set; }
    }
}
