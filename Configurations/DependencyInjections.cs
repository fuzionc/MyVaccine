using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Repositories.Implementations;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;

namespace MyVaccine.WebApi.Configurations
{
    public static class DependencyInjections
    {
        public static IServiceCollection SetDependencyInjection(this IServiceCollection services)
        {
            #region Repositories Injection
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBaseRepository<Dependent>, BaseRepository<Dependent>>();
            services.AddScoped<IBaseRepository<Allergy>, BaseRepository<Allergy>>();
            services.AddScoped<IBaseRepository<FamilyGroup>, BaseRepository<FamilyGroup>>();
            services.AddScoped<IBaseRepository<Vaccine>, BaseRepository<Vaccine>>();
            services.AddScoped<IBaseRepository<VaccineCategory>, BaseRepository<VaccineCategory>>();
            services.AddScoped<IBaseRepository<VaccineRecord>, BaseRepository<VaccineRecord>>();
            #endregion

            #region Services Injection

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDependentService, DependentService>();
            services.AddScoped<IAllergyServices, AllergyServices>();
            services.AddScoped<IFamilyGroupServices, FamilyGroupServices>();
            services.AddScoped<IVaccineServices, VaccineServices>();
            services.AddScoped<IVaccineCategoryServices, VaccineCategoryServices>();
            services.AddScoped<IVaccineRecordServices, VaccineRecordServices>();
            #endregion



            return services;
        }
    }
}
