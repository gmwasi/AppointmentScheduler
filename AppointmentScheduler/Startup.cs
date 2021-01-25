using System;
using System.Text;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using AppointmentScheduler.Core.Service;
using AppointmentScheduler.Persistence;
using AppointmentScheduler.Persistence.Repository;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace AppointmentScheduler
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string[] clients = new[] { Configuration["JWT:ValidAudience"] };
            // configure CORS
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(clients)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            //configure EF Core Postgres SQL
            services.AddDbContext<AppointmentsContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("defaultConnection")));

            // For Identity
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppointmentsContext>()
                .AddDefaultTokenProviders();

            // Adding Authentication
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })

                // Adding Jwt Bearer  
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration["JWT:ValidAudience"],
                        ValidIssuer = Configuration["JWT:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                    };
                });

            // Add Hangfire services.
            services.AddHangfire(config =>
                config.UsePostgreSqlStorage(Configuration.GetConnectionString("defaultConnection")));

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<IImmunizationRepository, ImmunizationRepository>();
            services.AddScoped<ILookupRepository, LookupRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IChildRepository, ChildRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IChildService, ChildService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddControllers();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppointmentsContext appointmentsContext)
        {
            appointmentsContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });

            app.UseHangfireDashboard();
            RecurringJob.AddOrUpdate<IAppointmentService>(x => x.MarkMissedAppointments(), Cron.Daily);
        }
    }
}
