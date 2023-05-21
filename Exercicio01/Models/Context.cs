using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exercicio01.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
