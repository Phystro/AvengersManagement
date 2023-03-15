global using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AvengersManagement.Data
{
    public class AvengerContext : DbContext
    {
        public AvengerContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Avenger> Avengers => Set<Avenger>();

    }
}