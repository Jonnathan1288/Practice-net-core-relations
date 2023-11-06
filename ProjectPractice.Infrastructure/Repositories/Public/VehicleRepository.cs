using EFCommonCRUD.Interfaces;
using EFCommonCRUD.Models;
using Microsoft.EntityFrameworkCore;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Helpers.IHelperBuilder;
using ProjectPractice.Domain.Interfaces.Repositories.Public;
using ProjectPractice.Domain.Parametrized;
using ProjectPractice.Domain.Reducers;
using ProjectPractice.Infrastructure.Repositories.Generic;
using System.Text;

namespace ProjectPractice.Infrastructure.Repositories.Public
{
    public class VehicleRepository: NPRepository<Vehicle, int>, IVehicleRepository
    {
        private readonly BdBillContext _context;
        private readonly IFilterBuilder<string> _builderStr;
        private readonly IFilterBuilder<int> _builderInt;
        public VehicleRepository(BdBillContext context, IFilterBuilder<string> builder, IFilterBuilder<int> builderInt) : base (context) { 
            _context = context;
            _builderStr = builder;
            _builderInt = builderInt;
        }

        public async Task<IEnumerable<VehicleInformation>> FindAllByFilter()
        {
            var result = await _context.Vehicles
                .AsNoTracking()
                .Select(v => new VehicleInformation
                {
                    VehiPlate = v.VehiPlate,
                    //UserUsername = v.User!.UserUsername,
                    //BrandName = v.Brand.BrandName!,
                    VsName = v.Vs!.VsName

                }).ToListAsync();
            return result;
        }

        public List<Vehicle> FindAllFromSql(string brand_name)
        {
            var sql = @"select v.* " +
                "from vehicles v INNER JOIN brands b ON b.brand_id = v.brand_id where b.brand_name = {0}";
            return _context.Vehicles
                .FromSqlRaw(sql, brand_name).ToList();
        }

        public async Task<IPage<Vehicle>> FindAllPageableAsync(IPageable pageable)
        {
            IQueryable<Vehicle> query = _context.Vehicles.AsNoTracking();
            List<Vehicle> data = await query
                .OrderBy(t => t.VehiId)
                .Skip(Convert.ToInt32(pageable.GetOffset()))
                .Take(pageable.GetPageSize()).ToListAsync();
            return new Page<Vehicle>(data, pageable, await query.CountAsync());
        }

        public List<Vehicle> FindAllWithMultipleParams(VehicleParams? vehicleParams)
        {
            string? where = GetWhere(vehicleParams);
            string sql = "SELECT v.*" +
                "FROM vehicles v "+
                "INNER JOIN users u "+
                "ON u.user_id = v.user_id "+
                "INNER JOIN brands b "+
                "ON v.brand_id = b.brand_id "+
                $"{(where != null && where.Length > 2 ? " WHERE "+where+" ":" ")}";

            List<Vehicle> data = _context.Vehicles.FromSqlRaw(sql).ToList();
            return data;
        }

        public async Task<IEnumerable<Vehicle>> FindByBrand(string brand_name)
        {
            var result = await _context.Vehicles.AsNoTracking()
                .Where(t => t.Model.Brand!.BrandName!.Equals(brand_name))
                .OrderBy(t => t.VehiId)
                .ToListAsync();
            return result;
        }

        // private static string? GetWhere(VehicleParams? vehicleParams) 
        private string? GetWhere(VehicleParams? vehicleParams)
        {
            if (vehicleParams == null) return null;
            StringBuilder data = new();
           
            data.Append($"{_builderStr.BuildeFilter(data.Length, "b.brand_name", vehicleParams.BrandName)}");
            data.Append($"{_builderStr.BuildeFilter(data.Length, "v.vehi_plate", vehicleParams.VehiPlate)}");
            data.Append($"{_builderInt.BuildeFilter(data.Length, "u.user_id", vehicleParams.UserId)}");
            
            return data.ToString();
        }
    }
}

/* data.Append(data.Length > 5 ? " AND " : "");
 data.Append("b.brand_name IN (");
 data.Append(string.Join(",", vehicleParams.BrandName.Select(c => $"'{c}'")));
 data.Append(')');*/

//data.Append($"{(data.Length > 5 ? " AND " : "")}b.brand_name IN ('{string.Join("','", vehicleParams.BrandName)}')");
