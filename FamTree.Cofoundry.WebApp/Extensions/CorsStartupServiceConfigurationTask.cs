using Cofoundry.Web;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamTree.Cofoundry.WebApp.Extensions
{
    public class CorsStartupServiceConfigurationTask : IStartupServiceConfigurationTask
    {
        public void ConfigureServices(IMvcBuilder mvcBuilder)
        {
            mvcBuilder.Services.AddCors(
        options => {
            options.AddPolicy(
                "AllowAll", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod().AllowAnyHeader();

                });
        });
        }

}
}
