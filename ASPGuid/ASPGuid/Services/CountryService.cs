using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPGuid.Services
{
    public class CountryService
    {
        private readonly IMongoCollection<Models.Country> _countries;

        public CountryService(Models.IGuidDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _countries = database.GetCollection<Models.Country>(settings.CountriesCollectionName);
        }

        public List<Models.Country> Get() =>
            _countries.Find(country => true).ToList();

        public Models.Country Get(string Id) =>
            _countries.Find<Models.Country>(country => country.Id == Id).FirstOrDefault();

        public Models.Country Create(Models.Country country)
        {
            _countries.InsertOne(country);
            return country;
        }
        public void Update(string Id, Models.Country countryIn) =>
            _countries.ReplaceOne(country => country.Id == Id, countryIn);

        public void Remove(Models.Country countryIn) =>
           _countries.DeleteOne(country => country.Id == countryIn.Id);
        public void Remove(string Id) =>
            _countries.DeleteOne(country => country.Id == Id);
    }
}
