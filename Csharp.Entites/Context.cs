using Csharp.Entites.Model;
using Microsoft.EntityFrameworkCore;

namespace Csharp.Entites
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<CarCompany> CarCompanies { get; set; } = default!; 
    }
}