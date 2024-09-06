using CrudProductos.Src.Dtos;

namespace CrudProductos.Src.Handlers
{
    public static class DeleteProductHandler
    {

        public static IResult Execute(Guid uuid, List<ProductDto> database){
            var product = database.FirstOrDefault( producto => producto.uuid == uuid);

            if(product is null) {
                return Results.NotFound($"product with id {uuid} not found");
            }

            database.Remove(product);

            return Results.NoContent();
        }
    }
}