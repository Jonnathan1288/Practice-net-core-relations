

using EFCommonCRUD.Interfaces;
using EFCommonCRUD.Models;
using Microsoft.EntityFrameworkCore;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Repositories.Public;
using ProjectPractice.Infrastructure.Repositories.Generic;

namespace ProjectPractice.Infrastructure.Repositories.Public
{
    public class ParentRepository : NPRepository<Parent, int>, IParentRepository
    {
        private readonly BdBillContext _context;
        public ParentRepository(BdBillContext context) : base(context){ 
            _context = context;
        }

        public async Task<IPage<Parent>> FindAllPageableAsync(IPageable pageable)
        {
            IQueryable<Parent> query = _context.Parents.AsNoTracking()
                .Where(t => t.ParentStatus == true);

            List<Parent> result = await query
                .OrderBy(t => t.ParentId)
                .Skip(Convert.ToInt32(pageable.GetOffset()))
                .Take(pageable.GetPageSize())
                .ToListAsync();

            return new Page<Parent>(result, pageable, await query.CountAsync());
        }
    }
}
