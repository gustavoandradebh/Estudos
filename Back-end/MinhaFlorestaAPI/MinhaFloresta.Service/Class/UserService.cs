using MinhaFloresta.Domain.Entity;
using MinhaFloresta.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaFloresta.Service.Class
{

    public class UserService
    {
        private readonly IRepository _repository;
        private readonly PlantService _plantService;

        public UserService(IRepository repository, PlantService plantService)
        {
            _repository = repository;
            _plantService = plantService;
        }

        public async Task<List<User>> Get() => await _repository.GetAll<User>();

        public async Task<User> Get(string id) => await _repository.GetById<User>(id);

        public async Task<User> Create(User user)
        {
            await _repository.Add<User>(user);
            return user;
        }

        public async Task Update(string id, User userUpdated)
        {
            await _repository.Update<User>(id, userUpdated);
        }

        public async Task Remove(User userIn)
        {
            await Remove(userIn.Id);
        }

        public async Task Remove(string id)
        {
            await _plantService.RemoveByUser(id);
            await _repository.Remove<User>(id);
        }
    }
}
