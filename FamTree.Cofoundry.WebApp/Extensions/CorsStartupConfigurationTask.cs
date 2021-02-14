using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using Cofoundry.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Cofoundry.Web;

namespace FamTree.Cofoundry.WebApp
{
    public class CorsStartupConfigurationTask : IStartupConfigurationTask
        , IRunAfterStartupConfigurationTask, IRunBeforeStartupConfigurationTask
    {
        public int Ordering
        {
            get { return (int)StartupTaskOrdering.Early; }
        }

        public ICollection<Type> RunAfter => new Type[] { typeof(UseRoutingStartupConfigurationTask) };

        public ICollection<Type> RunBefore => new Type[] { typeof(AuthStartupConfigurationTask) };

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("AllowAll");
        }
    }
}