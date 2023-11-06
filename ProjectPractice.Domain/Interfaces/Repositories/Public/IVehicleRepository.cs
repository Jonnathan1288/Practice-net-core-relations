using EFCommonCRUD.Interfaces;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Parametrized;
using ProjectPractice.Domain.Reducers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Domain.Interfaces.Repositories.Public
{
    public interface IVehicleRepository: INPRepository<Vehicle, int>
    {
        public Task<IPage<Vehicle>> FindAllPageableAsync(IPageable pageable);
        public Task<IEnumerable<Vehicle>> FindByBrand(string brand_name);
        public Task<IEnumerable<VehicleInformation>> FindAllByFilter();
        public List<Vehicle> FindAllFromSql(string brand_name);

        public List<Vehicle> FindAllWithMultipleParams(VehicleParams? vehicleParams);
    }
}
