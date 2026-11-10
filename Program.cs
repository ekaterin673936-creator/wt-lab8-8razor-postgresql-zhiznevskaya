using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_zhiznevskaya.Data;

var builder = WebApplication.CreateBuilder(args);

// ===== Подключение к PostgreSQL =====
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
if (!string.IsNullOrWhiteSpace(databaseUrl))
{
    var cleanUrl = databaseUrl.Replace("postgresql://", "").Replace("postgres://", "");
    var parts = cleanUrl.Split('@');
    var userInfo = parts[0].Split(':', 2);
    var hostAndDb = parts[1].Split('/', 2);
    var hostAndPort = hostAndDb[0].Split(':', 2);

    string user = userInfo[0];
    string password = userInfo.Length > 1 ? userInfo[1] : "";
    string host = hostAndPort[0];
    string port = hostAndPort.Length > 1 ? hostAndPort[1] : "5432";
    string database = hostAndDb.Length > 1 ? hostAndDb[1] : "postgres";

    connectionString = $"Host={host};Port={port};Database={database};Username={user};Password={password};SSL Mode=Disable";
}

// ВОТ ЭТА СТРОКА ДОЛЖНА БЫТЬ ОБЯЗАТЕЛЬНО!
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// ===== Razor Pages =====
builder.Services.AddRazorPages();

var app = builder.Build();

// ===== Автоматическое применение миграций при запуске =====
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// ===== Pipeline =====
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

// ===== Запуск =====
var appPort = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{appPort}");