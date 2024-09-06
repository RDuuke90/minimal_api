using CrudProductos.Src.Dtos;

namespace CrudProductos.Src.Handlers
{
    public static class UpdateProductHandler
    {

        public static IResult Execute(Guid uuid, ProductDto productDto, List<ProductDto> database){
            var product = database.FirstOrDefault( producto => producto.uuid == uuid);

            if(product is null) {
                return Results.NotFound($"product with id {uuid} not found");
            }

            product.nombre = productDto.nombre;
            product.precio = productDto.precio;

            return Results.Ok(product);
        }
    }
}