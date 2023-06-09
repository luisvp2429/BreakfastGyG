using BreakfastGyG.Common;
using BreakfastGyG.Persistence;
using BreakfastGyG.Services.Breakfasts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();

    builder.Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
    builder.Services.AddFluentValidationAutoValidation();

    builder.Services.AddDbContext<BreakfastGyGDbContext>(options =>
            options.UseSqlServer("Server=localhost;Database=BreakfastGyG;User Id=SA;Password=Luis*Passw0rd;Encrypt=false"));

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
    });
}

var app = builder.Build();
{
    app.UseCors("AllowAll");
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
