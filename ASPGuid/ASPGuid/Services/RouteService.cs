using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPGuid.Services
{
    public class RouteService
    {
        private readonly IMongoCollection<Models.Route> _countries;

        public RouteService(Models.IGuidDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _countries = database.GetCollection<Models.Route>(settings.RoutesCollectionName);
        }

        public List<Models.Route> Get() =>
            _countries.Find(country => true).ToList();

        public Models.Route Get(string Id) =>
            _countries.Find<Models.Route>(country => country.Id == Id).FirstOrDefault();

        public Models.Route Create(Models.Route country)
        {
            _countries.InsertOne(country);
            return country;
        }
        public void Update(string Id, Models.Route countryIn) =>
            _countries.ReplaceOne(country => country.Id == Id, countryIn);

        public void Remove(Models.Route countryIn) =>
           _countries.DeleteOne(country => country.Id == countryIn.Id);
        public void Remove(string Id) =>
            _countries.DeleteOne(country => country.Id == Id);
    }
}
