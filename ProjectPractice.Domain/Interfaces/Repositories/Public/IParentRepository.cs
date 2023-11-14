using EFCommonCRUD.Interfaces;
using ProjectPractice.Domain.Entities.Public;

namespace ProjectPractice.Domain.Interfaces.Repositories.Public
{
    public interface IParentRepository : INPRepository<Parent, int>
    {
        public Task<IPage<Parent>> FindAllPageableAsync(IPageable pageable);
        public Task<List<Parent>> SaveAsyncTran(List<Parent> p);

    }
}
