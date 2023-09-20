using CQRS_Pattern.Product.Query;
using MediatR;

namespace CQRS_Pattern.Product.Handler
{
    public class GetProductshandler : IRequestHandler<Query.GetProductsQuery, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetProductshandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<IEnumerable<Product>> Handle(Query.GetProductsQuery request, CancellationToken cancellationToken) => await _fakeDataStore.GetAllProducts();

    }
}

