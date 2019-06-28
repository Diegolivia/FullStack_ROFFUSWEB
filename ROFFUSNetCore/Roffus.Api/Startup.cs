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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Roffus.Domain;
using Roffus.Repository.Context;
using Roffus.Repository; 
using Roffus.Repository.Implementations;
using Roffus.Service;
using Roffus.Service.Implementations;
using Swashbuckle.AspNetCore.Swagger;

namespace Roffus.Api
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
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddTransient<IRepositorioCategoria, RepositorioCategoria>();
            services.AddTransient<IRepositorioListaMuebles, RepositorioListaMuebles>();
            services.AddTransient<IRepositorioMueble, RepositorioMueble>();
            services.AddTransient<IRepositorioPaquete, RepositorioPaquete>();
            services.AddTransient<IRepositorioPlantilla, RepositorioPlantilla>();
            services.AddTransient<IRepositorioTiendaVirtual, RepositorioTiendaVirtual>();   
            services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();       
            services.AddTransient<IRepositorioSubCategoria, RepositorioSubCategoria>();


            services.AddTransient<IServicioCategoria, ServicioCategoria>();
            services.AddTransient<IServicioListaMuebles, ServicioListaMuebles>();
            services.AddTransient<IServicioMueble, ServicioMueble>();
            services.AddTransient<IServicioPaquete, ServicioPaquete>();
            services.AddTransient<IServicioPlantilla, ServicioPlantilla>();
            services.AddTransient<IServicioTiendaVirtual, ServicioTiendaVirtual>();   
            services.AddTransient<IServicioUsuario, ServicioUsuario>();
            services.AddTransient<IServicioSubcategoria, ServicioSubcategoria>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        
             services.AddSwaggerGen(swagger =>
            {
                var contact = new Contact() { Name = SwaggerConfiguration.ContactName, Url = SwaggerConfiguration.ContactUrl };
                swagger.SwaggerDoc(SwaggerConfiguration.DocNameV1,
                                    new Info
                                    {
                                        Title = SwaggerConfiguration.DocInfoTitle,
                                        Version = SwaggerConfiguration.DocInfoVersion,
                                        Description = SwaggerConfiguration.DocInfoDescription,
                                        Contact = contact
                                    }
                                    );
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Todos",
                builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            });
        
        }

        //https://localhost:5001/swagger/index.html
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("Todos");
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
