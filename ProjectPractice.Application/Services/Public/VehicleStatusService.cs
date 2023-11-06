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
    public class VehicleStatusService : IVehicleStatusService
    {
        private readonly IVehicleStatusRepository _repository;

        public VehicleStatusService(IVehicleStatusRepository repository) { 
            _repository = repository;
        }
        public async Task<IEnumerable<VehicleStatus>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<VehicleStatus> SaveAsync(VehicleStatus p)
        {
            return await _repository.SaveAsync(p);
        }
    }
}
