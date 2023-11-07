using Microsoft.EntityFrameworkCore;
using NOVOROV.Context;
using NOVOROV.Models;

namespace NOVOROV.Middlewares
{
    public class UserFeaturesMiddleware
    {
        private readonly RequestDelegate _next;

        public UserFeaturesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, RovDbContext dbContext)/*, IUserFeaturesService userFeaturesService)*/
        {
            if (context.Request.Path != "/Error/Fatal")
            {
                var windowsLogin = context.User.Identity.Name.Split("\\")[1]; //"40414403" "A0108050";;



                var user = dbContext.Usuario.AsNoTracking()
                    .Include(x => x.Perfil)
                    .FirstOrDefault(u => u.UsuarioId == windowsLogin);


                if (user != null)
                {
                    context.Items["UserRole"] = user.Perfil.NomePerfil;
                    context.Items["UserName"] = user.NomeUsuario;
                    context.Items["UserMatricula"] = user.UsuarioId;
                }



                await _next(context);
            }
            else
            {
                await _next(context);
            }
        }

    }
}
