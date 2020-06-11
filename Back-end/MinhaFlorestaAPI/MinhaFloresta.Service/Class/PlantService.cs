using MinhaFloresta.Domain.Entity;
using MinhaFloresta.Repository.DatabaseSettings;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MinhaFloresta.Service.Class
{
    public class PlantService
    {
        private readonly IMongoCollection<Plant> _plants;

        public PlantService(IDatabaseSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            _plants = database.GetCollection<Plant>(dbSettings.MinhaFlorestaCollectionName);
        }

        public List<Plant> Get() => _plants.Find(plant => true).ToList();

        public Plant Get(string id) => _plants.Find<Plant>(plant => plant.Id == id).FirstOrDefault();

        public Plant Create(Plant plant)
        {
            _plants.InsertOne(plant);
            return plant;
        }

        public void Update(string id, Plant plantUpdated)
        {
            _plants.ReplaceOne(plant => plant.Id == id, plantUpdated);
        }

        public void Remove(Plant plantIn)
        {
            _plants.DeleteOne(plant => plant.Id == plantIn.Id);
        }

        public void Remove(string id)
        {
            _plants.DeleteOne(plant => plant.Id == id);
        }
    }
}
