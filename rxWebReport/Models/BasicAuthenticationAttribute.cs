using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace rxWebReport.Models
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private const string Realm = "Getlock";
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //If the Authorization header is empty or null
            //then return Unauthorized
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
                // If the request was unauthorized, add the WWW-Authenticate header 
                // to the response which indicates that it require basic authentication
                if (actionContext.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    actionContext.Response.Headers.Add("WWW-Authenticate",
                        string.Format("Basic realm=\"{0}\"", Realm));
                }
            }
            else
            {
                //Get the authentication token from the request header
                string authenticationToken = actionContext.Request.Headers
                    .Authorization.Parameter;

                string decodedAuthenticationToken = string.Empty;
                string username = string.Empty;
                string password = string.Empty;

                try
                {
                    //Decode the string
                    decodedAuthenticationToken = Encoding.UTF8.GetString(
                        Convert.FromBase64String(authenticationToken));

                    //Convert the string into an string array
                    string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                    //First element of the array is the username
                    username = usernamePasswordArray[0];
                    //Second element of the array is the password
                    password = usernamePasswordArray[1];
                    //call the login method to check the username and password

                    var user = UserValidate.Login(username, password);

                    if (user != null)
                    {
                        var identity = new GenericIdentity(username);

                        var cofres = new List<string>();

                        foreach (var cofre in user.GetLockCofres)
                        {
                            cofres.Add(cofre.id_cofre);
                        }

                        identity.AddClaim(new Claim("Cofres", string.Join(",", cofres)));
                        IPrincipal principal = new GenericPrincipal(identity, null);
                        Thread.CurrentPrincipal = principal;
                        if (HttpContext.Current != null)
                        {
                            HttpContext.Current.User = principal;
                        }
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request
                            .CreateResponse(HttpStatusCode.Unauthorized);
                    }
                }
                catch (Exception ex)
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}