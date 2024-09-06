using CrudProductos.Src.Dtos;

namespace CrudProductos.Src.Handlers
{
    public static class GetByUuidProductHandler
    {

        public static IResult Execute(Guid uuid, List<ProductDto> database){
            var product = database.FirstOrDefault( producto => producto.uuid == uuid);

            if(product is null) {
                return Results.NotFound($"product with id {uuid} not found");
            }
            return Results.Ok(product);
        }
    }
}