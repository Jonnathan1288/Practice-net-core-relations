using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Repositories.Public;
using ProjectPractice.Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<List<DetailsBill>> SaveAsyncTran(List<DetailsBill> details)
        {
           /* if (details.Count == 0) return details;
            using IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.DetailsBills.AsNoTracking()
                    .Where(t => t.BillNumber == details.Select(t => t.BillNumber).First())
                    .ExecuteDeleteAsync();
            }
            catch
            {
                throw;
            }*/
            return details;
        }
    }
}
