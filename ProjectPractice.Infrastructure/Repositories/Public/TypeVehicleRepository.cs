using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Enums;
using ProjectPractice.Domain.Exceptions.BadRequest;
using ProjectPractice.Domain.Interfaces.Repositories.Public;
using ProjectPractice.Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Infrastructure.Repositories.Public
{
    public class TypeVehicleRepository : NPRepository<VehiclesType, int>, ITypeVehicleRepository
    {
        private readonly BdBillContext _context;
        public TypeVehicleRepository(BdBillContext context) : base (context) 
        {
            _context = context;
        }

        public VehiclesType FindByNameTypeVehicle(string name)
        {
            VehiclesType finded = _context.VehiclesTypes.AsNoTracking().FirstOrDefault(v => v.VehiTypeName.Equals(name))
                   ?? throw new BadRequestException(ExceptionEnum.NotFound);
            return finded;
        }
    }
}
