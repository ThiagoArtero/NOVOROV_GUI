using Microsoft.EntityFrameworkCore;
using NOVOROV.Context;

namespace NOVOROV.Middlewares
{
    public class UserAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public UserAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, RovDbContext dbContext)
        {
            if (context.Request.Path != "/Error/Fatal")
            {
                var windowsLogin = context.User.Identity.Name.Split("\\")[1];

                if (windowsLogin == null)
                    context.Response.Redirect("/Error/Fatal");

                if (!context.User.Identity.IsAuthenticated)
                    context.Response.Redirect("/Error/Fatal");

                var user = await dbContext.Usuario
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.UsuarioId == windowsLogin);

                if (user == null)
                    context.Response.Redirect("/Error/Fatal");

                await _next(context);
            }
            else
            {
                await _next(context);
            }
        }
    }
}
