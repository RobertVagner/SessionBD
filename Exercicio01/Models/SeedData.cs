using Microsoft.EntityFrameworkCore;

namespace Exercicio01.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            Context context = app.ApplicationServices.GetRequiredService<Context>();
            context.Database.Migrate();
            if (!context.Usuarios.Any())
            {
                var usuario = new Usuario { Senha = "123456", Nome = "robert", Email = "robert@gmail.com" };
                context.Usuarios.AddRange(usuario);
                context.SaveChanges();
            }
        }
    }
}
