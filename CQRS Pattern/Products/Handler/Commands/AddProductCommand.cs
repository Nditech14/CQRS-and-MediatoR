
using MediatR;

namespace CQRS_Pattern.Commands
{
    public record AddProductCommand(Product Products) : IRequest;
  
}
