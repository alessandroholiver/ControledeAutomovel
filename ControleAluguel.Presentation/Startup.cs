using AutoMapper;
using ControleAluguel.Application.Mapper;
using ControleAluguel.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAluguel.Presentation
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
            services.AddControllers();
            InjetorDependencias.Registrar(services);

            var mapping = new MapperConfiguration(mc =>
            { mc.AddProfile(new Mapping());
            });
            IMapper mapper = mapping.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Controle de Aluguel de Automóveis",
                        Version = "v1",
                        Description = "Controlar aluguel de carros"

                    });
                c.CustomSchemaIds(x => x.FullName);
                var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
                var applicationName = PlatformServices.Default.Application.ApplicationName;
                var xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");

                //Caso exista arquivo então adiciona-lo
                if (File.Exists(xmlDocumentPath))
                {
                    c.IncludeXmlComments(xmlDocumentPath);
                }
            });
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
            app.UseSwagger();


app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ontrolar aluguel de carros");
    c.RoutePrefix = string.Empty; 
});


        }
    }
}
