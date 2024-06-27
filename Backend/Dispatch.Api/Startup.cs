using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dispatch.Api.Services.Basket;
using Dispatch.Api.Services.DispatchEstimation;
using Dispatch.Api.Services.ProductManagement;
using Dispatch.Api.Services.SupplierManagement;
using Dispatch.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dispatch.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private const string corsPolicyName = "AllowAnyOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: corsPolicyName,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .Build();
                    });
            });
            services.AddMvc();
            services.AddSingleton<IDbContext, DbContext>();
            services.AddTransient<IProductManagementService, ProductManagementService>();
            services.AddTransient<ISupplierManagementService, SupplierManagementService>();
            services.AddScoped<IDispatchEstimationService, DispatchEstimationService>();
            services.AddScoped<IBasketService, BasketService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(corsPolicyName);
            app.UseMvc();
        }
    }
}
