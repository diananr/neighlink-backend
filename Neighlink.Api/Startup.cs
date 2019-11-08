using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Neighlink.Repository;
using Neighlink.Repository.Context;
using Neighlink.Repository.implementation;
using Neighlink.Service;
using Neighlink.Service.implementation;

namespace Neighlink.Api
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
            options.UseSqlServer(Configuration.GetConnectionString("DefaulConnection")));
            
            services.AddTransient<IBillRepository,BillRepository>();
            services.AddTransient<IBillService,BillService>();
            
            services.AddTransient<IBuildingRepository,BuildingRepository>();
            services.AddTransient<IBuildingService,BuildingService>();

            services.AddTransient<ICondominiumRepository,CondominiumRepository>();
            services.AddTransient<ICondominiumService,CondominiumService>();

            services.AddTransient<INewRepository,NewRepository>();
            services.AddTransient<INewService,NewService>();

            services.AddTransient<IOptionRepository,OptionRepository>();
            services.AddTransient<IOptionService,OptionService>();

            services.AddTransient<IPaymentCategoryRepository,PaymentCategoryRepository>();
            services.AddTransient<IPaymentCategoryService,PaymentCategoryService>();

            services.AddTransient<IPlanRepository,PlanRepository>();
            services.AddTransient<IPlanService,PlanService>();

            services.AddTransient<IPollRepository,PollRepository>();
            services.AddTransient<IPollService,PollService>();

            services.AddTransient<IRoleRepository,RoleRepository>();
            services.AddTransient<IRoleService,RoleService>();

           

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
