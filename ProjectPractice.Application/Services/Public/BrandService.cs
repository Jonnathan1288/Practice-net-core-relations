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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;

        public BrandService(IBrandRepository repository) { 
            _repository = repository;
        }
        public async Task<IEnumerable<Brand>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Brand> SaveAsync(Brand b)
        {
            return await _repository.SaveAsync(b);
        }
    }
}
