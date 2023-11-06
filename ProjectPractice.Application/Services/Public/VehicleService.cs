using EFCommonCRUD.Interfaces;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Repositories.Public;
using ProjectPractice.Domain.Interfaces.Services.Public;
using ProjectPractice.Domain.Parametrized;
using ProjectPractice.Domain.Reducers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Application.Services.Public
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository) {
            _repository = repository;
        }
        public async Task<IEnumerable<Vehicle>> FindALlAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<IEnumerable<VehicleInformation>> FindAllByFilter()
        {
            return await _repository.FindAllByFilter();
        }

        public List<Vehicle> FindAllFromSql(string brand_name)
        {
            return _repository.FindAllFromSql(brand_name);
        }

        public async Task<IPage<Vehicle>> FindAllPageableAsync(IPageable pageable)
        {
            return await _repository.FindAllPageableAsync(pageable);
        }

        public List<Vehicle> FindAllWithMultipleParams(VehicleParams? vehicleParams)
        {
            return _repository.FindAllWithMultipleParams(vehicleParams);
        }

        public async Task<IEnumerable<Vehicle>> FindByBrand(string brand_name)
        {
            return await _repository.FindByBrand(brand_name);
        }

        public async Task<Vehicle?> FindByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<Vehicle> SaveAsync(Vehicle v)
        {
            return await _repository.SaveAsync(v);
        }

        public async Task<Vehicle> UpdateAsync(Vehicle v)
        {
            return await _repository.UpdateAsync(v);
        }
    }
}
