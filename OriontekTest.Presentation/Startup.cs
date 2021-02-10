using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OriontekTest.DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OriontekTest.BusinessLogic.Contracts;
using OriontekTest.BusinessLogic;

namespace OriontekTest.Presentation
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
            services.AddCors(builder => 
            {
                builder.AddPolicy("MyCors", policy => 
                {
                    policy.WithOrigins("https://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OriontekTest.Presentation", Version = "v1" });
            });
            
            services.AddDbContext<ClientsDbContext>(builder => 
            builder.UseSqlServer(Configuration.GetConnectionString("DbConnection")
            ));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OriontekTest.Presentation v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyCors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
