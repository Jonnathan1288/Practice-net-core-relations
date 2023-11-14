using ProjectPractice.Domain.Entities.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Domain.Interfaces.Services.Public
{
    public interface IBrandService
    {
        public Task<IEnumerable<Brand>> FindAllAsync();
        public Task<Brand> SaveAsync(Brand b);
        public Task<List<Brand>> SaveAllTransactional(List<Brand> brands);
        public bool ExistBrandName(string brand_name);

        public Task<List<Brand>> SaveAllAsync(List<Brand> brands);
    }
}
