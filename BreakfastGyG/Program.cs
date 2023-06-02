using BreakfastGyG.Persistence;
using BreakfastGyG.Services.Breakfasts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
    builder.Services.AddDbContext<BreakfastGyGDbContext>(options =>
            options.UseSqlServer("Server=localhost;Database=BuberDinner;User Id=SA;Password=amiko123!;TrustServerCertificate=true"));
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
