using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Repositories.Public;
using ProjectPractice.Domain.Interfaces.Services.Public;

namespace ProjectPractice.Application.Services.Public
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository) {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }


        public async Task<User?> FindByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<User>> SaveAllAsync(IEnumerable<User> data)
        {
            return await _repository.SaveAllAsync(data);
        }

        public async Task<User> SaveAsync(User u)
        {
            return await _repository.SaveAsync(u);
        }
    }
}
