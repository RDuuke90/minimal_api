using CrudProductos.Src.Dtos;
using CrudProductos.Src.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICreateProductHandler, CreateProductHandler>();

var app = builder.Build();

/**
    Crear POST
    Obtener GET
    Actualizar PUT
    Borrar DELETE

    //api/v1/modulo -> /api/v1/producto
*/

List<ProductDto> database = new List<ProductDto>();

app.MapPost("/api/v1/producto", (ProductDto productDto, ICreateProductHandler handler) => {
    return handler.Execute(database:database, productDto:productDto);
});

app.MapGet("/api/v1/producto", () => {
    return Results.Ok(database);
});

app.MapGet("/api/v1/producto/{uuid}", (Guid uuid) => {
    return GetByUuidProductHandler.Execute(uuid:uuid, database:database);
});

app.MapPut("/api/v1/producto/{uuid}", (Guid uuid, ProductDto productDto) => {
    return UpdateProductHandler.Execute(uuid:uuid, database:database, productDto:productDto);
});
app.MapDelete("/api/v1/producto/{uuid}", (Guid uuid) => {
    return DeleteProductHandler.Execute(uuid:uuid, database:database);
});

app.Run();
