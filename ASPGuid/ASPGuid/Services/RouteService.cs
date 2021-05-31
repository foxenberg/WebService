using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPGuid.Services
{
    public class RouteService
    {
        private readonly IMongoCollection<Models.Route> _routes;

        public RouteService(Models.IGuidDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _routes = database.GetCollection<Models.Route>(settings.RoutesCollectionName);
        }

        public List<Models.Route> Get() =>
            _routes.Find(route => true).ToList();

        public Models.Route Get(string Id) =>
            _routes.Find<Models.Route>(country => country.Id == Id).FirstOrDefault();

        public Models.Route Create(Models.Route route)
        {
            _routes.InsertOne(route);
            return route;
        }
        public void Update(string Id, Models.Route routeIn) =>
            _routes.ReplaceOne(country => country.Id == Id, routeIn);

        public void Remove(Models.Route routeIn) =>
           _routes.DeleteOne(country => country.Id == routeIn.Id);
        public void Remove(string Id) =>
            _routes.DeleteOne(country => country.Id == Id);
    }
}
