using EFCommonCRUD.Interfaces;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Parametrized;
using ProjectPractice.Domain.Reducers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Domain.Interfaces.Services.Public
{
    public interface IVehicleService
    {
        public Task<IEnumerable<Vehicle>> FindALlAsync();
        public Task<Vehicle> FindByIdAsync(int id);
        public Task<Vehicle> SaveAsync(Vehicle v);
        public Task<IPage<Vehicle>> FindAllPageableAsync(IPageable pageable);
        public Task<Vehicle> UpdateAsync(Vehicle v);
        public Task<IEnumerable<Vehicle>> FindByBrand(string brand_name);
        public Task<IEnumerable<VehicleInformation>> FindAllByFilter();
        public List<Vehicle> FindAllFromSql(string brand_name);

        public List<Vehicle> FindAllWithMultipleParams(VehicleParams? vehicleParams);
    }
}
