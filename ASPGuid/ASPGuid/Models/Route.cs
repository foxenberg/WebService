using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPGuid.Models
{
    public class Route
    {
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
