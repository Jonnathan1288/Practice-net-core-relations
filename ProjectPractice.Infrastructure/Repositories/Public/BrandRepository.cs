using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Repositories.Public;
using ProjectPractice.Infrastructure.Repositories.Generic;


namespace ProjectPractice.Infrastructure.Repositories.Public
{
    public class BrandRepository : NPRepository<Brand, int>, IBrandRepository
    {
        private readonly BdBillContext _context;
        public BrandRepository(BdBillContext context) : base(context) {
            _context = context; 
        }

        public bool  ExistBrandName(string brand_name) 
        {
            return _context.Brands
                .AsNoTracking()
                .AsEnumerable()
            .Any(p => string.Equals(p.BrandName, brand_name.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public bool ExistBrandsName(List<string> brands)
        {
            return false;
        }

        public async Task<List<Brand>> SaveAllAsync(List<Brand> brands)
        {
            await _context.AddRangeAsync(brands);
            await _context.SaveChangesAsync();
            return brands;
        }

        public async Task<List<Brand>> SaveAllTransactional(List<Brand> brands)
        {
            if (brands.Count == 0) return brands;
            using IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                 await _context.Brands.AsNoTracking()
                     .Where(b => b.BrandId == brands.Select(x => x.BrandId).First())
                     .ExecuteDeleteAsync();
                 await _context.AddRangeAsync(brands);
                 await _context.SaveChangesAsync();
                 await transaction.CommitAsync();
            }
            catch {
                throw;
            }
            return brands;
        }
    }
}


/*foreach (var brand in brands)
{
    _context.Brands.Update(brand);
}*/