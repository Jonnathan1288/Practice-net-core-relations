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
    public class DetailBillService : IDetailBillService
    {
        private readonly IDetailBillRepository _repository;
        public DetailBillService(IDetailBillRepository repository) 
        {
            _repository = repository;   
        }

        public async Task<IEnumerable<DetailsBill>> FindAllAsync() => await _repository.FindAllAsync();

        public async Task<DetailsBill> SaveAsync(DetailsBill d) => await _repository.SaveAsync(d);
    }
}
