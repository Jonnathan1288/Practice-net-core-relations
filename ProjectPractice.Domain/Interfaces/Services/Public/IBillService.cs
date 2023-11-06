using ProjectPractice.Domain.Entities.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Domain.Interfaces.Services.Public
{
    public interface IBillService
    {
        public Task<IEnumerable<Bill>> FindAllAsync();
        public Task<Bill> SaveAsync(Bill b);
    }
}
