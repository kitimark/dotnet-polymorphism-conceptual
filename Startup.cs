using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conceptual.Polymorphism.Converters;
using Conceptual.Polymorphism.DataTransferObjects.Person;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Conceptual.Polymorphism
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

            services.AddControllers()
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.Converters.Add(new PersonConverter());
                });
            services.AddSwaggerGen(c =>
            {
                // c.GeneratePolymorphicSchemas(infoType => {
                //     if (infoType == typeof(Person)) 
                //     {
                //         return new Type[] 
                //         {
                //             typeof(Student),
                //             typeof(Employee),
                //         };
                //     }

                //     return Enumerable.Empty<Type>();
                // }, (discriminator) => {
                //     if (discriminator == typeof(Person))
                //     {
                //         return "role";
                //     }
                //     return null;
                // });
                c.UseOneOfForPolymorphism();
                // c.UseAllOfForInheritance();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Conceptual.Polymorphism", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Conceptual.Polymorphism v1"));
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
