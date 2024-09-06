using CrudProductos.Src.Dtos;

namespace CrudProductos.Src.Handlers
{
    public class CreateProductHandler: ICreateProductHandler
    {

        public IResult Execute(ProductDto productDto, List<ProductDto> database){

            if(string.IsNullOrWhiteSpace(productDto.nombre)){
                return Results.BadRequest("field name is required!");
            }

            if(database.Any(producto => producto.uuid == productDto.uuid)){
                return Results.Conflict($"product with id {productDto.uuid} exists");
            }

            database.Add(productDto);

            return Results.Created($"product created", productDto);
        }

    }
}