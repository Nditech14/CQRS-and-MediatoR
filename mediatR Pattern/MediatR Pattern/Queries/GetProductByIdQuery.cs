using MediatR;

namespace MediatR_Pattern.Queries
{
    public record  GetProductByIdQuery(int Id) :IRequest<Product>;
    
}
