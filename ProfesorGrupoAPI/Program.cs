using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProfesorGrupoAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddDbContext<Sistem21PrimariaContext>(
    optionsBuilder => optionsBuilder.UseMySql("server=sistemas19.com;database=sistem21_primaria;user=sistem21_Test;password=sistemas20_", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.17-mariadb"))
    );
var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.Run();
