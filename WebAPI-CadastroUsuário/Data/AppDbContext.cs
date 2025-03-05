using Microsoft.EntityFrameworkCore;
using WebAPI_CadastroUsuário.Models;

namespace WebAPI_CadastroUsuário.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> usuario { get; set; }
    }
}
