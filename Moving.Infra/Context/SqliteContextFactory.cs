using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Moving.Infra.Context;

public class SqliteContextFactory : IDesignTimeDbContextFactory<SqliteContext>
{
    public SqliteContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SqliteContext>();
        var databasePath = SqliteDatabasePath.ForDesignTime(Directory.GetCurrentDirectory());
        optionsBuilder.UseSqlite($"Data Source={databasePath}");

        return new SqliteContext(optionsBuilder.Options);
    }
}
