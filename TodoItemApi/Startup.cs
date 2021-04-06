using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoItemApi.Services;
using Microsoft.Extensions.Logging;
using TodoItemApi.Contexts;
using Microsoft.EntityFrameworkCore;
using TodoItemApi.Services.Repositories;
using FluentValidation.AspNetCore;
using TodoItemApi.Vacunations;
using FluentValidation;
using TodoItemApi.Dtos;

namespace TodoItemApi
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
            services.AddSingleton<IDataSource, ListDataSource>();
           
            services.AddDbContext<CityInfoContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CityDb"));
            });
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IPointsOfInterestRepository, PointOfInterestRepository>();
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<CityDto>, CityValidation>();
            services.AddTransient<IValidator<PointOfInterestDto>, PointOfInterestValidation>();
            services.AddControllers();
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
