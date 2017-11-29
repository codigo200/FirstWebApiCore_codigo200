using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Web.Core.Data.Repository;
using Web.Core.EntityFramework;
using Web.Core.Utils.HttpContext;
using FirstWebApiCore.App_Start;
using Web.Core.EntityFramework.DbContext;
using Web.Core.EntityFramework.UnitOfWork;
using FirstWebApiCore.Data.Contract;
using FirstWebApiCore.Data;
using Microsoft.AspNetCore.Http;

namespace FirstWebApiCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AutoMapperConfiguration.LoadProfiles();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IHttpCurrentContext, HttpCurrentContext>();
            services.AddTransient<IDbContextFactory, DbContextFactory>();
            services.AddTransient<IEFUnitOfWork, EFUnitOfWork>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<CustomActionFilter>();
            services.AddMvc();

            services.AddCors(opts =>
            {
                opts.AddPolicy("allow_all", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware<RequestMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("allow_all");
            app.UseMvc();
        }
    }
}
