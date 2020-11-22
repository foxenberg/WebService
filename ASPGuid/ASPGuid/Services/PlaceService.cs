using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPGuid.Services
{
    public class PlaceService
    {

        private readonly IMongoCollection<Models.Place> _places;

        public PlaceService(Models.IGuidDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _places = database.GetCollection<Models.Place>(settings.PlacesCollectionName);

        }

        public List<Models.Place> Get() =>
            _places.Find(place => true).ToList();

        public Models.Place Get(string Id) =>
            _places.Find<Models.Place>(place => place.Id == Id).FirstOrDefault();

        public Models.Place Create(Models.Place place)
        {
            _places.InsertOne(place);
            return place;
        }

        public void Update(string Id, Models.Place placeIn) =>
            _places.ReplaceOne(place => place.Id == Id, placeIn);

        public void Remove(Models.Place placeIn) =>
            _places.DeleteOne(place => place.Id == placeIn.Id);

        public void Remove(string Id) =>
            _places.DeleteOne(place => place.Id == Id);


    }
}
