using MinhaFloresta.Domain.Entity;
using MinhaFloresta.Repository.DatabaseSettings;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MinhaFloresta.Service.Class
{

    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        private readonly PlantService _plantService;

        public UserService(IDatabaseSettings dbSettings, PlantService plantService)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            _users = database.GetCollection<User>(dbSettings.UsersCollectionName);
            _plantService = plantService;
        }

        public List<User> Get() => _users.Find(user => true).ToList();

        public User Get(string id) => _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userUpdated)
        {
            _users.ReplaceOne(user => user.Id == id, userUpdated);
        }

        public void Remove(User userIn)
        {
            _plantService.Remove(userIn);
            _users.DeleteOne(user => user.Id == userIn.Id);
        }

        public void Remove(string id)
        {
            _plantService.Remove(new User { Id = id } );
            _users.DeleteOne(user => user.Id == id);
        }
    }
}
