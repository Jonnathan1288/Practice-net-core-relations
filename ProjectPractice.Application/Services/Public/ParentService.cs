using EFCommonCRUD.Interfaces;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Repositories.Public;
using ProjectPractice.Domain.Interfaces.Services.Public;

namespace ProjectPractice.Application.Services.Public
{
    public class ParentService: IParentService
    {
        private readonly IParentRepository _repository;
        public ParentService(IParentRepository repository) {
            _repository = repository;
        }

        public IEnumerable<Parent> FindAll()
        {
            return _repository.FindAll();
        }

        public async Task<IEnumerable<Parent>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<IPage<Parent>> FindAllPageableAsync(IPageable pageable)
        {
            return await _repository.FindAllPageableAsync(pageable);
        }

        public async Task<Parent?> FindByOne(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<Parent> SaveAsync(Parent p)
        {
            return await _repository.SaveAsync(p);
        }
    }
}
