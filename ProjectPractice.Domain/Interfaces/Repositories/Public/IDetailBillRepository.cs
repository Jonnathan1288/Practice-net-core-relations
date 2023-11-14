using EFCommonCRUD.Interfaces;
using ProjectPractice.Domain.Entities.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Domain.Interfaces.Repositories.Public
{
    public interface IDetailBillRepository : INPRepository<DetailsBill, int>
    {
        public Task<List<DetailsBill>> SaveAsyncTran(List<DetailsBill> details);
    }
}
