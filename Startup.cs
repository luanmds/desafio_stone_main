using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuncionarioApi.Data;
using FuncionarioApi.Data.Repositories;
using FuncionarioApi.Models.ContraCheque;
using FuncionarioApi.Models.Funcionarios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace FuncionarioApi
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
            services.AddDbContext<FuncionarioDbContext>(options => options.UseMySql(
                Configuration.GetConnectionString("Default"), new MySqlServerVersion(new Version(8, 0))));
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                        options.SerializerSettings.Converters.Add(new StringEnumConverter())); ;

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "Funcionario API", Version = "v1" });
            });
            services.AddSwaggerGenNewtonsoftSupport();

            services.AddScoped<FuncionarioService>();
            services.AddScoped<ContraChequeService>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/Error");
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
