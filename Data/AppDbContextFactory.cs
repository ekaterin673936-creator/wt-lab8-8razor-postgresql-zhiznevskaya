using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace wt_lab8_8razor_postgresql_zhiznevskaya.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        // Строка подключения для локальных миграций (можно использовать любую)
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=wt_lab8;Username=postgres;Password=1234");
        
        return new AppDbContext(optionsBuilder.Options);
    }
}