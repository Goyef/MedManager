// set up the basic features of the ASP.NET Core platform

using System;
using ASPBookProject.Data;
using ASPBookProject.Models;
using ASPBookProject.Services.Class;
using ASPBookProject.Services.FakeDataService;
using ASPBookProject.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ASPBookProject.Logging;



using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

string logFilePath = "app_log.txt";
StreamWriter logFileWriter = new StreamWriter(logFilePath, append: true);
builder.Logging.ClearProviders();
builder.Logging.AddProvider(new CustomFileLoggerProvider(logFileWriter));

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddControllersWithViews();



// Enregistrement d'un service 
builder.Services.AddSingleton<IFakeDataService, FakeDataService>();
// Assurez vous que cette ligne soit placée avant : var app = builder.Build();
//builder.Services.AddSingleton<IMyFirstService, MyFirstService>();
// Nous n'avons maintenant plus à nous soucier à creer une instance de MyFristServie
// au sein de notre application, le service d'injection de dependance s'en
// chargera pour nous ! 

var serverVersion = new MySqlServerVersion(new Version(11, 0, 2));

// Ajout du dbcontext au service container
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion)
);

builder.Services.AddIdentity<Medecin, IdentityRole>(options =>
  {
      options.SignIn.RequireConfirmedAccount = false;
      options.Password.RequireDigit = false;
      options.Password.RequireLowercase = false;
      options.Password.RequireNonAlphanumeric = false;
      options.Password.RequireUppercase = false;
      options.Password.RequiredLength = 1;

      options.User.RequireUniqueEmail = false;
  }
).AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
        options.LoginPath = "/Account/Login"
    );


// set up middleware components
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error/Index");
    app.UseStatusCodePagesWithRedirects("/Error/Index"); // Pour les erreurs 404
    // autre middleware pour les exceptions
}

// Verification que la base de donnees est creee
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
context.Database.EnsureCreated();

// Par défaut les fichiers contenus au sein du dossier wwwroot ne 
// sont pas accessible coté client
// Le composant middleware UseStaticFiles le permet
app.UseStaticFiles(); // give access to files in wwwroot

// Au sein de notre projet UseStaticFiles() sera appelé avant 
app.UseAuthentication();
//ce qui permettra l'accès aux fichiers 
// statiques aux utilisateurs non authentifiés, attention 
// à ne pas stocker des données sensibles dans le dossier wwwroot

// Pour l'accès aux fichiers statiques vous pouvez utiliser un chemin
// relatif au web root, par exemple l'acces au fichier wwwroot/images/image01.jpg,
// on utilisera le chemin http://localhost:5245/images/image01.jpg

app.UseRouting();

app.UseAuthorization();
app.UseRotativa();
var env = app.Environment;
RotativaConfiguration.Setup(env.WebRootPath, "Rotativa");


// Default Routing system
// app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}"
);

app.Run();
