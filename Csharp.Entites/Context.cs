using Csharp.Entites.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp.Entites
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)  : base(options) { }

        public DbSet<CarCompany> CarCompanies { get; set; }

    }
}
