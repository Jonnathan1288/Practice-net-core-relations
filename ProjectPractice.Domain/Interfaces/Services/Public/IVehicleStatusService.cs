using ProjectPractice.Domain.Entities.Public;

namespace ProjectPractice.Domain.Interfaces.Services.Public
{
    public interface IVehicleStatusService
    {
        public Task<VehicleStatus> SaveAsync(VehicleStatus p);
        public Task<IEnumerable<VehicleStatus>> FindAllAsync();
    }
}
