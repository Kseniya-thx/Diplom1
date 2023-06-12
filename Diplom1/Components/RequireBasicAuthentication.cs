using System;
using System.Web;
using MySql.Data.MySqlClient;
using System.Web.Mvc;
using Diplom1.Components;

namespace Diplom1.Controllers.Filter
{
    public class RequireBasicAuthentication : ActionFilterAttribute
    {
        
        private readonly MySqlConnection _connection = ConnectionManager.GetConnection();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            if (String.IsNullOrEmpty(request.Headers["Authorization"]))
            {
                filterContext.HttpContext.Response.AddHeader("WWW-Authenticate", "Basic realm=\"Knowledge base\"");
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                var authorization = request.Headers["Authorization"];
                var credentials = System.Text.Encoding.UTF8.GetString(
                        Convert.FromBase64String(authorization.Substring(6)))
                    .Split(':');
                var user = new { Username = credentials[0], Password = credentials[1] };
                
                var command = new MySqlCommand("select * from vxod v, staff s where v.id = s.id AND v.password = '" + user.Password + "' AND name = '" + user.Username + "'", _connection);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        // Get current user - HttpContext.Session["Usernaem"] 
                        filterContext.HttpContext.Session["Username"] = user.Username;

                        // Get current user - HttpContext.Session["Role"] 
                        filterContext.HttpContext.Session["Role"] = user.Username;
                    }
                    else
                    {
                        filterContext.HttpContext.Response.AddHeader("WWW-Authenticate", "Basic realm=\"Knowledge base\"");
                        filterContext.Result = new HttpUnauthorizedResult();
                    }
                }
            }
        }
    }
}