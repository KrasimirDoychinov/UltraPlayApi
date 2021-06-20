using Hangfire;
using Hangfire.SqlServer;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System;
using System.Net.Http;
using System.Reflection;

using UltraPlayApi.Data;
using UltraPlayApi.Services.AutoMapper;
using UltraPlayApi.Services.Implementations;
using UltraPlayApi.Services.Interfaces;
using UltraPlayApi.Web.ViewModels.Events;

namespace UltraPlayApi.Web
{

    // TODO
    // Add try catch
    // Ask about the 24hour endpoint
    // Refactor code
    // Check for errors, readability, reusability and etc.
    // Write some comments
    // Write some tests
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddHangfire(configuration => configuration
               .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
               .UseSimpleAssemblyNameTypeSerializer()
               .UseRecommendedSerializerSettings()
               .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
               {
                   CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                   SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                   QueuePollInterval = TimeSpan.Zero,
                   UseRecommendedIsolationLevel = true,
                   DisableGlobalLocks = true
               }));

            services.AddHangfireServer();

            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UltraPlayApi", Version = "v1" });
            });

            services.AddTransient<IXmlServices, XmlServices>();
            services.AddTransient<IHttpServices, HttpServices>();
            services.AddTransient<ISportServices, SportServices>();
            services.AddTransient<IEventServices, EventServices>();
            services.AddTransient<IMatchServices, MatchServices>();
            services.AddTransient<IOddsServices, OddsServices>();
            services.AddTransient<IBetServices, BetServices>();
            services.AddTransient<IHangfireServices, HangfireServices>();
            services.AddTransient(typeof(BetUpdateMessageServices));
            services.AddTransient(typeof(MatchUpdateMessageServices));
            services.AddTransient(typeof(OddUpdateMessageServices));
            services.AddTransient(typeof(HttpClient));
            services.AddTransient(typeof(HttpResponseMessage));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHangfireServices hangfireServices)
        {
            AutoMapperConfig.RegisterMappings(typeof(EventDto).GetTypeInfo().Assembly);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UltraPlayApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseHangfireServer();
            app.UseHangfireDashboard();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });

            // This adds or updates the the job that handles the calling of the update api.
            RecurringJob.AddOrUpdate(() => hangfireServices.CallApi(), Cron.Minutely);

            // Use this to remove all recurring jobs.
            //DataSeeder.RemoveAllRecurringJobs();


        }
    }
}

