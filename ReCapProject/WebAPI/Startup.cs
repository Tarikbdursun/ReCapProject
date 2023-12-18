using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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

namespace WebAPI
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
            //services.AddSingleton<ICarService,CarManager>();
            ////CarManager uses IProductDal on its own CTOR
            //services.AddSingleton<IProductDal,EfProductDal>();

            //services.AddSingleton<IBrandService, BrandManager>();
            ////BrandManager uses IBrandDal on its own CTOR
            //services.AddSingleton<IBrandDal, EfBrandDal>();

            //services.AddSingleton<IColorService, ColorManager>();
            ////ColorManager uses IColorDal on its own CTOR
            //services.AddSingleton<IColorDal, EfColorDal>();

            //services.AddSingleton<ICustomerService, CustomerManager>();
            ////CustomerManager uses ICustomerDal on its own CTOR
            //services.AddSingleton<IColorDal, EfColorDal>();

            //services.AddSingleton<IModelService, ModelManager>();
            ////ModelManager uses IModelDal on its own CTOR
            //services.AddSingleton<IModelDal, EfModelDal>();

            //services.AddSingleton<IRentalService, RentalManager>();
            ////RentalManager uses IRentalDal on its own CTOR
            //services.AddSingleton<IRentalDal, EfRentalDal>();

            //services.AddSingleton<IUserService, UserManager>();
            ////UserManager uses IUserDal on its own CTOR
            //services.AddSingleton<IUserDal, EfUserDal>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
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
