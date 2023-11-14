using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Enums;
using ProjectPractice.Domain.Exceptions.BadRequest;
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

        public bool ExistBrandName(string brand_name)
        {
            if(string.IsNullOrEmpty(brand_name)) throw new RequiredFieldException(ExceptionEnum.InvalidName);
            return _repository.ExistBrandName(brand_name);
        }

        public async Task<IEnumerable<Brand>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<List<Brand>> SaveAllAsync(List<Brand> brands)
        {
            return await _repository.SaveAllAsync(brands);
        }

        public async Task<List<Brand>> SaveAllTransactional(List<Brand> brands)
        {
            return await _repository.SaveAllTransactional(brands);
        }

        public async Task<Brand> SaveAsync(Brand b)
        {
            ValidateData(b);
            return await _repository.SaveAsync(b);
        }

        public void ValidateData(Brand b) 
        {
            if (string.IsNullOrEmpty(b.BrandName)) throw new RequiredFieldException(ExceptionEnum.ReuieredBrandName); 
        }
    }
}
