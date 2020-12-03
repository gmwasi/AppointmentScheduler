using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using AppointmentScheduler.Core.Service;
using AppointmentScheduler.Persistence;
using AppointmentScheduler.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AppointmentScheduler
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
            //configure EF Core sql server
            var connectionString = Configuration["ConnectionStrings:defaultConnection"];
            services.AddDbContext<AppointmentsContext>(
                o =>
                {
                    o.UseSqlServer(connectionString,
                        x => x.MigrationsAssembly(typeof(AppointmentsContext).GetTypeInfo().Assembly.GetName()
                            .Name));
                }
            );

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<IImmunizationRepository, ImmunizationRepository>();
            services.AddScoped<ILookupRepository, LookupRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChildRepository, ChildRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IChildService, ChildService>();
            services.AddControllers();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
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
