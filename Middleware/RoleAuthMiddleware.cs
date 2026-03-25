using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AgriIntel_Advisory_System.Middleware
{
    public class RoleAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();

            if (string.IsNullOrEmpty(path) || path.Contains("/home/login"))
            {
                await _next(context);
                return;
            }

            string? sessionKey = path.StartsWith("/farmer") ? "FarmerId"
                            : path.StartsWith("/expert") ? "ExpertId"
                            : path.StartsWith("/staff") ? "EmpId"
                            : path.StartsWith("/kisankendra") ? "KKId"
                            : null;

            if (sessionKey != null)
            {
                var token = context.Session.GetString("JWToken");
                var id = context.Session.GetString(sessionKey);

                if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(id))
                {
                    context.Response.Redirect("/Home/Login");
                    return;
                }
            }

            await _next(context);
        }
    }

    public static class RoleAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseRoleAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoleAuthMiddleware>();
        }
    }
}