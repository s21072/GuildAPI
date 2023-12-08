using GuildAPI.Models;
using GuildAPI.Services;
using GuildAPI.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI
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
            //Services dodajemy ni¿ej
            services.AddScoped<IAdventurerDBService, AdventurerDBService>();
            services.AddScoped<ICommissionDBService, CommissionDBService>();
            services.AddScoped<IGuildWorkerDBService, GuildWorkerDBService>();
            services.AddScoped<ITeamDBService, TeamDBService>();
            services.AddScoped<IAddressDBService, AddressDBService>();
            services.AddScoped<IPersonDBService, PersonDBService>();
            services.AddScoped<ICEODBService, CEODBService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GuildAPI", Version = "v1" });
            });
            services.AddDbContext<MyDBContext>();
            services.AddCors(o => o.AddPolicy("LowCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GuildAPI v1"));
            }

            app.UseRouting();
            app.UseCors("LowCorsPolicy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
