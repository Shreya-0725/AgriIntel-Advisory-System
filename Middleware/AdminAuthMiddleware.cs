using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AgriIntel_Advisory_System.Middleware
{
    public class AdminAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AdminAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Check if the request is for Admin pages (except login page)
            if (context.Request.Path.StartsWithSegments("/Admin") &&
                !context.Request.Path.Value.Contains("AdminLogin"))
            {
                var token = context.Session.GetString("JWToken");

                if (string.IsNullOrEmpty(token))
                {
                    // Redirect to login if token not found
                    context.Response.Redirect("/Admin/AdminLogin");
                    return; // stop further processing
                }
            }

            await _next(context); // continue to the requested page
        }
    }
}