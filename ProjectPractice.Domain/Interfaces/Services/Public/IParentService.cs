using EFCommonCRUD.Interfaces;
using ProjectPractice.Domain.Entities.Public;

namespace ProjectPractice.Domain.Interfaces.Services.Public
{
    public interface IParentService
    {
        public Task<Parent> SaveAsync(Parent p);
        public IEnumerable<Parent> FindAll();
        public Task<IEnumerable<Parent>> FindAllAsync();
        public Task<Parent> FindByOne(int id);
        public Task<IPage<Parent>> FindAllPageableAsync(IPageable pageable);

        public Task<List<Parent>> SaveAsyncTran(List<Parent> p);
    }
}
