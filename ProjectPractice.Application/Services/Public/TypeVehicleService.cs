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
    public class TypeVehicleService : ITypeVehicleService
    {
        private readonly ITypeVehicleRepository _repository;
        public TypeVehicleService(ITypeVehicleRepository repository){
            _repository = repository;
        }
        public async Task<IEnumerable<VehiclesType>> FindAllAsync() => await _repository.FindAllAsync();

        public async Task<VehiclesType> SaveAsync(VehiclesType v) => await _repository.SaveAsync(v);
    }
}
