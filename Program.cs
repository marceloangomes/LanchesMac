using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LanchesMac.Context;
using LanchesMac.Repositories;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.Models;


var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddDbContext<AppDbContext>(options=>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
    
builder.Services.Configure<IdentityOptions>(options=>
{
    options.Password.RequireDigit=false;
    options.Password.RequireLowercase=false;
    options.Password.RequireNonAlphanumeric=false;
    options.Password.RequireUppercase=false;
    options.Password.RequiredLength=3;
    options.Password.RequiredUniqueChars=1;
});

builder.Services.AddTransient<ICategoriaRepository,CategoriaRepository>();
builder.Services.AddTransient<ILancheRepository,LancheRepository>();
builder.Services.AddTransient<IPedidoRepository,PedidoRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddScoped(sp => CarrinhoCompra.ObterInstancia(sp));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "CategoriaFiltro",
    pattern: "Lanche/{action}/{categoria?}",
    defaults: new {controller="Lanche", action="List"});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
