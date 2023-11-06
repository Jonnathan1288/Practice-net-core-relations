using ProjectPractice.Domain.Entities.Public;

namespace ProjectPractice.Domain.Interfaces.Services.Public
{
    public interface IDetailBillService
    {
        public Task<IEnumerable<DetailsBill>> FindAllAsync();

        public Task<DetailsBill> SaveAsync(DetailsBill d);
    }
}
