using FluentValidation;
using FluentValidation.AspNetCore;
using iMedicalApi.Services;
using iMedicalAPI.Middleware;
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
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            /* var authenticationSettings = new AuthenticationSettings();
             Configuration.GetSection("Authentication").Bind(authenticationSettings);
             services.AddAuthentication(option =>
             {
                 option.DefaultAuthenticateScheme = "Bearer";
                 option.DefaultScheme = "Bearer";
                 option.DefaultChallengeScheme = "Bearer";
             }).AddJwtBearer(cfg =>
             {
                 cfg.RequireHttpsMetadata = false;
                 cfg.SaveToken = true;
                 cfg.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidIssuer = authenticationSettings.JwtIssuer,
                     ValidAudience = authenticationSettings.JwtIssuer,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                 };
             });
            */
            services.AddScoped<ErrorHandlingMiddleware>();
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

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseAuthentication();
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
