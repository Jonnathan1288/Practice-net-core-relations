using ProjectPractice.Domain.Entities.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Domain.Interfaces.Services.Public
{
    public interface ITypeVehicleService
    {
        public Task<IEnumerable<VehiclesType>> FindAllAsync();
        public Task<VehiclesType> SaveAsync(VehiclesType v);
    }
}
