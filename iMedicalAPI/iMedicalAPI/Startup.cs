using FluentValidation;
using FluentValidation.AspNetCore;
using iMedicalApi.Services;
using iMedicalAPI.Models;
using iMedicalAPI.Models.RegisterUserModels;
using iMedicalAPI.Models.Validators;
using iMedicalAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<iMedical_angContext>();
            services.AddControllers().AddFluentValidation();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<ISpecializationService, SpecializationService>();
            services.AddScoped<IVisitTypeService, VisitTypeService>();
            services.AddScoped<IContractTypeService, ContractTypeService>();
            services.AddScoped<ITenureTypeService, TenureTypeService>();
            services.AddScoped<IJobTypeService, JobTypeService>();
            services.AddScoped<IPriceListService, PriceListService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPasswordHasher<Patient>, PasswordHasher<Patient>>();
            services.AddScoped<IPasswordHasher<Employee>, PasswordHasher<Employee>>();
            services.AddScoped<IValidator<RegisterPatientDto>, RegisterUserDtoValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
