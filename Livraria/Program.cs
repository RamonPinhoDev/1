using Livraria.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
{ options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); 
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Configura��es de senha
    options.Password.RequireDigit = false;                 // Nao Exige pelo menos um n�mero
    options.Password.RequireLowercase = false;             // Nao Exige pelo menos uma letra min�scula
    options.Password.RequireUppercase = false;             // Nao Exige pelo menos uma letra mai�scula
    options.Password.RequireNonAlphanumeric = false;      // N�o exige caracteres especiais
    options.Password.RequiredLength = 8;                  // M�nimo de 8 caracteres
    options.Password.RequiredUniqueChars = 4;             // Pelo menos 4 caracteres �nicos
});


// Adiciona suporte a cache distribu�do e sess�o(adcionado depois)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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
app.UseSession(); // Middleware de sess�o (adcionado depois)
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
