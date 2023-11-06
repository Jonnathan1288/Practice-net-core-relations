using Microsoft.EntityFrameworkCore;
using ProjectPractice.Application.Services.Public;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Helpers.HelperBuilder;
using ProjectPractice.Domain.Helpers.IHelperBuilder;
using ProjectPractice.Domain.Interfaces.Repositories.Public;
using ProjectPractice.Domain.Interfaces.Services.Public;
using ProjectPractice.Infrastructure.Repositories.Public;

namespace ProjectPractice.API
{
    public static class DependencyInjectionSystem
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //ADD REPOSITORYS
            services.AddScoped<IParentRepository, ParentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleStatusRepository, VehicleStatusRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<ITypeVehicleRepository, TypeVehicleRepository>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IDetailBillRepository, DetailBillRepository>();

            //ADD SERVICES
            services.AddScoped<IParentService, ParentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehicleStatusService, VehicleStatusService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<ITypeVehicleService, TypeVehicleService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IDetailBillService, DetailBillService>();


            //services.AddScoped<IFilterBuilder<string>, FilterBuilder<string>>();
            services.AddScoped(typeof(IFilterBuilder<>), typeof(FilterBuilder<>));


            //GET CONNECTION
            services.AddDbContext<BdBillContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"));

            });

            return services;
        }
    }
}
