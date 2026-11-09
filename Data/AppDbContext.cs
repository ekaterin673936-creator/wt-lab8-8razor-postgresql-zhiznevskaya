using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_zhiznevskaya.Models;

namespace wt_lab8_8razor_postgresql_zhiznevskaya.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars => Set<Car>();
}