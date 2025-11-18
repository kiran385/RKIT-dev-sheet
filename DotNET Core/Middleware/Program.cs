using Microsoft.AspNetCore.Mvc;
using Middleware.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


// Use method
app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware 1 - Before");
    await next();
    Console.WriteLine("Middleware 1 - After");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware 2 - Before");
    await next();
    Console.WriteLine("Middleware 2 - After");
});

//app.Run(async context =>
//{
//    Console.WriteLine("Middleware 3 - Terminal");
//    await context.Response.WriteAsync("Hello from terminal middleware");
//});


// Map method 
app.Map("/m1", appMap =>
{
    appMap.Run(async context =>
    {
        await context.Response.WriteAsync("Hello from app.Map()");
    });
});


// Custom middleware
app.UseCustomMiddleware();


app.UseDefaultFiles();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

// This is for convention based routing
//app.UseRouting();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Values}/{action=Get}/{id?}");

app.Run();
