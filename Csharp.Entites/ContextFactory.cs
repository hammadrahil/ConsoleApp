using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Csharp.Entites
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public static string ConnectionString = "Server=localhost;Port=3306;Database=CarCompanyDB;User=root;Password=YOUR_PASSWORD;SslMode=Preferred;";
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseMySql(ConnectionString,
                ServerVersion.AutoDetect(ConnectionString)); 
            return new Context(optionsBuilder.Options);
        }
    }
}
