using CrudProductos.Src.Dtos;

namespace CrudProductos.Src.Handlers
{
    public interface ICreateProductHandler
    {
        IResult Execute(ProductDto productDto, List<ProductDto> database);
    }
}