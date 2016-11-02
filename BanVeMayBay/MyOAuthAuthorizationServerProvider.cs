using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using BanVeMayBay.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;

namespace BanVeMayBay
{
    public class MyOAuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            UserManager<IdentityUser> userManager =
                context.OwinContext.GetUserManager<UserManager<IdentityUser>>();

            IdentityUser user;
            try
            {
                user = await userManager.FindAsync(context.UserName, context.Password);
            }
            catch
            {
                context.SetError("server_error");
                context.Rejected();
                return;
            }

            if (user != null)
            {
                try
                {
                    ClaimsIdentity identity = await userManager.CreateIdentityAsync(
                        user,
                        DefaultAuthenticationTypes.ExternalBearer);

                    context.Validated(identity);
                }
                catch
                {
                    context.SetError("server_error");
                    context.Rejected();
                }
            }
            else
            {
                context.SetError(
                    "invalid_grant",
                    "Client is not allowed for the 'Resource Owner Password Credentials Grant'");

                context.Rejected();
            }
        }
    }
}