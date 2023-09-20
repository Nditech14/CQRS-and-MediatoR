using MediatR;

namespace CQRS_Pattern.Product.Query
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;


}
