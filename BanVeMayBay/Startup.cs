using BanVeMayBay.DataContexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(BanVeMayBay.Startup))]
namespace BanVeMayBay
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.CreatePerOwinContext<AirticketDataContext>(() => new AirticketDataContext());
            app.CreatePerOwinContext<UserManager<IdentityUser>>(CreateManager);

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/oauth/token"),
                Provider = new MyOAuthAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                AllowInsecureHttp = true,
            });

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private static UserManager<IdentityUser> CreateManager(IdentityFactoryOptions<UserManager<IdentityUser>> options, IOwinContext context)
        {
            var userStore = new UserStore<IdentityUser>(context.Get<AirticketDataContext>());
            var manager = new UserManager<IdentityUser>(userStore);

            return manager;
        }
    }
}