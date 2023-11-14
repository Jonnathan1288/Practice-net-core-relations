using EFCommonCRUD.Interfaces;
using ProjectPractice.Domain.Entities.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Domain.Interfaces.Repositories.Public
{
    public interface IBrandRepository : INPRepository<Brand, int>
    {
        public Task<List<Brand>> SaveAllTransactional(List<Brand> brands);

        public bool ExistBrandName(string brand_name);

        public bool ExistBrandsName(List<string> brands);

        public Task<List<Brand>> SaveAllAsync(List<Brand> brands);
    }
}
