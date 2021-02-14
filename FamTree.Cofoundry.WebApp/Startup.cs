using Cofoundry.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FamTree.Cofoundry.Domain
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Register Cofoundry with the DI container. Must be run after AddMvc
            services
                .AddControllersWithViews()
                .AddCofoundry(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {  
            // Register Cofoundry into the pipeline. As part of this process it also initializes 
            // the MVC middleware and runs additional startup tasks.
            app.UseCofoundry();

        }

   
    }
}
