using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Repositories.Public;
using ProjectPractice.Domain.Interfaces.Services.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Application.Services.Public
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _repository;
        public BillService(IBillRepository repository) 
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Bill>> FindAllAsync() => await _repository.FindAllAsync();

        public async Task<Bill> SaveAsync(Bill b) => await _repository.SaveAsync(b);
    }
}
