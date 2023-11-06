using ProjectPractice.Domain.Entities.Public;

namespace ProjectPractice.Domain.Interfaces.Services.Public
{
    public  interface IUserService
    {
        public Task<IEnumerable<User>> FindAllAsync();
        public Task<User> FindByIdAsync(int id);
        public Task<User> SaveAsync(User u);
        public Task<IEnumerable<User>> SaveAllAsync(IEnumerable<User> data);
    }
}
