using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SpanishWebApi.Data
{
    public class SpanishDbContextFactory : IDesignTimeDbContextFactory<SpanishDbContext>
    {
        public SpanishDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SpanishDbContext>();
            optionsBuilder.UseSqlite("Data Source=Data/spanish.db");
            return new SpanishDbContext(optionsBuilder.Options);
        }
    }
}