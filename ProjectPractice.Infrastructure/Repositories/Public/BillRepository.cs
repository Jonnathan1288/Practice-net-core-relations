using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Repositories.Public;
using ProjectPractice.Infrastructure.Repositories.Generic;

namespace ProjectPractice.Infrastructure.Repositories.Public
{
    public class BillRepository : NPRepository<Bill, int> , IBillRepository 
    {
        private readonly BdBillContext _context;
        public BillRepository(BdBillContext context) : base(context)
        { 
            _context = context; 
        }
    }
}
