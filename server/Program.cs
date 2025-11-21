
// using Microsoft.EntityFrameworkCore;
//using TodoApi.Models;
//using TodoApi.Data;
// using TodoApi;
//using ToDoDbContext;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
// using MyApp.Models;
//using Microsoft.AspNetCore.Http.Features;
// //using Item;
// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();
// app.MapGet("/", () => "API עובד!");


// // הזרקת DbContext
// builder.Services.AddDbContext<ToDoDbContext>(options =>
//     options.UseMySql(builder.Configuration.GetConnectionString("ToDoDB"),
//         new MySqlServerVersion(new Version(8, 0, 44))));



// // ROUTES
// app.MapGet("/items", async (ToDoDbContext db) =>
//     await db.Items.ToListAsync());

// app.MapPost("/items", async (ToDoDbContext db, Item newItem) =>
// {
//     db.Items.Add(newItem);
//     await db.SaveChangesAsync();
//     return Results.Created($"/items/{newItem.Id}", newItem);
// });

// app.MapPut("/items/{id}", async (ToDoDbContext db, int id, Item updatedItem) =>
// {
//     var item = await db.Items.FindAsync(id);
//     if (item is null) return Results.NotFound();
//     item.Name = updatedItem.Name;
//     item.IsComplete = updatedItem.IsComplete;
//     await db.SaveChangesAsync();
//     return Results.NoContent();
// });

// app.MapDelete("/items/{id}", async (ToDoDbContext db, int id) =>
// {
//     var item = await db.Items.FindAsync(id);
//     if (item is null) return Results.NotFound();
//     db.Items.Remove(item);
//     await db.SaveChangesAsync();
//     return Results.NoContent();
// });

// app.Run();
//========================================
// using Microsoft.EntityFrameworkCore;
// using MyApp.Models;
// using TodoApi;

// var builder = WebApplication.CreateBuilder(args);

// // הזרקת DbContext
// builder.Services.AddDbContext<ToDoDbContext>(options =>
//     options.UseMySql(builder.Configuration.GetConnectionString("ToDoDB"), 
//         new MySqlServerVersion(new Version(8, 0, 44))));

// var app = builder.Build();

// app.MapGet("/", () => "API עובד!");

// // ROUTES
// app.MapGet("/items", async (ToDoDbContext db) => await db.Items.ToListAsync());

// app.MapPost("/items", async (ToDoDbContext db, Item newItem) =>
// {
//     db.Items.Add(newItem);
//     await db.SaveChangesAsync();
//     return Results.Created($"/items/{newItem.Id}", newItem);
// });

// app.MapPut("/items/{id}", async (ToDoDbContext db, int id, Item updatedItem) =>
// {
//     var item = await db.Items.FindAsync(id);
//     if (item is null) return Results.NotFound();
//     item.Name = updatedItem.Name;
//     item.IsComplete = updatedItem.IsComplete;
//     await db.SaveChangesAsync();
//     return Results.NoContent();
// });

// app.MapDelete("/items/{id}", async (ToDoDbContext db, int id) =>
// {
//     var item = await db.Items.FindAsync(id);
//     if (item is null) return Results.NotFound();
//     db.Items.Remove(item);
//     await db.SaveChangesAsync();
//     return Results.NoContent();
// });

// app.Run();
//==========================================
// using Microsoft.EntityFrameworkCore;
// using MyApp.Models;
// using TodoApi;

// var builder = WebApplication.CreateBuilder(args);

// // הוספת שירות CORS
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll", policy =>
//     {
//         policy.AllowAnyOrigin()  // מאפשר לכל דומיין לפנות
//               .AllowAnyHeader()  // מאפשר כל כותרת (header)
//               .AllowAnyMethod(); // מאפשר כל HTTP Method (GET, POST, PUT וכו')
//     });
// });

// // הזרקת DbContext
// builder.Services.AddDbContext<ToDoDbContext>(options =>
//     options.UseMySql(builder.Configuration.GetConnectionString("ToDoDB"), 
//         new MySqlServerVersion(new Version(8, 0, 44))));

// var app = builder.Build();

// // הגדרת ה-CORS על כל ה-API
// app.UseCors("AllowAll");  // מגדיר שהמדיניות AllowAll תיושם לכל ה-API

// // ROUTES
// app.MapGet("/", () => "API עובד!");

// app.MapGet("/items", async (ToDoDbContext db) => await db.Items.ToListAsync());

// app.MapPost("/items", async (ToDoDbContext db, Item newItem) =>
// {
//     db.Items.Add(newItem);
//     await db.SaveChangesAsync();
//     return Results.Created($"/items/{newItem.Id}", newItem);
// });

// app.MapPut("/items/{id}", async (ToDoDbContext db, int id, Item updatedItem) =>
// {
//     var item = await db.Items.FindAsync(id);
//     if (item is null) return Results.NotFound();
//     item.Name = updatedItem.Name;
//     item.IsComplete = updatedItem.IsComplete;
//     await db.SaveChangesAsync();
//     return Results.NoContent();
// });

// app.MapDelete("/items/{id}", async (ToDoDbContext db, int id) =>
// {
//     var item = await db.Items.FindAsync(id);
//     if (item is null) return Results.NotFound();
//     db.Items.Remove(item);
//     await db.SaveChangesAsync();
//     return Results.NoContent();
// });

// app.Run();

//===================================
using Microsoft.EntityFrameworkCore;
using MyApp.Models;
using TodoApi;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// הוספת שירות CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // מאפשר לכל דומיין לפנות
              .AllowAnyHeader()  // מאפשר כל כותרת (header)
              .AllowAnyMethod(); // מאפשר כל HTTP Method (GET, POST, PUT וכו')
    });
});

// הזרקת DbContext
builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ToDoDB"), 
        new MySqlServerVersion(new Version(8, 0, 44))));

// הוספת Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// הפעלת Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// הגדרת ה-CORS על כל ה-API
app.UseCors("AllowAll");

// ROUTES
app.MapGet("/", () => "API עובד!");

app.MapGet("/items", async (ToDoDbContext db) => await db.Items.ToListAsync());

app.MapPost("/items", async (ToDoDbContext db, Item newItem) =>
{
    db.Items.Add(newItem);
    await db.SaveChangesAsync();
    return Results.Created($"/items/{newItem.Id}", newItem);
});

// app.MapPut("/items/{id}", async (ToDoDbContext db, int id, Item updatedItem) =>
// {
//     var item = await db.Items.FindAsync(id);
//     if (item is null) return Results.NotFound();
//     item.Name = updatedItem.Name;
//     item.IsComplete = updatedItem.IsComplete;
//     await db.SaveChangesAsync();
//     return Results.NoContent();
// });
app.MapPut("/items/{id}", async (ToDoDbContext db, int id, Item updatedItem) =>
{
    var item = await db.Items.FindAsync(id);
    if (item is null) return Results.NotFound();

    if (updatedItem.Name is not null)
        item.Name = updatedItem.Name;

    item.IsComplete = updatedItem.IsComplete;

    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/items/{id}", async (ToDoDbContext db, int id) =>
{
    var item = await db.Items.FindAsync(id);
    if (item is null) return Results.NotFound();
    db.Items.Remove(item);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
