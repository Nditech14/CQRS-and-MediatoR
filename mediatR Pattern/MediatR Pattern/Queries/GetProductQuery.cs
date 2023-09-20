using MediatR;

namespace MediatR_Pattern.Queries
{
    public record GetProductQuery : IRequest<IEnumerable<Product>>;
    
    
}
