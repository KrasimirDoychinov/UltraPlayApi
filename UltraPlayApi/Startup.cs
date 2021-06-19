using Hangfire;
using Hangfire.SqlServer;
using Hangfire.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UltraPlayApi.Data;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.AutoMapper;
using UltraPlayApi.Services.Implementations;
using UltraPlayApi.Services.Interfaces;
using UltraPlayApi.Web.Seeder;
using UltraPlayApi.Web.ViewModels.Sports;
using static UltraPlayApi.Data.Common.GlobalConstants;

namespace UltraPlayApi.Web
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
            services.AddTransient(typeof(HttpClient));
            services.AddTransient(typeof(HttpResponseMessage));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHangfireServices hangfireServices)
        {
            AutoMapperConfig.RegisterMappings(typeof(SportDto).GetTypeInfo().Assembly);
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

            RecurringJob.AddOrUpdate(() => hangfireServices.CallApi(), Cron.Minutely);
            //using (var connection = JobStorage.Current.GetConnection())
            //{
            //    foreach (var recurringJob in StorageConnectionExtensions.GetRecurringJobs(connection))
            //    {
            //        RecurringJob.RemoveIfExists(recurringJob.Id);
            //    }
            //}


        }

    }
}
