using MediatR;

namespace MediatR_Pattern.Command
{
    public record AddProductCommand(Product Product) : IRequest<Product>;
    
        
    

    
    
}
