using Bezaleel_Bagoes_A_A_fdtest.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSession();

//for mysql connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(10, 11, 9))));

// Build and run
var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.MapRazorPages();

app.Run();
