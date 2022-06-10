using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using minnimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<KioscoDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Post
app.MapPost("/productoitems", async (Producto producto, KioscoDBContext db) =>
{
    db.Producto.Add(producto);
    await db.SaveChangesAsync();
    return Results.Created($"/productoitems/{producto.ProductID}", producto);

});
app.MapPost("/caracteristicasitems", async(Caracteristicas cat, KioscoDBContext db)=>{
    db.Caracteristica.Add(cat);
    await db.SaveChangesAsync();
    return Results.Created($"/caracteristicasitems/{cat.CaracteristicaID}", cat);
});

//Get
app.MapGet("/productoitems", async(KioscoDBContext db)=>
await db.Producto.ToListAsync());

app.MapGet("/caracteristicasitems", async (KioscoDBContext db) =>
await db.Caracteristica.ToListAsync());

//GetID
app.MapGet("/productoitems/{id}", async (int id, KioscoDBContext DB) =>

    await DB.Producto.FindAsync(id)
    is Producto p
    ? Results.Ok(p)
    : Results.NotFound());

app.MapGet("/caracteristicasitems/{id}", async (int id, KioscoDBContext DB) =>

    await DB.Caracteristica.FindAsync(id)
    is Caracteristicas p
    ? Results.Ok(p)
    : Results.NotFound());

//Put
app.MapPut("/productoitems/{id}", async (int id, Producto p, KioscoDBContext db)=>
{
    var producto = await db.Producto.FindAsync(id);
    if (producto is null) return Results.NotFound();
    producto.ProductName = p.ProductName;
    producto.FechaBaja = p.FechaBaja;
    producto.Category = p.Category;
    await db.SaveChangesAsync();
    return Results.NoContent(); 
});

app.MapPut("/caracteristicasitems/{id}", async (int id, Caracteristicas p, KioscoDBContext db) =>
{
    var producto = await db.Caracteristica.FindAsync(id);
    if (producto is null) return Results.NotFound();
    producto.Precio = p.Precio;
    producto.Ancho = p.Ancho;
    producto.Largo = p.Largo;
    producto.ProductID = p.ProductID;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

//Delete
app.MapDelete("/productoitems/{id}", async (int id, KioscoDBContext db) =>
{
    if(await db.Producto.FindAsync(id) is Producto producto)
    {
        db.Producto.Remove(producto);
        await db.SaveChangesAsync();
        return Results.Ok(producto);
    }

    return Results.NotFound();
});

app.MapDelete("/caracteristicasitems/{id}", async (int id, KioscoDBContext db) =>
{
    if (await db.Caracteristica.FindAsync(id) is Caracteristicas producto)
    {
        db.Caracteristica.Remove(producto);
        await db.SaveChangesAsync();
        return Results.Ok(producto);
    }

    return Results.NotFound();
});

app.Run();

