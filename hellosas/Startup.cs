using hellosas.Controllers.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hellosas.Data;
using hellosas.Repository;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.OpenApi.Models;

namespace hellosas
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
            //services.AddCors(option =>
            //{
            //    option.AddPolicy("AllowAngularOrigins", builder =>
            //    {
            //        builder.WithOrigins("http://localhost:4200")
            //        .AllowAnyMethod()
            //        .AllowAnyHeader();
            //    });

            //});


            //services.AddControllers();
            ////services.AddDbContext<hellosasContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            //services.AddDbContext<hellosasContext>(options =>
            //      options.UseSqlServer(Configuration.GetConnectionString("hellosasContext")));

           
            services.AddControllers();
            //services.AddDbContext<hellosasContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DBConnection")));


            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

            services.AddDbContext<hellosasContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("hellosasContext")));

            services.AddCors(option =>
            {
                option.AddPolicy("AllowAngularOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost:4200/")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });

            });
            
            services.AddDbContext<hellosasContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddScoped<IstdinfoRepository, stdinfoRepository>();
            services.AddScoped<IcourseRepository, courseRepository>();
            services.AddScoped<IadmissioninfoRepository, admissioninfoRepository>();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Implement Swagger UI",
                    Description = "A simple example to Implement Swagger UI",
                });
            });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

            app.UseHttpsRedirection();
           
            app.UseRouting();

            app.UseCors("AllowAngularOrigins");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
