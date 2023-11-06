using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Repositories.Public;
using ProjectPractice.Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Infrastructure.Repositories.Public
{
    public class DetailBillRepository : NPRepository<DetailsBill, int>, IDetailBillRepository
    {
        private readonly BdBillContext _context;
        public DetailBillRepository(BdBillContext context) : base(context) 
        {
            _context = context; 
        }
    }
}
