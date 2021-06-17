using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPGuid.Models
{
    public class Place
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("address")]
        public string Address { get; set; }
        [BsonElement("reviews")]
        public string Reviews { get; set; }
        [BsonElement("photo")]
        public string Photo { get; set; }
        [BsonElement("rating")]
        public double Rating { get; set; }
        [BsonElement("avgCost")]
        public string AvgCost { get; set; }
        [BsonElement("country")]
        public string Country { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("latitude")]
        public double Latitude { get; set; }
        [BsonElement("longitude")]
        public double Longitude { get; set; }
    }
}
