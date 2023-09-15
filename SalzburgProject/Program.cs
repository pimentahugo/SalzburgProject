using Microsoft.EntityFrameworkCore;
using SalzburgProject.Data;
using SalzburgProject.Interface;
using SalzburgProject.Repository;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Configura a cultura padrão para pt-BR (português brasileiro)
var cultureInfo = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Configuração da localização (cultura) para as Views
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(cultureInfo);
    options.SupportedCultures = new List<CultureInfo> { cultureInfo };
    options.SupportedUICultures = new List<CultureInfo> { cultureInfo };
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
builder.Services.AddScoped<IFolgaRepository, FolgaRepository>();
builder.Services.AddScoped<IChavePixRepository, ChavePixRepository>();
builder.Services.AddScoped<ICustoRepository, CustoRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
